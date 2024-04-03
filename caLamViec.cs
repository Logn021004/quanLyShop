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
    public partial class PhanCong : Form
    {
        public PhanCong()
        {
            InitializeComponent();
        }
        private Button selectedBtn;
        private void CaLamViec_Load(object sender, EventArgs e)
        {
            cboCa();
            txtTimeBD.KeyPress += txtTimeBD_KeyPress;

        }
        private void cboCa()
        {

            PhanCongBUS.Instance.cboTenCa(cbotenCa);
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
            PhanCongBUS.Instance.HienbtnAddClose(btnSaveCa, btnCloseAddCa,txtAddCa);
            txtTimeBD.Clear();
            txtTimeKT.Clear();
            txtAddCa.Focus();
        }

        private void btnXoaPC_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DoimauBtn(btn);
            PhanCongBUS.Instance.AnbtnAddClose(btnSaveCa, btnCloseAddCa,txtAddCa);
            
        }

        
        private void cbotenCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhanCongBUS.Instance.timeCa(txtTimeBD, txtTimeKT, cbotenCa.SelectedItem.ToString());
        }

        private void btnSaveCa_Click(object sender, EventArgs e)
        {
            
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

        private void btnSuaPC_Click(object sender, EventArgs e)
        {
            PhanCongBUS.Instance.AnbtnAddClose(btnSaveCa, btnCloseAddCa, txtAddCa);
            if (!PhanCongBUS.Instance.IsValidHourFormat(txtTimeBD.Text) || !PhanCongBUS.Instance.IsValidHourFormat(txtTimeKT.Text))
            {
                MessageBox.Show("Yêu cầu hập đúng định dạng giờ hh:mm");
            }
             else  if (PhanCongBUS.Instance.suaCa(cbotenCa.SelectedItem.ToString(), txtTimeBD, txtTimeKT))
            {
                MessageBox.Show("Sửa thành công");
                cboCa();
            }
            else
            {
                MessageBox.Show("Sửa không thành công");
            }
        }

        private void txtTimeBD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar!='\b'&&!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }
    }
}
