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
    public partial class PhanCongform : Form
    {
        public PhanCongform()
        {
            InitializeComponent();
            dtgvcaLamViec.SelectionChanged += dtgvcaLamViec_SelectionChanged;          
        }


        private Button selectedBtn;
        private void CaLamViec_Load(object sender, EventArgs e)
        {                   
            cboCa();
            cboNv();         
            txtTimeBD.KeyPress += txtTimeBD_KeyPress;
            danhSáchPhânCôngToolStripMenuItem_Click(null, null);
            dtgvcaLamViec.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void cboCa()
        {        
            PhanCongBUS.Instance.cboTenCa(cbotenCa);
        }
        private void cboNv()
        {          
            PhanCongBUS.Instance.cboNV(cboNV);
        }
        private void DoimauBtn(Button btn)
        {
            if (selectedBtn != null)
            {
                selectedBtn.BackColor = SystemColors.GradientActiveCaption;
            }
            btn.BackColor = SystemColors.GradientInactiveCaption;
            selectedBtn = btn;
        }
        
        private void btnThemPC_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DoimauBtn(btn);
            txtMoTa.Clear();
            cboNV.Focus();
            btnCloseAddCa_Click(sender, e);
            PhanCongBUS.Instance.HienbtnPCAdd(btnSaveAddPC, btnCloseAddPC);
        }

        /* update Button xóa ca sau khi hoàn thành các Button liên quan đến phân công */
        private void btnXoaPC_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DoimauBtn(btn);
            PhanCongBUS.Instance.AnbtnAddClose(btnSaveCa, btnCloseAddCa,txtAddCa);
            PhanCongBUS.Instance.AnbtnPCAdd(btnSaveAddPC, btnCloseAddPC);
            if (PhanCongBUS.Instance.xoaPC(cboNV.SelectedItem.ToString(), cbotenCa.SelectedItem.ToString()))
            {
                MessageBox.Show("Xóa thành công!");
                danhSáchPhânCôngToolStripMenuItem_Click(null, null);
            }
            else
                MessageBox.Show("Xóa không thành công!");
        }

        
        private void cbotenCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhanCongBUS.Instance.timeCa(txtTimeBD, txtTimeKT, cbotenCa.SelectedItem.ToString());
        }

        private void btnSaveCa_Click(object sender, EventArgs e)
        {
            if (txtAddCa.Text != "" && txtTimeBD.Text != "" && txtTimeKT.Text != "")
            {
                if (!PhanCongBUS.Instance.IsValidHourFormat(txtTimeBD.Text) || !PhanCongBUS.Instance.IsValidHourFormat(txtTimeKT.Text))
                    MessageBox.Show("Yêu cầu nhập đúng định dạng giờ hh:mm");

                if (PhanCongBUS.Instance.themCa(txtAddCa, txtTimeBD, txtTimeKT))
                {
                    MessageBox.Show("Thêm thành công");
                    cboCa();
                    PhanCongBUS.Instance.AnbtnAddClose(btnSaveCa, btnCloseAddCa, txtAddCa);

                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }     
            else
                MessageBox.Show("Nhập đầy đủ thông tin");        
                      
        }

        private void btnSuaPC_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DoimauBtn(btn);
            PhanCongBUS.Instance.AnbtnAddClose(btnSaveCa, btnCloseAddCa, txtAddCa);
            PhanCongBUS.Instance.AnbtnPCAdd(btnSaveAddPC, btnCloseAddPC);
            if (PhanCongBUS.Instance.suaPC(cboNV.SelectedItem.ToString(), cbotenCa.SelectedItem.ToString(), dateNgayLam, txtMoTa))
            {
                MessageBox.Show("Sửa thành công!");
                danhSáchPhânCôngToolStripMenuItem_Click(null, null);
            }
            else
                MessageBox.Show("S không thành công!");
        }

        private void txtTimeBD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar!='\b'&&!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }

        private void danhSáchPhânCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhanCongBUS.Instance.DSPhanCong(dtgvcaLamViec);
        }

        private void btnThemCa_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DoimauBtn(btn);
            PhanCongBUS.Instance.HienbtnAddClose(btnSaveCa, btnCloseAddCa, txtAddCa);
            PhanCongBUS.Instance.AnbtnPCAdd(btnSaveAddPC, btnCloseAddPC);

            txtTimeBD.Clear();
            txtTimeKT.Clear();
            txtAddCa.Focus();
        }

        private void btnSuaCa_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DoimauBtn(btn);
            PhanCongBUS.Instance.AnbtnAddClose(btnSaveCa, btnCloseAddCa, txtAddCa);
            PhanCongBUS.Instance.AnbtnPCAdd(btnSaveAddPC, btnCloseAddPC);
            if (txtTimeBD.Text != "" || txtTimeKT.Text != "")
            {
                if (!PhanCongBUS.Instance.IsValidHourFormat(txtTimeBD.Text) || !PhanCongBUS.Instance.IsValidHourFormat(txtTimeKT.Text))
                {
                    MessageBox.Show("Yêu cầu nhập đúng định dạng giờ hh:mm");
                }
                else if (PhanCongBUS.Instance.suaCa(cbotenCa.SelectedItem.ToString(), txtTimeBD, txtTimeKT))
                {
                    MessageBox.Show("Sửa thành công");
                    cboCa();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công");
                }
            }
            else
            {
                btnCloseAddCa_Click(sender, e);
                return;                
            }
             
        }

        private void btnCloseAddCa_Click(object sender, EventArgs e)
        {
            PhanCongBUS.Instance.AnbtnAddClose(btnSaveCa, btnCloseAddCa, txtAddCa);
            cboCa();
        }

        private void btnSaveAddPC_Click(object sender, EventArgs e)
        {
           
            if (PhanCongBUS.Instance.themPC(cboNV.SelectedItem.ToString(), cbotenCa.SelectedItem.ToString(), dateNgayLam, txtMoTa))
            {

                MessageBox.Show("Thêm Phân công thành công!");
                danhSáchPhânCôngToolStripMenuItem_Click(null, null);
                PhanCongBUS.Instance.AnbtnPCAdd(btnSaveAddPC, btnCloseAddPC);
            }
            else
                MessageBox.Show("Thêm  Phân công không thành công!");

        }

        private void btnXoaCa_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DoimauBtn(btn);
            PhanCongBUS.Instance.AnbtnAddClose(btnSaveCa, btnCloseAddCa, txtAddCa);
            PhanCongBUS.Instance.AnbtnPCAdd(btnSaveAddPC, btnCloseAddPC);
            DialogResult dlg = MessageBox.Show("Bạn muốn xóa ca làm này?","Cảnh Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dlg == DialogResult.Yes)
            {
                if (PhanCongBUS.Instance.xoaCa(cbotenCa.SelectedItem.ToString()))
                {
                    cboCa();
                    danhSáchPhânCôngToolStripMenuItem_Click(null, null);
                    MessageBox.Show("Xóa thành công!");
                }
                else
                    MessageBox.Show("Xóa không thành công!");
            }
            else
                return;
        }

        private void dtgvcaLamViec_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvcaLamViec.SelectedCells.Count > 0)
                {
                    DataGridViewRow row = dtgvcaLamViec.SelectedCells[0].OwningRow;
                    string temp = row.Cells["Ca Làm"].Value.ToString();
                    if (temp=="")
                    {
                        cbotenCa.SelectedIndex = 0;
                        cboNV.SelectedIndex = 0;
                    }
                    else
                    {
                        cbotenCa.SelectedItem = row.Cells["Ca Làm"].Value.ToString();
                        cboNV.SelectedItem = row.Cells["Tên nhân viên"].Value.ToString();
                        dateNgayLam.Value = (DateTime)row.Cells["Ngày làm việc"].Value;
                    }                 
                    txtMoTa.Text = row.Cells["Mô tả"].Value.ToString();
                    PhanCongBUS.Instance.AnbtnAddClose(btnSaveCa, btnCloseAddCa, txtAddCa);
                    PhanCongBUS.Instance.AnbtnPCAdd(btnSaveAddPC, btnCloseAddPC);
                }
            }
            catch
            {

            }
        }

        private void btnCloseAddPC_Click(object sender, EventArgs e)
        {

        }
    }
}
