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
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }
        
        private void btnADD_Click(object sender, EventArgs e)
        {
            if (txtPWD.Text == txtPWD2.Text)
            {
                if(userBUS.Instance.add(txtNAME,txtPWD,txtMANV,cboQuyen.SelectedItem.ToString()))
                {
                    MessageBox.Show("Tạo tài khoản thành công!");
                }
                else
                    MessageBox.Show("Tạo tài khoản không thành công!");
            }
        }
    }
}
