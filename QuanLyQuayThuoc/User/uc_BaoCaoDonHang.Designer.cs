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
            this.dataGridViewHoaDon = new System.Windows.Forms.DataGridView();
            this.colMathuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenthuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volSoNgayUong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongSoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitle = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
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
            this.dataGridViewHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMathuoc,
            this.colTenthuoc,
            this.colSoVien,
            this.volSoNgayUong,
            this.colTongSoVien,
            this.VolGiaBan,
            this.colThanhTien});
            this.dataGridViewHoaDon.Location = new System.Drawing.Point(22, 89);
            this.dataGridViewHoaDon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewHoaDon.Name = "dataGridViewHoaDon";
            this.dataGridViewHoaDon.ReadOnly = true;
            this.dataGridViewHoaDon.RowHeadersVisible = false;
            this.dataGridViewHoaDon.RowHeadersWidth = 102;
            this.dataGridViewHoaDon.RowTemplate.Height = 28;
            this.dataGridViewHoaDon.Size = new System.Drawing.Size(1142, 146);
            this.dataGridViewHoaDon.TabIndex = 10;
            this.dataGridViewHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHoaDon_CellContentClick);
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
            // colSoVien
            // 
            this.colSoVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSoVien.HeaderText = "Số viên Mỗi Ngày";
            this.colSoVien.MinimumWidth = 12;
            this.colSoVien.Name = "colSoVien";
            this.colSoVien.ReadOnly = true;
            // 
            // volSoNgayUong
            // 
            this.volSoNgayUong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.volSoNgayUong.HeaderText = "Số Ngày Uống";
            this.volSoNgayUong.MinimumWidth = 12;
            this.volSoNgayUong.Name = "volSoNgayUong";
            this.volSoNgayUong.ReadOnly = true;
            // 
            // colTongSoVien
            // 
            this.colTongSoVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTongSoVien.HeaderText = "Tổng Số Viên";
            this.colTongSoVien.MinimumWidth = 12;
            this.colTongSoVien.Name = "colTongSoVien";
            this.colTongSoVien.ReadOnly = true;
            // 
            // VolGiaBan
            // 
            this.VolGiaBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VolGiaBan.HeaderText = "Giá Bán";
            this.VolGiaBan.MinimumWidth = 12;
            this.VolGiaBan.Name = "VolGiaBan";
            this.VolGiaBan.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThanhTien.HeaderText = "Thành Tiền";
            this.colThanhTien.MinimumWidth = 12;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.SeaGreen;
            this.labelTitle.Location = new System.Drawing.Point(13, 17);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(203, 30);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "Quản lý Đơn Hàng";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(22, 405);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(203, 56);
            this.guna2Button1.TabIndex = 12;
            this.guna2Button1.Text = "Xóa hóa Đơn";
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
            this.guna2TextBox1.Location = new System.Drawing.Point(22, 271);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(847, 55);
            this.guna2TextBox1.TabIndex = 13;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(34, 249);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(51, 15);
            this.guna2HtmlLabel1.TabIndex = 14;
            this.guna2HtmlLabel1.Text = "Tiềm kiếm ";
            // 
            // uc_BaoCaoDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewHoaDon);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "uc_BaoCaoDonHang";
            this.Size = new System.Drawing.Size(1179, 628);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMathuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenthuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn volSoNgayUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongSoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
