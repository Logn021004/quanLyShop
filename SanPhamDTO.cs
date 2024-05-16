using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanLyShop
{
    class SanPhamDTO
    {
        private string masp;
        public string Masp
        {
            get { return masp; }
            set { masp = value; }
        }

        private string tensp;
        public string Tensp
        {
            get { return tensp; }
            set { tensp = value; }
        }
        private float dongia;
        public float Dongia { 
            get { return dongia; }
            set { dongia = value; }
        }
        private int km = 0;
        public int Km
        {
            get { return km; }
            set
            {
                km = value;
            }
        }
        private int sl;
        public int Sl
        {
            get { return sl; }
            set { sl = value; }
        }
        private int tongtien;
        public int Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
    }
}
