using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace quanLyShop
{
    class LoginDAO
    {
        private static LoginDAO instance;
        public static LoginDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoginDAO();
                return instance;
            }
        }
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";
        private static string manv="";
        public static string Manv
        {
            get { return manv; }
        }
        public static string quyen="";
        public static string Quyen
        {
            get { return quyen; }
        }
        public string Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {              
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public bool VerifyHash(string input, string hash)
        {
            string hashOfInput = Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }
        public bool checkLogin(string username, string password)
        {
            using (SqlConnection conn=new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select PWD,MANV,QUYEN from ACCOUNT where USERNAME= @USERNAME ";
                object[] para = new object[] { username };
                if (Functions.Instance.ExecuteQuery(query, para).Rows.Count > 0)
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@USERNAME", username);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                   string pas= sdr[0].ToString();
                    if (VerifyHash(password, sdr[0].ToString()))
                    {
                        manv = sdr[1].ToString();
                        quyen = sdr[2].ToString();
                        return true;
                    }
                }
                conn.Close();
            }
            return false;
        }
    }
}
