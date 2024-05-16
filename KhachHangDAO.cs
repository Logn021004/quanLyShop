using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace quanLyShop
{
    class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get
            {
                if(instance == null)
                    instance = new KhachHangDAO();
                return instance;
            }
        }
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";
        public DataTable listKhachHang()
        {
            string query = "select ID as N'Mã Khách',TENKHACH as N'Tên Khách', SDT as N'Số điện thoại',DCHI as N'Địa Chỉ' from KHACHHANG \r\n";
            return Functions.Instance.ExecuteQuery(query);
        }
        public ListView listHoaDonOfKhach(string idKhach)
        {
            ListView list = new ListView();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select HOADON.MAHD,NHANVIEN.TENNV,KHACHHANG.TENKHACH,HOADON.NGAYLAPHD,HOADON.GIAMGIA,HOADON.TONGTIEN,HOADON.TIENTRA,HOADON.TIENTHUA\r\nfrom HOADON,KHACHHANG,NHANVIEN \r\nwhere HOADON.MAKH=KHACHHANG.ID and HOADON.MANV=NHANVIEN.MANV and KHACHHANG.ID=@ID";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@ID", idKhach);
                SqlDataReader sdr=cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = sdr[0].ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text=sdr.GetString(1) });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sdr.GetString(2) });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sdr[3].ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sdr[4].ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sdr[5].ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sdr[6].ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sdr[7].ToString() });
                    list.Items.Add(item);
                }
              conn.Close();
            }
            return list;
        }
        public bool them(string name,int sdt,string dchi)
        {
            if (checksdt(sdt))
            {
                string query = "insert into KHACHHANG(TENKHACH,SDT,DCHI) values( @TENNV , @SDT , @DCHI )";
                object[] para = new object[] { name, sdt, dchi };
                if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                    return true;
                return false;
            }else
                return false;     
        }
        private bool checksdt(int sdt)
        {
            string query = "select * from KHACHHANG where SDT= @SDT \r\n";
            object[] para = new object[] {  sdt};
            if (Functions.Instance.ExecuteQuery(query, para).Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        public bool sua(string name, int sdt, string dchi,string id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from KHACHHANG where ID= @id \r\n";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdt == int.Parse( sdr[2].ToString()))
                {
                    return false;
                }
                else
                {
                    if (checksdt(sdt))
                    {
                        query = "update KHACHHANG set TENKHACH= @TENKHACH , SDT= @sdt ,DCHI= @dchi where ID= @id \r\n";
                        object[] para = new object[] { name, sdt, dchi, id };
                        if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                            return true;
                        return false;
                    }
                    else
                        return false;
                }             
            }
           
        }
        public DataTable tracuu(string sdt)
        {
            string query = "select ID as N'Mã Khách',TENKHACH as N'Tên Khách', SDT as N'Số điện thoại',DCHI as N'Địa Chỉ' from KHACHHANG where SDT like '%"+sdt+"%'";
            return Functions.Instance.ExecuteQuery(query);
        }
    }
}
