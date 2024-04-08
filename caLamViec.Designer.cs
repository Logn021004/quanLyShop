namespace quanLyShop
{
    partial class PhanCongform
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgvcaLamViec = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.btnCloseAddPC = new System.Windows.Forms.Button();
            this.btnSaveAddPC = new System.Windows.Forms.Button();
            this.btnCloseAddCa = new System.Windows.Forms.Button();
            this.btnSaveCa = new System.Windows.Forms.Button();
            this.txtAddCa = new System.Windows.Forms.TextBox();
            this.cbotenCa = new System.Windows.Forms.ComboBox();
            this.txtMoTa = new System.Windows.Forms.RichTextBox();
            this.dateNgayLam = new System.Windows.Forms.DateTimePicker();
            this.txtTimeKT = new System.Windows.Forms.TextBox();
            this.txtTimeBD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemPC = new System.Windows.Forms.Button();
            this.btnXoaPC = new System.Windows.Forms.Button();
            this.btnSuaPC = new System.Windows.Forms.Button();
            this.btnThemCa = new System.Windows.Forms.Button();
            this.btnXoaCa = new System.Windows.Forms.Button();
            this.btnSuaCa = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.traCứuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchCaLàmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.danhSáchPhânCôngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcaLamViec)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvcaLamViec
            // 
            this.dtgvcaLamViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvcaLamViec.Location = new System.Drawing.Point(12, 322);
            this.dtgvcaLamViec.Name = "dtgvcaLamViec";
            this.dtgvcaLamViec.RowHeadersWidth = 51;
            this.dtgvcaLamViec.RowTemplate.Height = 24;
            this.dtgvcaLamViec.Size = new System.Drawing.Size(1147, 309);
            this.dtgvcaLamViec.TabIndex = 0;
            this.dtgvcaLamViec.SelectionChanged += new System.EventHandler(this.dtgvcaLamViec_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboNV);
            this.groupBox1.Controls.Add(this.btnCloseAddPC);
            this.groupBox1.Controls.Add(this.btnSaveAddPC);
            this.groupBox1.Controls.Add(this.btnCloseAddCa);
            this.groupBox1.Controls.Add(this.btnSaveCa);
            this.groupBox1.Controls.Add(this.txtAddCa);
            this.groupBox1.Controls.Add(this.cbotenCa);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.dateNgayLam);
            this.groupBox1.Controls.Add(this.txtTimeKT);
            this.groupBox1.Controls.Add(this.txtTimeBD);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(510, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 268);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // cboNV
            // 
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(112, 136);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(163, 24);
            this.cboNV.TabIndex = 8;
            // 
            // btnCloseAddPC
            // 
            this.btnCloseAddPC.Location = new System.Drawing.Point(567, 82);
            this.btnCloseAddPC.Name = "btnCloseAddPC";
            this.btnCloseAddPC.Size = new System.Drawing.Size(74, 39);
            this.btnCloseAddPC.TabIndex = 7;
            this.btnCloseAddPC.Text = "Hủy";
            this.btnCloseAddPC.UseVisualStyleBackColor = true;
            this.btnCloseAddPC.Visible = false;
            this.btnCloseAddPC.Click += new System.EventHandler(this.btnCloseAddPC_Click);
            // 
            // btnSaveAddPC
            // 
            this.btnSaveAddPC.Location = new System.Drawing.Point(567, 37);
            this.btnSaveAddPC.Name = "btnSaveAddPC";
            this.btnSaveAddPC.Size = new System.Drawing.Size(74, 39);
            this.btnSaveAddPC.TabIndex = 7;
            this.btnSaveAddPC.Text = "Lưu ";
            this.btnSaveAddPC.UseVisualStyleBackColor = true;
            this.btnSaveAddPC.Visible = false;
            this.btnSaveAddPC.Click += new System.EventHandler(this.btnSaveAddPC_Click);
            // 
            // btnCloseAddCa
            // 
            this.btnCloseAddCa.Location = new System.Drawing.Point(204, 81);
            this.btnCloseAddCa.Name = "btnCloseAddCa";
            this.btnCloseAddCa.Size = new System.Drawing.Size(73, 37);
            this.btnCloseAddCa.TabIndex = 6;
            this.btnCloseAddCa.Text = "Hủy";
            this.btnCloseAddCa.UseVisualStyleBackColor = true;
            this.btnCloseAddCa.Visible = false;
            this.btnCloseAddCa.Click += new System.EventHandler(this.btnCloseAddCa_Click);
            // 
            // btnSaveCa
            // 
            this.btnSaveCa.Location = new System.Drawing.Point(112, 81);
            this.btnSaveCa.Name = "btnSaveCa";
            this.btnSaveCa.Size = new System.Drawing.Size(73, 37);
            this.btnSaveCa.TabIndex = 6;
            this.btnSaveCa.Text = "Áp dụng";
            this.btnSaveCa.UseVisualStyleBackColor = true;
            this.btnSaveCa.Visible = false;
            this.btnSaveCa.Click += new System.EventHandler(this.btnSaveCa_Click);
            // 
            // txtAddCa
            // 
            this.txtAddCa.Location = new System.Drawing.Point(112, 45);
            this.txtAddCa.Name = "txtAddCa";
            this.txtAddCa.Size = new System.Drawing.Size(165, 22);
            this.txtAddCa.TabIndex = 5;
            this.txtAddCa.Visible = false;
            // 
            // cbotenCa
            // 
            this.cbotenCa.FormattingEnabled = true;
            this.cbotenCa.Location = new System.Drawing.Point(112, 45);
            this.cbotenCa.Name = "cbotenCa";
            this.cbotenCa.Size = new System.Drawing.Size(165, 24);
            this.cbotenCa.TabIndex = 4;
            this.cbotenCa.SelectedIndexChanged += new System.EventHandler(this.cbotenCa_SelectedIndexChanged);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(112, 164);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(530, 92);
            this.txtMoTa.TabIndex = 3;
            this.txtMoTa.Text = "";
            // 
            // dateNgayLam
            // 
            this.dateNgayLam.CustomFormat = "dd/MM/yyyy";
            this.dateNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLam.Location = new System.Drawing.Point(439, 131);
            this.dateNgayLam.Name = "dateNgayLam";
            this.dateNgayLam.Size = new System.Drawing.Size(149, 22);
            this.dateNgayLam.TabIndex = 2;
            // 
            // txtTimeKT
            // 
            this.txtTimeKT.Location = new System.Drawing.Point(439, 88);
            this.txtTimeKT.Name = "txtTimeKT";
            this.txtTimeKT.Size = new System.Drawing.Size(122, 22);
            this.txtTimeKT.TabIndex = 1;
            // 
            // txtTimeBD
            // 
            this.txtTimeBD.Location = new System.Drawing.Point(439, 45);
            this.txtTimeBD.Name = "txtTimeBD";
            this.txtTimeBD.Size = new System.Drawing.Size(122, 22);
            this.txtTimeBD.TabIndex = 1;
            this.txtTimeBD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeBD_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày làm việc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thời gian kết thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mô tả công việc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Nhân Viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Thời gian bắt đầu ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ca";
            // 
            // btnThemPC
            // 
            this.btnThemPC.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThemPC.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThemPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemPC.Location = new System.Drawing.Point(12, 78);
            this.btnThemPC.Name = "btnThemPC";
            this.btnThemPC.Size = new System.Drawing.Size(153, 99);
            this.btnThemPC.TabIndex = 2;
            this.btnThemPC.Text = "Thêm Phân Công";
            this.btnThemPC.UseVisualStyleBackColor = false;
            this.btnThemPC.Click += new System.EventHandler(this.btnThemPC_Click);
            // 
            // btnXoaPC
            // 
            this.btnXoaPC.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoaPC.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoaPC.FlatAppearance.BorderSize = 0;
            this.btnXoaPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPC.Location = new System.Drawing.Point(171, 78);
            this.btnXoaPC.Name = "btnXoaPC";
            this.btnXoaPC.Size = new System.Drawing.Size(153, 99);
            this.btnXoaPC.TabIndex = 2;
            this.btnXoaPC.Text = "Xóa Phân Công";
            this.btnXoaPC.UseVisualStyleBackColor = false;
            this.btnXoaPC.Click += new System.EventHandler(this.btnXoaPC_Click);
            // 
            // btnSuaPC
            // 
            this.btnSuaPC.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSuaPC.FlatAppearance.BorderSize = 0;
            this.btnSuaPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaPC.Location = new System.Drawing.Point(330, 78);
            this.btnSuaPC.Name = "btnSuaPC";
            this.btnSuaPC.Size = new System.Drawing.Size(153, 99);
            this.btnSuaPC.TabIndex = 2;
            this.btnSuaPC.Text = "Sửa Phân Công";
            this.btnSuaPC.UseVisualStyleBackColor = false;
            this.btnSuaPC.Click += new System.EventHandler(this.btnSuaPC_Click);
            // 
            // btnThemCa
            // 
            this.btnThemCa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThemCa.FlatAppearance.BorderSize = 0;
            this.btnThemCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCa.Location = new System.Drawing.Point(12, 183);
            this.btnThemCa.Name = "btnThemCa";
            this.btnThemCa.Size = new System.Drawing.Size(153, 99);
            this.btnThemCa.TabIndex = 2;
            this.btnThemCa.Text = "Thêm Ca Làm";
            this.btnThemCa.UseVisualStyleBackColor = false;
            this.btnThemCa.Click += new System.EventHandler(this.btnThemCa_Click);
            // 
            // btnXoaCa
            // 
            this.btnXoaCa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoaCa.FlatAppearance.BorderSize = 0;
            this.btnXoaCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCa.Location = new System.Drawing.Point(171, 183);
            this.btnXoaCa.Name = "btnXoaCa";
            this.btnXoaCa.Size = new System.Drawing.Size(153, 99);
            this.btnXoaCa.TabIndex = 2;
            this.btnXoaCa.Text = "Xóa Ca Làm";
            this.btnXoaCa.UseVisualStyleBackColor = false;
            this.btnXoaCa.Click += new System.EventHandler(this.btnXoaCa_Click);
            // 
            // btnSuaCa
            // 
            this.btnSuaCa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSuaCa.FlatAppearance.BorderSize = 0;
            this.btnSuaCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCa.Location = new System.Drawing.Point(330, 183);
            this.btnSuaCa.Name = "btnSuaCa";
            this.btnSuaCa.Size = new System.Drawing.Size(153, 99);
            this.btnSuaCa.TabIndex = 2;
            this.btnSuaCa.Text = "Sửa Ca Làm";
            this.btnSuaCa.UseVisualStyleBackColor = false;
            this.btnSuaCa.Click += new System.EventHandler(this.btnSuaCa_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traCứuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1171, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // traCứuToolStripMenuItem
            // 
            this.traCứuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchCaLàmToolStripMenuItem,
            this.toolStripMenuItem1,
            this.danhSáchPhânCôngToolStripMenuItem});
            this.traCứuToolStripMenuItem.Name = "traCứuToolStripMenuItem";
            this.traCứuToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.traCứuToolStripMenuItem.Text = "Tra Cứu";
            // 
            // danhSáchCaLàmToolStripMenuItem
            // 
            this.danhSáchCaLàmToolStripMenuItem.Name = "danhSáchCaLàmToolStripMenuItem";
            this.danhSáchCaLàmToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.danhSáchCaLàmToolStripMenuItem.Text = "Danh sách ca làm";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(231, 6);
            // 
            // danhSáchPhânCôngToolStripMenuItem
            // 
            this.danhSáchPhânCôngToolStripMenuItem.Name = "danhSáchPhânCôngToolStripMenuItem";
            this.danhSáchPhânCôngToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.danhSáchPhânCôngToolStripMenuItem.Text = "Danh sách phân công";
            this.danhSáchPhânCôngToolStripMenuItem.Click += new System.EventHandler(this.danhSáchPhânCôngToolStripMenuItem_Click);
            // 
            // PhanCongform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1171, 643);
            this.Controls.Add(this.btnXoaCa);
            this.Controls.Add(this.btnSuaPC);
            this.Controls.Add(this.btnSuaCa);
            this.Controls.Add(this.btnXoaPC);
            this.Controls.Add(this.btnThemCa);
            this.Controls.Add(this.btnThemPC);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgvcaLamViec);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PhanCongform";
            this.Text = "Phân Công";
            this.Load += new System.EventHandler(this.CaLamViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcaLamViec)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvcaLamViec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThemPC;
        private System.Windows.Forms.Button btnXoaPC;
        private System.Windows.Forms.Button btnSuaPC;
        private System.Windows.Forms.Button btnThemCa;
        private System.Windows.Forms.Button btnXoaCa;
        private System.Windows.Forms.Button btnSuaCa;
        private System.Windows.Forms.TextBox txtTimeKT;
        private System.Windows.Forms.TextBox txtTimeBD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtMoTa;
        private System.Windows.Forms.DateTimePicker dateNgayLam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem traCứuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchCaLàmToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem danhSáchPhânCôngToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbotenCa;
        private System.Windows.Forms.Button btnCloseAddCa;
        private System.Windows.Forms.Button btnSaveCa;
        private System.Windows.Forms.TextBox txtAddCa;
        private System.Windows.Forms.Button btnCloseAddPC;
        private System.Windows.Forms.Button btnSaveAddPC;
        private System.Windows.Forms.ComboBox cboNV;
    }
}