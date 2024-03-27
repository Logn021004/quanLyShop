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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
            dtgvNhanVien.SelectionChanged += dtgvNhanVien_SelectionChanged;

        }
       
        private void NhanVien_Load(object sender, EventArgs e)
        {
            NhanvienBUS.Instance.Xem(dtgvNhanVien);
            cboGIOITINH.Items.Add("Nam");
            cboGIOITINH.Items.Add("Nữ");
            cboTrangThai.Items.Add("Nhân viên");
            cboTrangThai.Items.Add("Đã nghỉ");
            cboGIOITINH.SelectedItem = cboGIOITINH.Items[0];
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            dtgvNhanVien.EditingControlShowing += dtgvNhanVien_EditingControlShowing;
            dtgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void dtgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvNhanVien.SelectedCells.Count > 0)
                {
                    DataGridViewRow row = dtgvNhanVien.SelectedCells[0].OwningRow;
                    txtMaNV.Text = row.Cells["Mã nhân viên"].Value.ToString();
                    txtName.Text = row.Cells["Tên nhân viên"].Value.ToString();
                    txtCMND.Text = row.Cells["CMND"].Value.ToString();
                    txtSDT.Text = row.Cells["Số điện thoại"].Value.ToString();
                    txtDCHI.Text = row.Cells["Địa chỉ"].Value.ToString();
                    txtLUONG.Text = row.Cells["Lương"].Value.ToString();
                    dateNgaySinh.Value = (DateTime)row.Cells["Ngày sinh"].Value;
                    dateBDLAM.Value = (DateTime)row.Cells["Ngày bắt đầu làm"].Value;
                    dateBDNGHI.Value = new DateTime(1900, 1, 1, 0, 0, 0);

                    if (row.Cells["Giới tính"].Value.ToString() == "Nữ")
                        cboGIOITINH.SelectedItem = "Nữ";
                    else
                        cboGIOITINH.SelectedItem = "Nam";
                    if (row.Cells["Trạng Thái"].Value.ToString() == "Nhân viên")
                        cboTrangThai.SelectedItem = "Nhân viên";
                    else
                        cboTrangThai.SelectedItem = "Đã nghỉ";

                    try
                    {
                        dateBDNGHI.Value = (DateTime)row.Cells["Ngày bắt đầu nghỉ"].Value;
                    }
                    catch { }
                    AnHienbtnSaveAndClose();

                }
            }
            catch
            {

            }
        }

        public void AnHienbtnSaveAndClose()
        {
            if (btnLuu.Visible == true && btnHuy.Visible == true)
            {
                btnLuu.Visible = false;
                btnHuy.Visible = false;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            NhanvienBUS.Instance.TimKiem(dtgvNhanVien, txtTimKiem);
            AnHienbtnSaveAndClose();
            
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanvienBUS.Instance.Xem(dtgvNhanVien);
            AnHienbtnSaveAndClose();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            if (NhanvienBUS.Instance.Xoa(dtgvNhanVien, txtMaNV, date))
            {
                MessageBox.Show("xóa thành công");
                danhSáchNhânViênToolStripMenuItem_Click(sender, e);
            }
            else
                MessageBox.Show("xóa không thành công");
            AnHienbtnSaveAndClose();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (NhanvienBUS.Instance.Sua(txtMaNV,txtName,txtCMND,txtSDT,txtDCHI,txtLUONG,cboGIOITINH,cboTrangThai,dateNgaySinh,dateBDLAM,dateBDNGHI))
            {
                MessageBox.Show("Sửa thành công");
                danhSáchNhânViênToolStripMenuItem_Click(sender, e);
            }
            else
                MessageBox.Show("Sửa không thành công");
            AnHienbtnSaveAndClose();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (NhanvienBUS.Instance.themNVDaNghi(txtMaNV))
            {
                MessageBox.Show("Thêm nhân viên trở lại");
                AnHienbtnSaveAndClose();
                danhSáchNhânViênToolStripMenuItem_Click(sender, e);
            }
            else
            {
                txtMaNV.Clear();
                txtName.Clear();
                txtCMND.Clear();
                txtSDT.Clear();
                txtDCHI.Clear();
                txtLUONG.Clear();
                dateBDLAM.Value = DateTime.Now;
                dateBDNGHI.Value = new DateTime(1900, 1, 1, 0, 0, 0);
                cboTrangThai.SelectedItem = "Nhân viên";
                btnLuu.Visible = true;
                btnHuy.Visible = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtCMND.Text == "" || txtSDT.Text == "" || txtName.Text=="")
            {
                MessageBox.Show("Nhập đầy đủ thông tin mục đỏ.");

                _ = txtName.Text == "" ? txtName.Focus() : txtCMND.Text == "" ? txtCMND.Focus() : txtSDT.Focus();
            }
            else
            {
                if (NhanvienBUS.Instance.Them(txtMaNV, txtName, txtCMND, txtSDT, txtDCHI, txtLUONG, cboGIOITINH, cboTrangThai, dateNgaySinh, dateBDLAM, dateBDNGHI))
                {
                    MessageBox.Show("Thêm thành công");
                    if (btnLuu.Visible == true && btnHuy.Visible == true)
                    {
                        btnLuu.Visible = false;
                        btnHuy.Visible = false;
                    }
                    danhSáchNhânViênToolStripMenuItem_Click(sender, e);

                }
                else
                    MessageBox.Show("Nhân viên đã tồn tại hoặc lỗi hệ thống", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void xemDanhSáchNhânViênĐãNghỉToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanvienBUS.Instance.XemDSDaNghi(dtgvNhanVien);
            AnHienbtnSaveAndClose();
        }

        private void dtgvNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void dtgvNhanVien_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            TextBox textbox = e.Control as TextBox;
            if(textbox != null)
            {
                textbox.KeyPress += new KeyPressEventHandler(dtgvNhanVien_KeyPress);
            }
        }
    }
}

