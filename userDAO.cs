using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace quanLyShop
{
     class userDAO
    {
        private static userDAO instance;
        public static userDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new userDAO();
                return instance;
            }
        }
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";

        public bool checkUsername(string username)
        {
            using (SqlConnection conn=new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from ACCOUNT where USERNAME= @USERNAME ";
                object[] para = new object[] { username };
                if (Functions.Instance.ExecuteQuery(query, para).Rows.Count > 0)
                {
                    return true;
                }
                else 
                    return false;
            }
        }
        public bool add(string username,string pwd,string manv,string quyen)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "insert into ACCOUNT values( @username , @pwd , @manv , @quyen )";
                pwd = LoginDAO.Instance.Hash(pwd);
                object[] para = new object[] { username,pwd,manv,quyen };
                if (Functions.Instance.ExecuteNonQuery(query, para)>0)
                {
                    return true;
                }
                conn.Close(); 
            }
            return false;
        }
    }
}
