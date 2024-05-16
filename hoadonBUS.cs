using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyShop
{
    class hoadonBUS
    {
        private static hoadonBUS instance;
        public static hoadonBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new hoadonBUS();
                return instance;
            }
        }
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";

        public SanPhamDTO thongtinSP(string masp)
        {
            return hoadonDAO.Instance.thongtinSP(masp);
        }
        public bool checkSlOfHdon(string tensp, int sl)
        {
            return hoadonDAO.Instance.checkSlOfHdon(tensp, sl);
        }
        public string nameKhach(string sdt)
        {
            return hoadonDAO.Instance.nameKhach(sdt.TrimStart('0'));
        }
        public bool ThanhToan(DataGridView dtgvHD, TextBox SdtKH, TextBox Giamgia, TextBox Tientra, TextBox Tienthua, Label Tongtien)
        {
            List<SanPhamDTO> listData = new List<SanPhamDTO>();
            foreach (DataGridViewRow row in dtgvHD.Rows)
            {
                if (!row.IsNewRow)
                {
                    SanPhamDTO sp = new SanPhamDTO();
                    sp.Tensp = row.Cells[0].Value.ToString();
                    sp.Tongtien = int.Parse(row.Cells[4].Value.ToString());
                    sp.Sl = int.Parse(row.Cells[3].Value.ToString());
                    sp.Dongia = int.Parse(row.Cells[1].Value.ToString());
                    listData.Add(sp);
                }
            }
            string manv="";
            string sdtKH = SdtKH.Text;
            int giamgia = int.Parse(Giamgia.Text);
            float tientra = float.Parse(Tientra.Text);
            float tienthua = float.Parse(Tienthua.Text);
            tienthua = Math.Abs(tienthua);
            float tongtien = float.Parse(Tongtien.Text.Replace(",","").Replace(" ₫", "").Trim());
            return hoadonDAO.Instance.ThanhToan(listData, manv, sdtKH, giamgia, tientra, tienthua, tongtien);
        }
        public object[] getBill(string mahd)
        {
            return hoadonDAO.Instance.getBill(mahd);
        }
    
    }
}

