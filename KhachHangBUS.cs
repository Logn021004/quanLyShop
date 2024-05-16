using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyShop
{
    class KhachHangBUS
    {
        private static KhachHangBUS instance;
        public static KhachHangBUS Instance
        {
            get
            {
                if(instance==null)
                    instance = new KhachHangBUS();
                return instance;
            }
        }
        public void listKhachHang(DataGridView dtgv)
        {
            dtgv.DataSource = KhachHangDAO.Instance.listKhachHang();
        }
        public void tracuu(DataGridView dtgv,TextBox sdt)
        {

            dtgv.DataSource = KhachHangDAO.Instance.tracuu(sdt.Text.TrimStart('0'));
        }
        public void listHoaDonOfKhach(ListView list,string idKhach)
        {
            list.Items.Clear();
            ListView dsTemp=KhachHangDAO.Instance.listHoaDonOfKhach(idKhach);
            foreach(ListViewItem item in dsTemp.Items)
            {
                ListViewItem newItem = new ListViewItem(item.Text);
                foreach(ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    if(subitem.Text!=item.Text)
                    newItem.SubItems.Add(subitem.Text);
                }
                list.Items.Add(newItem);
            }
        }
        public bool them(TextBox name,TextBox sdt,TextBox dchi)
        {
            string Name = name.Text;
            int Sdt = int.Parse(sdt.Text);
            string Dchi = dchi.Text;
            return KhachHangDAO.Instance.them(Name, Sdt, Dchi);
        }
        public bool sua(TextBox name, TextBox sdt, TextBox dchi,string id)
        {
            string Name = name.Text;
            int Sdt = int.Parse(sdt.Text);
            string Dchi = dchi.Text;
            return KhachHangDAO.Instance.sua(Name, Sdt, Dchi,id);
        }
    }
}
