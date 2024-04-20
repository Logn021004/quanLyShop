using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace quanLyShop
{
    public partial class formCapNhapSP : Form
    {
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";
        private string maSP;
        private string tensp;
        private string ncc;
        private int soluongtonkho;
        private float giaban;
        private float gianhap;
        private string loai;
        private string trangthai;
        private string pathImg;
        private string mota;

        public string Masp {
            get { return maSP; }
            set { maSP = value; }
        }
        public string Tensp
        {
            get { return tensp; }
            set
            {
                tensp = value;
                txtNameSP.Text = tensp;
            }
        }
        public string Ncc
        {
            get { return ncc; }
            set
            {
                ncc = value;

            }
        }
        public int Soluongtonkho
        {
            get { return soluongtonkho; }
            set
            {
                soluongtonkho = value;
                txtSoLuong.Text = soluongtonkho.ToString();
            }
        }
        public float Giaban
        {
            get { return giaban; }
            set
            {
                giaban = value;
                txtGiaBan.Text = giaban.ToString();
            }
        }
        public float Gianhap
        {
            get { return gianhap; }
            set
            {
                gianhap = value;
            }
        }
        public string Loai
        {
            get { return loai; }
            set
            {
                loai = value;

            }
        }
        public string Trangthai
        {
            get { return trangthai; }
            set
            {
                trangthai = value;
            }
        }
        public string PathImg
        {
            get { return pathImg; }
            set
            {
                pathImg = value;
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Imgs\\" + pathImg);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }
        public string Mota
        {
            get { return mota; }
            set
            {
                mota = value;
                txtMoTa.Text = mota;
            }
        }

        public formCapNhapSP()
        {
            InitializeComponent();
        }


        private void formCapNhapSP_Load(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select DONGIANHAP from SANPHAM where MASP= @MASP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MASP", this.maSP);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                this.gianhap = float.Parse(sdr[0].ToString());
                txtGiaNhap.Text = this.gianhap.ToString();
                sdr.Close();

            }
            SanPhamBUS.Instance.dsLoai(cboLoai);
            SanPhamBUS.Instance.dsNCC(cboNCC);
            cboNCC.SelectedItem = ncc;
            cboLoai.SelectedItem = loai;
            setCboTrangThai();
            setCboSize();

        }
        public void setCboTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Còn hàng");
            cboTrangThai.Items.Add("Ngưng bán");
            cboTrangThai.Items.Add("Lỗi");
            cboTrangThai.Items.Add("Khác");
            cboTrangThai.SelectedItem = trangthai;
        }
        public void setCboSize()
        {
            cboSize.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select SIZE from SIZESP where MASP= @MASP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MASP", this.maSP);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    cboSize.Items.Add(sdr[0].ToString());
                }
                conn.Close();
            }
            cboSize.Items.Add("Thêm size");
            cboSize.SelectedIndex = 0;
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
                trangthai = cboTrangThai.SelectedItem.ToString();
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSize.SelectedItem == "Thêm size")
            {
                txtSLSize.Clear();
                txtAddSize.Visible = true;
                btnaddSize.Visible = true;
                btnCloseSize.Visible = true;
                txtAddSize.Focus();
            }
            else
            {
                txtAddSize.Visible = false;
                btnaddSize.Visible = false;
                btnCloseSize.Visible = false;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "select SOLUONGTONKHO from SIZESP where MASP= @MASP and SIZE= @SIZE";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MASP", this.maSP);
                    cmd.Parameters.AddWithValue("@SIZE", cboSize.SelectedItem.ToString());
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    txtSLSize.Text = sdr[0].ToString();
                    sdr.Close();
                    conn.Close();
                }
            }

        }

        private void btnaddSize_Click(object sender, EventArgs e)
        {
            int sum = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select SUM(SOLUONGTONKHO) from SIZESP where MASP= @MASP ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MASP", this.maSP);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                sum = int.Parse(sdr[0].ToString());
                sdr.Close();
                if (sum + int.Parse(txtSLSize.Text) > int.Parse(txtSoLuong.Text))
                {
                    MessageBox.Show("Số lượng vượt quá số lượng tồn kho!");
                    return;
                }
                else
                {
                    query = "insert into SIZESP(MASP,SIZE,SOLUONGTONKHO,TRANGTHAI) values( @MASP , @SIZE , @SOLUONG ,N'Còn hàng')";
                    cmd = new SqlCommand(query, conn);
                    object[] para = new object[] { this.maSP, txtAddSize.Text, txtSLSize.Text };
                    if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
            }
            setCboSize();
        }

        private void btnCloseSize_Click(object sender, EventArgs e)
        {
            txtAddSize.Visible = false;
            btnaddSize.Visible = false;
            btnCloseSize.Visible = false;
            cboSize.SelectedIndex = 0;
        }

        string dlg_fileNameImg = "";
        private void btnChose_Click(object sender, EventArgs e)
        {
            dlg.Filter = "All file(*.*)|*.*";
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "Chọn ảnh!";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int vitricuoi = dlg.FileName.LastIndexOf('\\');
                this.pathImg = dlg.FileName.Substring(vitricuoi+1);
                dlg_fileNameImg=dlg.FileName;
                pictureBox1.Image = Image.FromFile(dlg.FileName);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string maloai, mancc;
                conn.Open();

                string query = "select MALOAI from LOAI WHERE TENLOAI=@TENLOAI\r\n";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TENLOAI", cboLoai.SelectedItem.ToString());
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                maloai = sdr[0].ToString();
                sdr.Close();

                query = "select MANCC from NHACUNGCAP WHERE TENNCC=@TENNCC\r\n";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TENNCC", cboNCC.SelectedItem.ToString());
                sdr = cmd.ExecuteReader();
                sdr.Read();
                mancc = sdr[0].ToString();
                sdr.Close();

                query = "update SANPHAM\r\nset TENSP= @TENSP ,MANCC= @MANCC ,MOTA= @MOTA ,SOLUONGTONKHO= @SOLUONGTONKHO ,DONGIANHAP= @GIABAN ,DONGIABAN= @GIANHAP ,IMG= @IMG ,LOAI= @LOAI ,TRANGTHAI= @TRANGTHAI \r\nwhere MASP= @MASP ";
                object[] para = new object[] {txtNameSP.Text,mancc,txtMoTa.Text,txtSoLuong.Text,txtGiaBan.Text,txtGiaNhap.Text,pathImg,maloai,trangthai,maSP };
                if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                {
                    if(!File.Exists(Application.StartupPath+"\\Imgs\\"+pathImg))
                        File.Copy(dlg_fileNameImg, Application.StartupPath + "\\Imgs\\" + pathImg);
                    MessageBox.Show("Cập nhập thành công!");
                    
                    this.Close();
                }
                else
                    MessageBox.Show("Cập nhập không thành công!");
                conn.Close();
            }
        }

        private void btnHủy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
