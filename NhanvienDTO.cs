using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanLyShop
{
    internal class NhanvienDTO
    {
        private string MaNV;
        public string maNV
        {
            get { return MaNV; }
            set { MaNV = value; }
        }

        private string Ten;
        public string ten
        {
            get { return Ten; }
            set { Ten = value; }
        }

        private int CMND;
        public int cmnd
        {
            get { return CMND; }
            set { CMND = value; }
        }

        private int SDT;
        public int  sdt
        {
            get { return SDT; }
            set { SDT = value; }
        }

        private string DChi;
        public string dchi
        {
            get { return DChi; }
            set { DChi = value; }
        }

        private DateTime NgaySinh;
        public DateTime ngaysinh
        {
            get { return NgaySinh; }
            set { NgaySinh = value; }
        }

        private float Luong;
        public float luong
        {
            get { return Luong; }
            set { Luong = value; }
        }

        private DateTime Ngaybdlam;
        public DateTime ngaybdlam
        {
            get { return Ngaybdlam; }
            set { Ngaybdlam = value; }
        }

        private DateTime Ngaybdnghi;
        public DateTime ngaybdnghi
        {
            get { return Ngaybdnghi; }
            set { Ngaybdnghi = value; }
        }


        private string Trangthai;
        public string trangthai
        {
            get { return Trangthai; }
            set { Trangthai = value; }
        }


        private string Gioitinh;
        public string gioitinh
        {
            get { return Gioitinh; }
            set { Gioitinh = value; }
        }

    }
}
