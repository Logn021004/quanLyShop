using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanLyShop
{
    class hoadonDAO
    {
        private static hoadonDAO instance;
        public static hoadonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new hoadonDAO();
                return instance;
            }
        }
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";
       
        private static string MAHD;
        public static string maHD
        {
            get
            {
                return MAHD;
            }
        }
        public SanPhamDTO thongtinSP(string masp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select TENSP,DONGIABAN,MASP,SOLUONGTONKHO from SANPHAM where SANPHAM.MASP=N'" + masp+"'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                SanPhamDTO infosp = new SanPhamDTO() { Tensp = sdr[0].ToString()};
                infosp.Masp = sdr[2].ToString();
                infosp.Sl = int.Parse(sdr[3].ToString());
                float dongia = float.Parse(sdr[1].ToString());
                sdr.Close();             
                query = "select TIENGIAM,NGAYAPDUNG,NGAYKT from SANPHAM,KHUYENMAI where SANPHAM.MASP=KHUYENMAI.MASP and SANPHAM.MASP='" + masp + "'";
                cmd = new SqlCommand(query, conn);
                if (Functions.Instance.ExecuteQuery(query).Rows.Count > 0)
                {
                    sdr = cmd.ExecuteReader();
                    DateTime date = DateTime.Now.Date;
                    while (sdr.Read())
                    {
                        DateTime dateBD = Convert.ToDateTime(sdr[1]);
                        DateTime dateKT = Convert.ToDateTime(sdr[2]);
                        if (dateBD <= date && dateKT >= date)
                        {
                            infosp.Km = int.Parse(sdr[0].ToString());
                            infosp.Dongia = (dongia - ((infosp.Km * dongia) / 100));
                            break;
                        }
                        else
                            infosp.Dongia = dongia;
                    }
                }
                else 
                    infosp.Dongia = dongia;
                conn.Close();
                return infosp;
            }
        }
        public bool checkSlOfHdon(string tensp,int sl)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select SOLUONGTONKHO from SANPHAM where TENSP=@TENSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TENSP", tensp);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if(sl> int.Parse(sdr[0].ToString()))
                {
                    int.Parse(sdr[0].ToString()); 
                    return false;
                }
                sdr.Close();
                conn.Close();
                return true;
            }
        }
        public string nameKhach(string sdt)
        {
            string name = "Không tồn tại";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select TENKHACH from KHACHHANG where SDT= @sdt ";
                object[] para = new object[] { sdt };
                if (Functions.Instance.ExecuteQuery(query, para).Rows.Count > 0)
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    name = sdr[0].ToString();
                    sdr.Close();
                }            
                conn.Close();
            }
            return name;
        }

        public bool ThanhToan(List<SanPhamDTO> listSP,string manv,string sdtKH,int giamgia,float tientra,float tienthua,float tongtien)
        {
           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                manv = LoginDAO.Manv;
                string makh = getMAKH(sdtKH);
                string query = "EXEC InsertHoaDon @MANV = "+manv+", @MAKH = "+makh+", @DATE = '"+DateTime.Now.ToString()+"', @GIAMGIA = "+giamgia+", @TIENTRA = "+tientra+", @TIENTHUA = "+tienthua+", @TONGTIEN = "+tongtien+";";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                MAHD = sdr[0].ToString();
                sdr.Close();
                for(int i = 0; i < listSP.Count; i++)
                {
                    string masp = getMASP(listSP[i].Tensp);
                    query = "EXEC InsertCTHDAndUpdateSanPham \r\n    @MAHD = "+MAHD+",\r\n    @MASP = '"+masp+"',\r\n    @SOLUONG = " + listSP[i].Sl + ",\r\n    @DONGIA = "+ listSP[i].Dongia + ",\r\n    @TONGTIEN = "+ listSP[i].Tongtien + ";";
                    if (!(Functions.Instance.ExecuteNonQuery(query) > 0))
                    {
                        return false;
                    }
                }
                conn.Close();
            }
            return true;
        }
        public string getMAKH(string sdt)
        {
            string makh = "1";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select ID from KHACHHANG where SDT= @sdt \r\n";
                object[] para = new object[] { sdt };
                if (Functions.Instance.ExecuteQuery(query, para).Rows.Count > 0)
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    makh = sdr[0].ToString();
                    sdr.Close();
                }
                conn.Close();

            }
            return makh;
        }       
        public string getMASP(string nameSP)
        {
            string masp;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select MASP from SANPHAM where TENSP=@TENSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TENSP", nameSP);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                masp = sdr[0].ToString();
                conn.Close();             
            }
            return masp;
        }
        public object[] getBill(string mahd)
        {
            object[] infoBill = new object[8];
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "exec getBill "+mahd+"";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                infoBill[0] = sdr[0].ToString() ;
                infoBill[1] = sdr[1].ToString();
                infoBill[2] = sdr[2].ToString();
                infoBill[3] = sdr[3].ToString();
                infoBill[4] = sdr[4].ToString();
                infoBill[5] = sdr[5].ToString();
                infoBill[6] = sdr[6].ToString();
                infoBill[7] = sdr[7].ToString();
                conn.Close();
            }
            return infoBill;
        }
    }
}
