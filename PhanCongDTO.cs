using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanLyShop
{
    class PhanCongDTO
    {
        
        private int maCa;
        public int MaCa
        {
            get { return maCa; }
            set { maCa = value; }
        }
        private int maNV;
        public int MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        private DateTime ngayLamViec;
        public DateTime Ngaylamviec
        {
            get { return ngayLamViec; }
            set { ngayLamViec = value; }
        }
        private string moTa;
        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }




    }
}
