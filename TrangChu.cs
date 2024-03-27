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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            this.Resize += TrangChu_Resize;
        }
        private Form currentFormChild;
        private Button selectedBtn;
        private void TrangChu_Resize(object sender, EventArgs e)
        {
            MessageBox.Show("Không thể điều chỉnh kích thước!","Thông Cảm");

        }


        private void openFormChild(Form child)
        {
            if (currentFormChild != null)
                currentFormChild.Close();
            currentFormChild = child;
            child.TopLevel = false;
            child.FormBorderStyle=FormBorderStyle.None;
            child.Dock= DockStyle.Fill;
            pnl_body.Controls.Add(child);
            pnl_body.Tag = child;
            child.BringToFront();
            child.Show();
        }
        public void DoimauBtn(Button btn)
        {
            if (selectedBtn != null)
            {
                selectedBtn.BackColor = SystemColors.ScrollBar;
            }
            btn.BackColor = SystemColors.ActiveCaption;
            selectedBtn = btn;
        }



        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(currentFormChild!= null)
                currentFormChild.Close();
            DoimauBtn(btn);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            openFormChild(new SanPham());
            DoimauBtn(btn);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            openFormChild(new NhanVien());
            DoimauBtn(btn);
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            btnTrangChu_Click(btnTrangChu, new EventArgs());
        }

     
    }
}
