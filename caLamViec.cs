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
    public partial class CaLamViec : Form
    {
        public CaLamViec()
        {
            InitializeComponent();
        }
        private Button selectedBtn;
        private void CaLamViec_Load(object sender, EventArgs e)
        {
            cboCa();

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
        }

        private void btnXoaPC_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DoimauBtn(btn);
        }

        
        private void cbotenCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhanCongBUS.Instance.timeCa(txtTimeBD, txtTimeKT, cbotenCa.SelectedItem.ToString());
        }
    }
}
