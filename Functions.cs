using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace quanLyShop
{
    public class Functions
    {

        //mẫu Singleton
        private static Functions instance;
        public static Functions Instance
        {
            
            get {
                if (instance == null)
                {
                    instance = new Functions();
                }
                return instance; }
            //set { instance = value; }
        }
        private Functions()
        {

        }

            
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";
 
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))//de phong truong hop ngắt kết nối bất chợp đảm bảo data
            {
                connection.Open();
                //SqlCommand insert,update,delete; tra ve 1 record;
                //SqlDataAdapter select; tra ve table
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] temp = query.Split(' ');// tach chuoi ra tung chu
                    List<string> list = new List<string>();// list de luu danh sach @....
                    foreach (string item in temp)
                    {
                        if ( item !=string.Empty && item[0] == '@')//item[0] ki tu dau tien cua moi item
                        {
                            list.Add(item);                     
                        }      
                    }

                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.AddWithValue(list[i], parameter[i]);// them lan luoc cac thuoc tinh
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Data table; 1 bảng table
                //Data set; 1 data set chứa nhiều data table
                //đổ data vào bảng fill
                
                adapter.Fill(data);
                //show data;
                //dtgvData.dataSource= table;
                connection.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int accpectedRows = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))//de phong truong hop ngắt kết nối bất chợp đảm bảo data
            {
                connection.Open();


                //SqlCommand insert,update,delete; tra ve 1 record;
                //SqlDataAdapter select; tra ve table

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] temp = query.Split(' ');// tach chuoi ra tung chu
                    List<string> list = new List<string>();// list de luu danh sach @....
                    foreach (string item in temp)
                    {
                        if (item != string.Empty && item[0] == '@')//item[0] ki tu dau tien cua moi item
                        {
                            list.Add(item);
                        }
                    }
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.AddWithValue(list[i], parameter[i]);// them lan luoc cac thuoc tinh
                    }
                }
                //thực hiện câu query-> trả về số dòng mà câu truy vấn thực hiện được;
                accpectedRows =  command.ExecuteNonQuery();

                //Data table; 1 bảng table
                //Data set; 1 data set chứa nhiều data table
                //đổ data vào bảng fill

                
                //show data;
                connection.Close();
            }
            return accpectedRows;
        }



    }
}
