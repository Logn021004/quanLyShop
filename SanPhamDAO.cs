﻿using System;
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
    }
}
