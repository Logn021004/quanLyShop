using System;
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select SANPHAM.MASP,TENSP,IMG,DONGIABAN,SOLUONGTONKHO from SANPHAM\r\n";
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
                    query += "AND TENSP like N'%" + tensp+"%'";
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
        public int tiengiamgia(string MASP)
        {
            int money = 0;
            string query = "select TIENGIAM from SANPHAM,KHUYENMAI WHERE SANPHAM.MASP= KHUYENMAI.MASP and SANPHAM.MASP= @MASP \r\n";
            object[] para = new object[] { MASP };
            if (Functions.Instance.ExecuteQuery(query, para).Rows.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MASP", MASP);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                        money = int.Parse(sdr[0].ToString());
                    conn.Close();
                }

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
