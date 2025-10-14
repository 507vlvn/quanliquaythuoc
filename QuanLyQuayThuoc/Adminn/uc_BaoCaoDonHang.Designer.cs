namespace QuanLyQuayThuoc.User
{
    partial class uc_BaoCaoDonHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_BaoCaoDonHang));
            this.dataGridViewHoaDon = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.colMaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMathuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenthuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volSoNgayUong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHoaDon
            // 
            this.dataGridViewHoaDon.AllowUserToAddRows = false;
            this.dataGridViewHoaDon.AllowUserToDeleteRows = false;
            this.dataGridViewHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHoaDon.BackgroundColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHoaDon,
            this.colMathuoc,
            this.colTenthuoc,
            this.volSoNgayUong,
            this.colSDT,
            this.colTenKh,
            this.colThanhTien});
            this.dataGridViewHoaDon.Location = new System.Drawing.Point(22, 89);
            this.dataGridViewHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewHoaDon.Name = "dataGridViewHoaDon";
            this.dataGridViewHoaDon.ReadOnly = true;
            this.dataGridViewHoaDon.RowHeadersVisible = false;
            this.dataGridViewHoaDon.RowHeadersWidth = 102;
            this.dataGridViewHoaDon.RowTemplate.Height = 28;
            this.dataGridViewHoaDon.Size = new System.Drawing.Size(1042, 402);
            this.dataGridViewHoaDon.TabIndex = 10;
            this.dataGridViewHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHoaDon_CellContentClick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.SeaGreen;
            this.labelTitle.Location = new System.Drawing.Point(13, 17);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(174, 24);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "Quản Lý Hóa Đơn";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(22, 495);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(203, 56);
            this.guna2Button1.TabIndex = 12;
            this.guna2Button1.Text = "Xóa Hóa Đơn";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(22, 53);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(1042, 31);
            this.guna2TextBox1.TabIndex = 13;
            // 
            // guna2Button6
            // 
            this.guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button6.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button6.ForeColor = System.Drawing.Color.Black;
            this.guna2Button6.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button6.Image")));
            this.guna2Button6.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button6.Location = new System.Drawing.Point(966, 17);
            this.guna2Button6.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Size = new System.Drawing.Size(98, 37);
            this.guna2Button6.TabIndex = 14;
            this.guna2Button6.Text = "Search:";
            // 
            // colMaHoaDon
            // 
            this.colMaHoaDon.HeaderText = "Mã Hóa Đơn";
            this.colMaHoaDon.Name = "colMaHoaDon";
            this.colMaHoaDon.ReadOnly = true;
            // 
            // colMathuoc
            // 
            this.colMathuoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMathuoc.HeaderText = "Mã Thuốc";
            this.colMathuoc.MinimumWidth = 12;
            this.colMathuoc.Name = "colMathuoc";
            this.colMathuoc.ReadOnly = true;
            // 
            // colTenthuoc
            // 
            this.colTenthuoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenthuoc.HeaderText = "Tên Thuốc";
            this.colTenthuoc.MinimumWidth = 12;
            this.colTenthuoc.Name = "colTenthuoc";
            this.colTenthuoc.ReadOnly = true;
            // 
            // volSoNgayUong
            // 
            this.volSoNgayUong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.volSoNgayUong.HeaderText = "Số Ngày Uống";
            this.volSoNgayUong.MinimumWidth = 12;
            this.volSoNgayUong.Name = "volSoNgayUong";
            this.volSoNgayUong.ReadOnly = true;
            // 
            // colSDT
            // 
            this.colSDT.HeaderText = "Sô Điện Thoại";
            this.colSDT.Name = "colSDT";
            this.colSDT.ReadOnly = true;
            // 
            // colTenKh
            // 
            this.colTenKh.HeaderText = "Tên Khách Hàng";
            this.colTenKh.Name = "colTenKh";
            this.colTenKh.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThanhTien.HeaderText = "Tổng Tiền";
            this.colThanhTien.MinimumWidth = 12;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(893, 508);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 31);
            this.textBox1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(737, 517);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tổng Doanh Thu";
            // 
            // uc_BaoCaoDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.guna2Button6);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewHoaDon);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uc_BaoCaoDonHang";
            this.Size = new System.Drawing.Size(1079, 567);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHoaDon;
        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMathuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenthuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn volSoNgayUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}
