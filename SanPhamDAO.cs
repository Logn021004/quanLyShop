using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace quanLyShop
{
    class SanPhamDAO
    {
        private static SanPhamDAO instance;
        public static SanPhamDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new SanPhamDAO();
                }
                return instance;
            }
            //set { instance = value; }
        }
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";

        public FlowLayoutPanel Xem()
        {
            FlowLayoutPanel dssp = new FlowLayoutPanel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select SANPHAM.MASP,TENSP,IMG,DONGIABAN,SOLUONGTONKHO from SANPHAM\r\n";
                SqlCommand cmd = new SqlCommand(query,conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    int giamgia = tiengiamgia(sdr[0].ToString());                  
                    ItemSP itemsp=new ItemSP() { TenSP = sdr[1].ToString(), PathImg = sdr[2].ToString(), Gia = int.Parse(sdr[3].ToString()), Giamgia = giamgia, Soluong = int.Parse(sdr[4].ToString()) };
                    itemsp.Tag = sdr[0].ToString();
                    dssp.Controls.Add(itemsp);
                }
               conn.Close();
            }
           return dssp;
        }
        public int tiengiamgia(string MASP)
        {
            int money = 0;
            string query = "select TIENGIAM from SANPHAM,KHUYENMAI WHERE SANPHAM.MASP= KHUYENMAI.MASP and SANPHAM.MASP= @MASP \r\n";
            object[] para = new object[] { MASP };
            if (Functions.Instance.ExecuteQuery(query, para).Rows.Count>0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MASP", MASP);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    money=int.Parse(sdr[0].ToString());
                    conn.Close();
                }
               
            }
            return money;
        }
        public ListView DSSize(string maSP)
        {
            ListView dssize = new ListView();
            using (SqlConnection conn=new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select SIZE,SIZESP.SOLUONGTONKHO from SIZESP,SANPHAM where SIZESP.MASP=SANPHAM.MASP and SANPHAM.MASP= @MASP \r\n";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MASP", maSP);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text =sdr[0].ToString();

                    ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item,sdr[1].ToString());
                    item.SubItems.Add(subitem);

                    dssize.Items.Add(item);
                }
                conn.Close();
            }
            return dssize;
            
        }
        public object[] thongtinSP(string maSP)
        {
            object[] info = new object[7];
            using (SqlConnection conn =new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select TENSP,TENNCC,SOLUONGTONKHO,DONGIABAN,l.TENLOAI,TRANGTHAI,MOTA\r\nfrom SANPHAM as sp,NHACUNGCAP as ncc,LOAI as l\r\nwhere sp.MANCC=ncc.MANCC and sp.LOAI=l.MALOAI and sp.MASP= @MASP";
                SqlCommand cmd=new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@MASP", maSP);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    info[0] = sdr[0].ToString();
                    info[1] = sdr[1].ToString();
                    info[2] = sdr[2].ToString();
                    int price = int.Parse(sdr[3].ToString()) - (int.Parse(sdr[3].ToString()) * tiengiamgia(maSP)) / 100;
                    info[3] = price.ToString();
                    info[4] = sdr[4].ToString();
                    info[5] = sdr[5].ToString();
                    info[6] = sdr[6].ToString();
                }
                conn.Close();
            }
            return info;
        }
        public ComboBox dsLoai()
        {
            ComboBox dsloai = new ComboBox();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from LOAI";
                SqlCommand cmd=new SqlCommand(query,conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    dsloai.Items.Add(sdr[1].ToString());
                }
                conn.Close();
            }
            return dsloai;
        }
        public ComboBox dsNCC()
        {
            ComboBox dsncc = new ComboBox();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from NHACUNGCAP\r\n";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    dsncc.Items.Add(sdr[1].ToString());
                }
                conn.Close();
            }
            return dsncc;
        }
        public bool XoaSP(string maSP)
        {
            string query = "update SANPHAM set TRANGTHAI=N'Ngưng bán' where MASP= @MASP ";
            object[] para = new object[] { maSP };
            if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                return true;
            return false;
        }
    }
}
