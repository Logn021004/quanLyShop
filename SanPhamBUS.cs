using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyShop
{
     class SanPhamBUS
    {
        private static SanPhamBUS instance;
        public static SanPhamBUS Instance
        {
            get
            {
                if(instance == null)
                    instance = new SanPhamBUS();
                return instance;
            }   
        }
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";

        public void Xem(FlowLayoutPanel dssp)
        {
            //FlowLayoutPanel dssp = new FlowLayoutPanel();
            dssp.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select SANPHAM.MASP,TENSP,IMG,DONGIABAN,SOLUONGTONKHO from SANPHAM where TRANGTHAI=N'Còn hàng'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    int giamgia = tiengiamgia(sdr[0].ToString());
                    ItemSP itemsp = new ItemSP() { TenSP = sdr[1].ToString(), PathImg = sdr[2].ToString(), Giamgia = giamgia, Gia = int.Parse(sdr[3].ToString()) , Soluong = int.Parse(sdr[4].ToString()) };
                    itemsp.Tag = sdr[0].ToString();
                    itemsp.setMoney();
                    dssp.Controls.Add(itemsp);
                }
                conn.Close();
            }
           // return dssp;
        }
        public void Search(FlowLayoutPanel dsSearch,string tensp,string tenloai,string tenncc)
        {
            dsSearch.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string maloai = "", mancc = "";
                string query = "";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr;
                if (tenloai!="Chọn loại")
                {
                     query = "select * from LOAI where TENLOAI= @TENLOAI\r\n";
                     cmd = new SqlCommand(query, conn);
                     cmd.Parameters.AddWithValue("@TENLOAI", tenloai);
                     sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                        maloai = sdr[0].ToString();
                    sdr.Close();
                }
                if (tenncc != "Chọn nhà cung cấp")
                {
                    query = "select * from NHACUNGCAP where TENNCC= @TENNCC ";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TENNCC", tenncc);
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                        mancc = sdr[0].ToString();
                    sdr.Close();
                }
                query = "select MASP,TENSP,IMG,DONGIABAN,SOLUONGTONKHO from SANPHAM\r\nwhere 1=1 ";
                if (!string.IsNullOrEmpty(tensp))
                {
                    query += "AND TENSP like N'%" +tensp+"%'";
                }
                if (maloai != "")
                {
                    query += " AND LOAI='" + maloai+"'";
                }
                if (mancc != "")
                {
                    query += " AND MANCC='" + mancc + "'";
                }
                cmd = new SqlCommand(query, conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    int giamgia = tiengiamgia(sdr[0].ToString());
                    ItemSP itemsp = new ItemSP() { TenSP = sdr[1].ToString(), PathImg = sdr[2].ToString(), Giamgia = giamgia, Gia = int.Parse(sdr[3].ToString()), Soluong = int.Parse(sdr[4].ToString()) };
                    itemsp.Tag = sdr[0].ToString();
                    itemsp.setMoney();
                    dsSearch.Controls.Add(itemsp);
                }
                conn.Close();
            }
        }
        public bool XoaSP(string maSP)
        {
            return SanPhamDAO.Instance.XoaSP(maSP);
        }
        public void CapNhapSP(string maSP, Label tenSP, Label ncc, Label sl, Label gia, Label loai, Label trangthai, Label mota)
        {
            string path_img;
            using (SqlConnection conn =new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select IMG from SANPHAM where MASP=@MASP";
                SqlCommand cmd=new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MASP", maSP);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                path_img=sdr[0].ToString();
                sdr.Close();
                conn.Close();
            }
            string str_price = gia.Text.Replace(",", "").Replace(" ₫", "");
            float price = float.Parse(str_price);
            int Sltonkho = int.Parse(sl.Text.ToString());
            formCapNhapSP form = new formCapNhapSP {Loai=loai.Text,Soluongtonkho=Sltonkho,Giaban=price,Masp=maSP, Tensp =tenSP.Text, Mota = mota.Text, Ncc = ncc.Text, Trangthai = trangthai.Text,PathImg=path_img };
            form.Show();
            
        }
        public void ThemSP()
        {
            formAddSP item = new formAddSP();
            item.Show();
        }
        public int tiengiamgia(string MASP)
        {
            int money = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select TIENGIAM,NGAYAPDUNG,NGAYKT from SANPHAM,KHUYENMAI where SANPHAM.MASP=KHUYENMAI.MASP and SANPHAM.MASP='" + MASP + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                if (Functions.Instance.ExecuteQuery(query).Rows.Count > 0)
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    DateTime date = DateTime.Now.Date;
                    while (sdr.Read())
                    {
                        DateTime dateBD = Convert.ToDateTime(sdr[1]);
                        DateTime dateKT = Convert.ToDateTime(sdr[2]);
                        if (dateBD <= date && dateKT >= date)
                        {
                             money = int.Parse(sdr[0].ToString());
                            break;
                        }
                    }
                }
                conn.Close();
            }
            return money;
        }
        public void dsSize(ListView dsSie,string maSP)
        {
            dsSie.Items.Clear();
            ListView dsTemp = SanPhamDAO.Instance.DSSize(maSP);
            foreach(ListViewItem item in dsTemp.Items)
            {
                ListViewItem newItem=new ListViewItem(item.Text);

                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {   
                    if ( subitem.Text!=item.Text)
                    newItem.SubItems.Add(subitem.Text); 
                }
                dsSie.Items.Add(newItem);
            }
        }
        public void info(string maSP,Label tenSP, Label ncc,Label sl,Label gia, Label loai, Label trangthai, Label mota)
        {
            object[] in4 = SanPhamDAO.Instance.thongtinSP(maSP);
            tenSP.Text = in4[0].ToString();
            ncc.Text = in4[1].ToString();
            sl.Text = in4[2].ToString();
            gia.Text = int.Parse(in4[3].ToString()).ToString("#,#") + " ₫";
            loai.Text = in4[4].ToString();
            trangthai.Text = in4[5].ToString();
            mota.Text = in4[6].ToString();
        }

        public void dsLoai(ComboBox cbodsLoai)
        {
            cbodsLoai.Items.Clear();
            cbodsLoai.Items.Add("Chọn loại");
            foreach(var item in SanPhamDAO.Instance.dsLoai().Items)
            {
                cbodsLoai.Items.Add(item);
            }
            cbodsLoai.SelectedIndex = 0;
        }
        public void dsNCC(ComboBox cbodsNCC)
        {
            cbodsNCC.Items.Clear();
            cbodsNCC.Items.Add("Chọn nhà cung cấp");
            foreach (var item in SanPhamDAO.Instance.dsNCC().Items)
            {
                cbodsNCC.Items.Add(item);
            }
            cbodsNCC.SelectedIndex = 0;
        }
        
        
    }
}
