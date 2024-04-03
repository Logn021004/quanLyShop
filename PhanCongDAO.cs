using System;
using System.Collections;
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
     class PhanCongDAO
    {
        private static PhanCongDAO instance;
        public static PhanCongDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new PhanCongDAO();
                }
                return instance;
            }
            //set { instance = value; }
        }

        private PhanCongDAO()
        {

        }
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";

        public ComboBox cboTenCa()
        {
            ComboBox cboTenCa=new ComboBox();
            using (SqlConnection connection = new SqlConnection(connectionString))//de phong truong hop ngắt kết nối bất chợp đảm bảo data
            {
                connection.Open();
                string query = "select TENCA from CALAM\r\norder by THOIGIANKETTHUC asc";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    cboTenCa.Items.Add(sdr[0]);
                }  
                connection.Close();
            }
            return cboTenCa;
        }
        public string[] timeCa(string tenca)
        {
            string[] time =new string[2];
            using (SqlConnection connection = new SqlConnection(connectionString))//de phong truong hop ngắt kết nối bất chợp đảm bảo data
            {
                connection.Open();
                string query = "select THOIGIANBDLAM,THOIGIANKETTHUC from CALAM where TENCA= @TENCA ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TENCA", tenca);
                SqlDataReader sdr = command.ExecuteReader();
                while(sdr.Read())
                {
                    time[0] = sdr[0].ToString();
                    time[1] = sdr[1].ToString();
                }
                connection.Close();
            }
            return time;

        }
        public bool ThemCa(string txtAddCa,string timeBD,string timeKT)
        {
            string query = "insert into CALAM values( @TENCA , @TIMEBD , @TIMEKT )";
            object[] para = new object[] { txtAddCa, timeBD, timeKT };
            if (checkCaTonTai(txtAddCa))
                return false;
            if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                return true;
            return false;
        }
        public bool SuaCa(string txtAddCa, string timeBD, string timeKT)
        {
            string query = "update CALAM set THOIGIANBDLAM= @timeBD ,THOIGIANKETTHUC= @timeKT where TENCA= @TENCA ";
            object[] para = new object[] { timeBD, timeKT,txtAddCa };
            if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                return true;
            return false;
        }
        public bool checkCaTonTai(string tenca)
        {
            string query = "select TENCA from CALAM where TENCA= @TENCA ";
            object[] para = new object[] { tenca };
            if (Functions.Instance.ExecuteQuery(query, para).Rows.Count > 0)
                return true;
            return false;
        }

    }





 }
