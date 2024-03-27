using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Xml.Linq;


namespace quanLyShop
{
     class NhanvienBUS
    {
        private static NhanvienBUS instance;
        public static NhanvienBUS Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new NhanvienBUS();
                }
                return instance;
            }
            //set { instance = value; }
        }

        private NhanvienBUS()
        {

        }

        public void Xem(DataGridView data)
        {
            data.DataSource = NhanvienDAO.Instance.Xem();
        }
        public void XemDSDaNghi(DataGridView data)
        {
            data.DataSource = NhanvienDAO.Instance.XemDSDaNghi();
        }
        public void TimKiem(DataGridView data,TextBox Ten)
        {         
            data.DataSource = NhanvienDAO.Instance.Timkiem(Ten);         
        }
        public bool Xoa(DataGridView data,TextBox id,DateTime date)
        {
            return NhanvienDAO.Instance.Xoa(id, date);                    
        }

        public bool Sua(TextBox manv, TextBox name, TextBox cmnd, TextBox sdt, TextBox dchi, TextBox luong,ComboBox gioitinh,ComboBox trangthai,DateTimePicker ngaysinh, DateTimePicker ngaybdlam,DateTimePicker ngaybdnghi)
        {

            string MaNV = manv.Text;
            string Name = name.Text;
            int CMND = int.Parse(cmnd.Text);
            int SDT =int.Parse( sdt.Text);
            string DCHI = dchi.Text;
            float LUONG = float.Parse( luong.Text);
            string Gioitinh = gioitinh.SelectedItem.ToString();
            DateTime dateNgaySinh =(DateTime)ngaysinh.Value;
            DateTime dateBDLAM = (DateTime)ngaybdlam.Value;
            NhanvienDTO user = new NhanvienDTO() { maNV = MaNV ,cmnd= CMND,dchi=DCHI,gioitinh=Gioitinh,luong=LUONG,ten=Name,sdt=SDT,ngaysinh=dateNgaySinh,ngaybdlam=dateBDLAM};
            return NhanvienDAO.Instance.Sua(user); 
        }

        public bool Them(TextBox manv, TextBox name, TextBox cmnd, TextBox sdt, TextBox dchi, TextBox luong, ComboBox gioitinh, ComboBox trangthai, DateTimePicker ngaysinh, DateTimePicker ngaybdlam, DateTimePicker ngaybdnghi)
        {
            string MaNV = manv.Text;
            string Name = name.Text;
            int CMND = int.Parse(cmnd.Text);
            int SDT = int.Parse(sdt.Text);
            string DCHI = dchi.Text;
            float LUONG = float.Parse(luong.Text);
            string Gioitinh = gioitinh.SelectedItem.ToString();
            string Trangthai = trangthai.SelectedItem.ToString();
            DateTime dateNgaySinh = (DateTime)ngaysinh.Value;
            DateTime dateBDLAM = (DateTime)ngaybdlam.Value;
            NhanvienDTO user = new NhanvienDTO() { maNV = MaNV, cmnd = CMND, dchi = DCHI, gioitinh = Gioitinh, luong = LUONG, ten = Name, sdt = SDT, ngaysinh = dateNgaySinh, ngaybdlam = dateBDLAM, };
            return NhanvienDAO.Instance.Them(user);
        }

        public bool themNVDaNghi(TextBox maNV)
        {
            string MaNV = maNV.Text;       
            NhanvienDTO user = new NhanvienDTO() {maNV=MaNV };
            return NhanvienDAO.Instance.ThemNVDaNghi(user);
        }
    }
}
