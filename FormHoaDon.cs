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
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
            txtSdtSearch.TextChanged += txtSdtSearch_TextChanged;
            txtTienTra.TextChanged += txtTienTra_TextChanged;
            txtGiamGia.KeyPress += txtGiamGia_KeyPress;
            txtGiamGia.TextChanged += txtGiamGia_TextChanged;
        }
        private string MASP;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SanPhamBUS.Instance.Search(flowLayoutPanelSP, txtNameSP.Text, cbodsLoai.SelectedItem.ToString(), cboNCC.SelectedItem.ToString());
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            SanPhamBUS.Instance.Xem(flowLayoutPanelSP);
            foreach (Control control in flowLayoutPanelSP.Controls)
            {
                if (control is ItemSP)
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
            SanPhamDTO sp =  hoadonBUS.Instance.thongtinSP(MASP);
            foreach (DataGridViewRow row in dtgvHOADON.Rows)
            {
                if (!row.IsNewRow)
                {
                    string nameRow = row.Cells[0].Value.ToString();
                    if (nameRow.Contains(sp.Tensp))
                    {
                        return;
                    }
                }
            }
            int rowindex=  dtgvHOADON.Rows.Add(sp.Tensp, sp.Dongia, sp.Km, 1, sp.Dongia);
            DataGridViewButtonCell buttonTangSL = new DataGridViewButtonCell();
            buttonTangSL.Value = "+";
            dtgvHOADON.Rows[rowindex].Cells[5] = buttonTangSL;
            DataGridViewButtonCell buttonGiamSL = new DataGridViewButtonCell();
            buttonGiamSL.Value = "-";
            dtgvHOADON.Rows[rowindex].Cells[6] = buttonGiamSL;
            lbltongTien();
        }
        private void btnReset_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanelSP.Controls.Clear();
            txtNameSP.Clear();
            cbodsLoai.SelectedIndex = 0;
            cboNCC.SelectedIndex = 0;
            SanPhamBUS.Instance.dsLoai(cbodsLoai);
            SanPhamBUS.Instance.dsNCC(cboNCC);
            FormHoaDon_Load(sender, e);
        }

        private void dtgvHOADON_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex !=5 && e.ColumnIndex!=6) 
            {
                dtgvHOADON.Rows.RemoveAt(e.RowIndex); 
            }
            lbltongTien();
        }

        private void dtgvHOADON_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == 5 || e.ColumnIndex == 6)) 
            {
                int rowIndex = e.RowIndex;
                string nameSp = dtgvHOADON.Rows[rowIndex].Cells[0].Value.ToString();
                int quantity = Convert.ToInt32(dtgvHOADON.Rows[rowIndex].Cells["SL"].Value);
                int tong = Convert.ToInt32(dtgvHOADON.Rows[rowIndex].Cells[1].Value);
                if (e.ColumnIndex == 5 && hoadonBUS.Instance.checkSlOfHdon(nameSp, quantity + 1))
                {
                    quantity++;
                    tong *= quantity;
                    txtTienTra.Text = "0";
                }
                else if (e.ColumnIndex == 6 && quantity > 1) 
                {
                    quantity--;
                    tong *= quantity;
                    txtTienTra.Text = "0";
                }
                else
                {
                    MessageBox.Show("Số lượng vượt quá hàng tồn kho!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lbltongTien();
                    return;
                }
                dtgvHOADON.Rows[rowIndex].Cells[4].Value = tong;
                dtgvHOADON.Rows[rowIndex].Cells["SL"].Value = quantity;
                lbltongTien();
            }
        }
        int tongtien;
        int tongtientemp;
        private void lbltongTien()
        {
            int sum = 0;
            foreach (DataGridViewRow row in dtgvHOADON.Rows)
            {
               
                if (!row.IsNewRow)
                {
                    int tong = int.Parse(row.Cells[4].Value.ToString());
                    sum += tong;
                }
            }
            lblTongTien.Text = sum.ToString("#,#") + " ₫";
            this.tongtien =sum;
            this.tongtientemp = sum;
        }

        private void txtSdtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSdtSearch.Text.Length > 9&& txtSdtSearch.Text.Length <= 10 && txtSdtSearch.Text!="")
            {
                txtNameKhach.Text = hoadonBUS.Instance.nameKhach(txtSdtSearch.Text);
            }
            else if(txtSdtSearch.Text == "")
            {
                txtNameKhach.Text = "Khách lẻ";
                txtSdtSearch.Text = "0";
            }
            else
            {
                txtNameKhach.Text = "Khách lẻ";               
            }
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }


        private void txtTienTra_TextChanged(object sender, EventArgs e)
        {
            if(txtTienTra.Text != ""&&txtTienTra.Text != "0" && int.Parse(txtTienTra.Text)> this.tongtientemp)
            {
                txtTienThua.Text = ( this.tongtientemp - int.Parse(txtTienTra.Text)).ToString();
            }
            else if(txtTienTra.Text != "" && int.Parse(txtTienTra.Text) == this.tongtientemp)
            {
                txtTienThua.Text = "0";
            }
            else
            {
                txtTienThua.Text = "Không đủ";
            }
        }

        private void txtTienTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
   
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (txtGiamGia.Text == "100")
            {
                lblTongTien.Text = 0.ToString() + " ₫";
                txtTienTra.Text = 0.ToString();
            }
            else if (txtGiamGia.Text != "")
            {
                lblTongTien.Text = (this.tongtien - ((this.tongtien * int.Parse(txtGiamGia.Text)) / 100)).ToString("#,#") + " ₫";
                this.tongtientemp = (this.tongtien - ((this.tongtien * int.Parse(txtGiamGia.Text)) / 100));
            }
            else
            {
                txtGiamGia.Text = "0";
                lblTongTien.Text = this.tongtien.ToString("#,#") + " ₫";
                this.tongtientemp = this.tongtien;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtgvHOADON.Rows.Count > 0&&txtNameKhach.Text!="Không tồn tại")
            {                         
                if(txtTienThua.Text=="Không đủ")
                {
                    MessageBox.Show("Chưa đủ tiền");
                    return;
                }
                else if (hoadonBUS.Instance.ThanhToan(dtgvHOADON, txtSdtSearch, txtGiamGia, txtTienTra, txtTienThua, lblTongTien))
                {
                    MessageBox.Show("Thanh Toán thành công!");
                }
                else
                {
                    MessageBox.Show("Thanh Toán không thành công!");
                    btnHuy_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Thông tin thanh toán không đầy đủ!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
           
            dtgvHOADON.Rows.Clear();
            lblTongTien.Text = "";
            txtGiamGia.Text = "0";
            txtTienTra.Text = "0";
            txtTienThua.Text = "Không đủ";
            FormHoaDon_Load(sender, e);
        }
    }
}
