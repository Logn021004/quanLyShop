using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyShop
{
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
            dtgvKhachHang.SelectionChanged+=dtgvKhachHang_SelectionChanged;
        }
        public void anhienbtn(bool Check)
        {
            if (Check)
            {
                txtDchi.Visible = true;
                txtSDT.Visible = true;
                textName.Visible = true;
                btnAdd.Visible = true;
                btnHuy.Visible = true;
            }
            else
            {
                txtDchi.Visible = false;
                txtSDT.Visible = false;
                textName.Visible = false;
                btnAdd.Visible = false;
                btnHuy.Visible = false;
                btnUpdate.Visible = false;
            }
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            KhachHangBUS.Instance.listKhachHang(dtgvKhachHang);
        }

        private void dtgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
                if (dtgvKhachHang.SelectedCells.Count > 0)
                {
                    DataGridViewRow row= dtgvKhachHang.SelectedCells[0].OwningRow;
                    lblName.Text = row.Cells["Tên Khách"].Value.ToString();
                    lblSdt.Text = row.Cells["Số điện thoại"].Value.ToString();
                    lblDchi.Text = row.Cells["Địa chỉ"].Value.ToString();
                    lblID.Text = row.Cells["Mã khách"].Value.ToString();
                    KhachHangBUS.Instance.listHoaDonOfKhach(listViewHD, row.Cells["Mã Khách"].Value.ToString());
                }
            anhienbtn(false);
        }
      
        private void btnThem_Click(object sender, EventArgs e)
        {
            anhienbtn(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtDchi.Clear();
            txtSDT.Clear();
            textName.Clear();
            if (KhachHangBUS.Instance.them(textName, txtSDT, txtDchi))
            {
                MessageBox.Show("them thanh cong", "thong bao");
            }
            else
            {
                MessageBox.Show("them khong thanh cong", "thong bao");
            }
            KhachHangBUS.Instance.listKhachHang(dtgvKhachHang);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            anhienbtn(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            textName.Text = lblName.Text;
            txtSDT.Text = lblSdt.Text;
            txtDchi.Text = lblDchi.Text;
            btnUpdate.Visible = true;
            anhienbtn(true);
            btnAdd.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (KhachHangBUS.Instance.sua(textName, txtSDT, txtDchi,lblID.Text))
            {
                MessageBox.Show("cap nhap thanh cong", "thong bao");
            }
            else
            {
                MessageBox.Show("cap nhap khong thanh cong", "thong bao");
            }
            KhachHangBUS.Instance.listKhachHang(dtgvKhachHang);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KhachHangBUS.Instance.tracuu(dtgvKhachHang, txtSearch);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            KhachHangBUS.Instance.listKhachHang(dtgvKhachHang);
            txtSearch.Clear();
        }
    }
}
