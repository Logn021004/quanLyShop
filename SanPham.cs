using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyShop
{
    public partial class SanPham : Form
    {
        private string MASP;
        public SanPham()
        {
            InitializeComponent();

        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            SanPhamBUS.Instance.Xem(flowLayoutPanelSP);
            foreach(Control control in flowLayoutPanelSP.Controls)
            {
                if(control is ItemSP)
                {
                    ItemSP item = (ItemSP)control;
                    item.Click += getMASP;
                }              
            }
            SanPhamBUS.Instance.dsLoai(cbodsLoai);
            SanPhamBUS.Instance.dsNCC(cboNCC);
        }
        private void getMASP(object sender, EventArgs e)
        {
            ItemSP item = (ItemSP)sender;
            
            this.MASP = item.Tag.ToString();
            SanPhamBUS.Instance.dsSize(listSize, this.MASP);
        }







        private void btnReset_Click(object sender, EventArgs e)
        {
            flowLayoutPanelSP.Controls.Clear();
            txtNameSP.Clear();
            cbodsLoai.SelectedIndex = 0;
            cboNCC.SelectedIndex = 0;
            SanPhamBUS.Instance.dsLoai(cbodsLoai);
            SanPhamBUS.Instance.dsNCC(cboNCC);
            SanPhamBUS.Instance.Xem(flowLayoutPanelSP);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SanPhamBUS.Instance.Search(flowLayoutPanelSP, txtNameSP.Text, cbodsLoai.SelectedItem.ToString(), cboNCC.SelectedItem.ToString());
        }
    }
}
