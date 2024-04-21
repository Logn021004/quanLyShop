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
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace quanLyShop
{
    public partial class formAddSP : Form
    {
        string connectionString = @"Data Source=LONG-PC;Initial Catalog=QlyShop;Integrated Security=True";
        Dictionary<string, int> dsSize = new Dictionary<string, int>();
        string dlg_fileNameImg = "";
        string pathImg = "";
        public formAddSP()
        {
            InitializeComponent();
        }

        private void formAddSP_Load(object sender, EventArgs e)
        {
            SanPhamBUS.Instance.dsNCC(cboNCC1);
            SanPhamBUS.Instance.dsLoai(cboLoai1);
            setCboTrangThai();
            setCboSize();
        }
        public void setCboTrangThai()
        {
            cboTrangThai1.Items.Clear();
            cboTrangThai1.Items.Add("Còn hàng");
            cboTrangThai1.Items.Add("Ngưng bán");
            cboTrangThai1.Items.Add("Lỗi");
            cboTrangThai1.Items.Add("Khác");
            cboTrangThai1.SelectedIndex = 0;
        }
        public void setCboSize()
        {
            cboSize1.Items.Clear();
            cboSize1.Items.Add("Thêm size");
            foreach(KeyValuePair<string,int> item in dsSize)
            {
                cboSize1.Items.Add(item.Key);
            }
            cboSize1.SelectedIndex = 0;
        }    
        private void btnHủy1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboSize1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboSize1.SelectedItem == "Thêm size")
            {
                txtSLSize1.Clear();
                txtAddSize1.Visible = true;
                btnaddSize1.Visible = true;
                btnCloseSize1.Visible = true;
                txtAddSize1.Focus();
                lblnamesize.Visible = true;
            }
            else
            {              
                foreach (KeyValuePair<string, int> item in dsSize)
                {
                    if (item.Key == cboSize1.SelectedItem)
                    {
                        txtSLSize1.Text = item.Value.ToString();
                    }
                }
                txtAddSize1.Visible = false;
                btnaddSize1.Visible = false;
                btnCloseSize1.Visible = false;
                lblnamesize.Visible = false;
                
            }
        }
        private void btnChose1_Click_1(object sender, EventArgs e)
        {
            dlg.Filter = "All file(*.*)|*.*";
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "Chọn ảnh!";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int vitricuoi = dlg.FileName.LastIndexOf('\\');
                pathImg = dlg.FileName.Substring(vitricuoi + 1);
                dlg_fileNameImg = dlg.FileName;
                pictureBox.Image = Image.FromFile(dlg.FileName);
            }
        }
        private void btnaddSize1_Click_1(object sender, EventArgs e)
        {
            int sum = 0;
            if (!string.IsNullOrEmpty(txtAddSize1.Text) && !string.IsNullOrEmpty(txtSLSize1.Text) && !string.IsNullOrEmpty(txtSoLuong1.Text))
            {
                foreach (KeyValuePair<string, int> item in dsSize)
                {
                    sum += item.Value;
                }
                sum += int.Parse(txtSLSize1.Text);
                if (sum > int.Parse(txtSoLuong1.Text))
                {
                    MessageBox.Show("số lượng vượt quá số lượng có trong kho ");
                }
                else
                {
                    dsSize.Add(txtAddSize1.Text, int.Parse(txtSLSize1.Text));
                    setCboSize();
                }
            }
            else
            {
                MessageBox.Show("Lỗi");
            }             
        }

        private void btnCloseSize1_Click_1(object sender, EventArgs e)
        {
            txtAddSize1.Visible = false;
            btnaddSize1.Visible = false;
            btnCloseSize1.Visible = false;
            lblnamesize.Visible = false;
            cboSize1.SelectedIndex = 0;
        }

        private void btnXoaSize_Click(object sender, EventArgs e)
        {
            if (cboSize1.SelectedItem != "Thêm size")
                dsSize.Remove(cboSize1.SelectedItem.ToString());
            setCboSize();
        }

        private void btnLuu1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string maloai, mancc;
                conn.Open();

                string query = "select MALOAI from LOAI WHERE TENLOAI=@TENLOAI\r\n";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TENLOAI", cboLoai1.SelectedItem.ToString());
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                maloai = sdr[0].ToString();
                sdr.Close();

                query = "select MANCC from NHACUNGCAP WHERE TENNCC=@TENNCC\r\n";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TENNCC", cboNCC1.SelectedItem.ToString());
                sdr = cmd.ExecuteReader();
                sdr.Read();
                mancc = sdr[0].ToString();
                sdr.Close();

                query = "insert into SANPHAM (MASP,MANCC,TENSP,MOTA,SOLUONGTONKHO,DONGIANHAP,DONGIABAN,IMG,LOAI,TRANGTHAI) \r\nvalues( @MASP , @MANCC , @TENSP , @MOTA , @SOLUONGTONKHO , @GIANHAP , @GIABAN , @IMG , @LOAI , @TRANGTHAI )";
                object[] para = new object[] { txtMaSP.Text ,mancc, txtNameSP1.Text, txtMoTa1.Text, txtSoLuong1.Text, txtGiaNhap1.Text, txtGiaBan1.Text, pathImg, maloai, cboTrangThai1.SelectedItem.ToString() };
                if (!string.IsNullOrWhiteSpace(txtMaSP.Text) &&Functions.Instance.ExecuteNonQuery(query, para) > 0)
                {
                    if (!File.Exists(Application.StartupPath + "\\Imgs\\" + pathImg))
                        File.Copy(dlg_fileNameImg, Application.StartupPath + "\\Imgs\\" + pathImg);
                    foreach(KeyValuePair<string,int> item in dsSize)
                    {
                        if (item.Value > 0)
                            query = "insert into SIZESP(MASP,SIZE,SOLUONGTONKHO,TRANGTHAI) values( @MASP , @SIZE , @SL ,N'Hết hàng' )";
                        else
                            query = "insert into SIZESP(MASP,SIZE,SOLUONGTONKHO,TRANGTHAI) values( @MASP , @SIZE , @SL ,N'Còn hàng' )";
                        cmd = new SqlCommand(query, conn);
                        para = new object[] { txtMaSP.Text,item.Key,item.Value.ToString() };
                        Functions.Instance.ExecuteNonQuery(query, para);
                    }
                    MessageBox.Show("Thêm thành công!");                   
                    this.Close();
                }
                else
                    MessageBox.Show("Thêm không thành công!");
                conn.Close();
            }
        }
    }
}

