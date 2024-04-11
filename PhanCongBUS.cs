using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyShop
{
    class PhanCongBUS
    {
        private static PhanCongBUS instance;
        public static PhanCongBUS Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new PhanCongBUS();
                }
                return instance;
            }
            //set { instance = value; }
        }
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";
        private PhanCongBUS()
        {

        }
        public void AnbtnAddClose(Button btnSaveCa,Button btnCloseAddCa,TextBox txtAddCa)
        {
            if (btnSaveCa.Visible == true && btnCloseAddCa.Visible == true&& txtAddCa.Visible==true)
            {
                txtAddCa.Visible = false;
                btnSaveCa.Visible = false;
                btnCloseAddCa.Visible = false;
            }
        }
        public void AnbtnPCAdd(Button btnLuu, Button btnHuy)
        {
            if (btnLuu.Visible == true && btnHuy.Visible == true)
            {
               
                btnLuu.Visible = false;
                btnHuy.Visible = false;
            }
        }
        public void HienbtnPCAdd(Button btnLuu, Button btnHuy)
        {
            if (btnLuu.Visible == false && btnHuy.Visible == false)
            {

                btnLuu.Visible = true;
                btnHuy.Visible = true;
            }
        }
        public void HienbtnAddClose(Button btnSaveCa, Button btnCloseAddCa,TextBox txtAddCa)
        {
            if (btnSaveCa.Visible == false && btnCloseAddCa.Visible == false && txtAddCa.Visible==false)
            {
                txtAddCa.Visible = true;
                btnSaveCa.Visible = true;
                btnCloseAddCa.Visible = true;
            }
        }
        public void cboTenCa(ComboBox cbotenCa)
        {
            cbotenCa.Items.Clear();
            
            cbotenCa.Items.Add("Chọn Ca");
            foreach (var item in PhanCongDAO.Instance.cboTenCa().Items)
            {
                cbotenCa.Items.Add(item);
            }         
            cbotenCa.SelectedIndex = 0;  
        }
        public void cboNV(ComboBox cboNV)
        {
            cboNV.Items.Clear();
            cboNV.Items.Add("Chọn Nhân Viên");
            foreach (var item in PhanCongDAO.Instance.cboNV().Items)
            {
                cboNV.Items.Add(item);
            }
            cboNV.SelectedIndex = 0;
        }

        public void timeCa(TextBox timeBD,TextBox timeKT,string tenca)
        {
            string[] time = PhanCongDAO.Instance.timeCa(tenca);
            timeBD.Text = time[0];
            timeKT.Text = time[1];
        }
        public bool themCa(TextBox txtAddCa,TextBox timeBD,TextBox timeKT)
        {
            return PhanCongDAO.Instance.ThemCa(txtAddCa.Text,timeBD.Text,timeKT.Text);
        }
        public bool suaCa(string nameCa,TextBox timeBD,TextBox timeKT)
        {   
            return PhanCongDAO.Instance.SuaCa(nameCa, timeBD.Text, timeKT.Text);
        }
        public bool xoaCa(string tenca)
        {
            int maca=0;
            using (SqlConnection connection = new SqlConnection(connectionString))//de phong truong hop ngắt kết nối bất chợp đảm bảo data
            {
                connection.Open();

                string queryMaCA = "select MACA from CALAM where TENCA= @TENCA";
                SqlCommand command = new SqlCommand(queryMaCA, connection);
                command.Parameters.AddWithValue("@TENCA", tenca);
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    maca = sdr.GetInt32(0);
                }              
                connection.Close();
            }
            return PhanCongDAO.Instance.xoaCa(maca);
        }
        public bool IsValidHourFormat(string time)
        {
            
            string[] temp = time.Split(':');
            int hour=0,minute=0;
            if (time[time.Length - 3] != ':')
                return false;
            if(temp.Length != 2){
                return false;
            }
            if (!int.TryParse(temp[0],out hour) && !int.TryParse(temp[1],out minute))
            {
                return false;
            }
            if (hour < 0 || hour > 24 || minute < 0 || minute > 60)
            {
                return false;
            }
            return true;
        }
        public void DSPhanCong(DataGridView dt)
        {
            dt.DataSource = PhanCongDAO.Instance.DSPhanCong();
        }
        public void DSCa(DataGridView dt)
        {
            dt.DataSource = PhanCongDAO.Instance.DSCa();
        }
        public bool themPC(string nameNV,string tenca,DateTimePicker ngaylam,RichTextBox moTa)
        {
            int MaCA=0, MaNV=0;
            using (SqlConnection connection = new SqlConnection(connectionString))//de phong truong hop ngắt kết nối bất chợp đảm bảo data
            {
                connection.Open();
                            
                string queryMaCA = "select MACA from CALAM where TENCA= @TENCA";
                SqlCommand command = new SqlCommand(queryMaCA, connection);
                command.Parameters.AddWithValue("@TENCA", tenca);
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    MaCA = sdr.GetInt32(0);
                }
                sdr.Close();
                string queryMaNV = "select MANV from NHANVIEN where TENNV= @TENNV";
                command =new SqlCommand(queryMaNV, connection);
                command.Parameters.AddWithValue("@TENNV", nameNV);
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    MaNV = sdr.GetInt32(0);
                }
                connection.Close();
            }
            DateTime ngaylamviec = (DateTime)ngaylam.Value;
            string mota = moTa.Text;
            PhanCongDTO user = new PhanCongDTO { MaCa = MaCA, MaNV = MaNV, MoTa = mota, Ngaylamviec = ngaylamviec };
            return PhanCongDAO.Instance.ThemPC(user, tenca);
        }
        public bool suaPC(string nameNV, string tenca, DateTimePicker ngaylam, RichTextBox moTa)
        {
            int MaCA = 0, MaNV = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))//de phong truong hop ngắt kết nối bất chợp đảm bảo data
            {
                connection.Open();

                string queryMaCA = "select MACA from CALAM where TENCA= @TENCA";
                SqlCommand command = new SqlCommand(queryMaCA, connection);
                command.Parameters.AddWithValue("@TENCA", tenca);
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    MaCA = sdr.GetInt32(0);
                }
                sdr.Close();
                string queryMaNV = "select MANV from NHANVIEN where TENNV= @TENNV";
                command = new SqlCommand(queryMaNV, connection);
                command.Parameters.AddWithValue("@TENNV", nameNV);
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    MaNV = sdr.GetInt32(0);
                }
                connection.Close();
            }
            DateTime ngaylamviec = (DateTime)ngaylam.Value;
            string mota = moTa.Text;
            PhanCongDTO user = new PhanCongDTO { MaCa = MaCA, MaNV = MaNV, MoTa = mota, Ngaylamviec = ngaylamviec };
            return PhanCongDAO.Instance.SuaPC(user);
        }
        public bool xoaPC(string nameNV,string tenca)
        {
            int MaCA = 0, MaNV = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))//de phong truong hop ngắt kết nối bất chợp đảm bảo data
            {
                connection.Open();

                string queryMaCA = "select MACA from CALAM where TENCA= @TENCA";
                SqlCommand command = new SqlCommand(queryMaCA, connection);
                command.Parameters.AddWithValue("@TENCA", tenca);
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    MaCA = sdr.GetInt32(0);
                }
                sdr.Close();
                string queryMaNV = "select MANV from NHANVIEN where TENNV= @TENNV";
                command = new SqlCommand(queryMaNV, connection);
                command.Parameters.AddWithValue("@TENNV", nameNV);
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    MaNV = sdr.GetInt32(0);
                }
                connection.Close();
            }       
            return PhanCongDAO.Instance.XoaPC(MaCA, MaNV);
        }
    }
}
