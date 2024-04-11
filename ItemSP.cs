using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyShop
{
    public partial class ItemSP : UserControl
    {

        private string tenSP;
        private string pathImg;
        private int gia;
        private int giamgia;
        private int soluong;

        public string TenSP
        {
            get
            {
                return tenSP;
            }
            set
            {
                tenSP = value;
                lblTenSP.Text = tenSP;
            }
        }
        public string PathImg
        {
            get { return pathImg; }
            set { 
                pathImg = value;
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = new Bitmap(Application.StartupPath + "\\Imgs\\" + pathImg);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                
                pictureBox.Size = pnlPic.Size;
                pnlPic.Controls.Add(pictureBox);
            }
        }
        public int Gia
        {
            get { return gia; }
            set
            {
                gia = value;              
            }
        }
        public int Giamgia
        {
            get { return giamgia; }
            set
            {
                giamgia = value;               
            }
        }
        public int Soluong
        {
            get { return soluong; }
            set
            {
                soluong = value;
                lblSoLuong.Text = "Số lượng: " + soluong.ToString();
            }
        }
        public ItemSP()
        {
            InitializeComponent();
            tenSP = "";
            gia = 0;
            giamgia= 0;
            pathImg = "";
            soluong=0;
        }
        private void ItemSP_Load(object sender, EventArgs e)
        {

        }
        public void setMoney()
        {
            if (giamgia > 0)
            {
                lblGiamGia.Visible = true;
                lblGiamGia.Text = ((giamgia * gia) / 100).ToString("#,#") + " ₫";              
            }
            lblGia.Text = "Giá: " + (gia - ((giamgia * gia) / 100)).ToString("#,#") + " ₫";
        }

        private void lblGia_Click(object sender, EventArgs e)
        {

        }
    }
}
