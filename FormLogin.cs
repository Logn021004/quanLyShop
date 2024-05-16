using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace quanLyShop
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }
        private void Showform()
        {
            TrangChu newForm = new TrangChu();
            newForm.ShowDialog();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginBUS.Instance.checkLogin(txtUserName,txtPWD)) {
                Thread thread = new Thread(new ThreadStart(Showform));
                thread.Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thông tin sai!");
            }
        }
    }
}
