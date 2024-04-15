namespace quanLyShop
{
    partial class ItemSP
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPic = new System.Windows.Forms.Panel();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlPic
            // 
            this.pnlPic.Location = new System.Drawing.Point(0, 0);
            this.pnlPic.Name = "pnlPic";
            this.pnlPic.Size = new System.Drawing.Size(213, 134);
            this.pnlPic.TabIndex = 0;
            // 
            // lblTenSP
            // 
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblTenSP.Location = new System.Drawing.Point(5, 137);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(207, 40);
            this.lblTenSP.TabIndex = 1;
            this.lblTenSP.Text = "Áo Sơ Mi Vải Lanh Cotton Tay Dài Dáng Rộng Cổ Đứng Cài Khóa Kiểu Trung Hoa Thời T" +
    "rang Xuân Hè 2023 5UFB Cho Nam";
            // 
            // lblGia
            // 
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblGia.Location = new System.Drawing.Point(3, 177);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(163, 31);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "Gía";
            this.lblGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGia.Click += new System.EventHandler(this.lblGia_Click);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(111, 250);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(102, 22);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng:1000";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamGia.ForeColor = System.Drawing.Color.Gray;
            this.lblGiamGia.Location = new System.Drawing.Point(3, 246);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(77, 25);
            this.lblGiamGia.TabIndex = 4;
            this.lblGiamGia.Text = "6.000 đ";
            this.lblGiamGia.Visible = false;
            // 
            // ItemSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.lblGiamGia);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.pnlPic);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ItemSP";
            this.Size = new System.Drawing.Size(213, 272);
            this.Load += new System.EventHandler(this.ItemSP_Load);
            this.MouseLeave += new System.EventHandler(this.ItemSP_MouseLeave);
            this.MouseHover += new System.EventHandler(this.ItemSP_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPic;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblGiamGia;
    }
}
