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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_BaoCaoDonHang));
            this.dgvQuanLiHoaDon = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btndelete = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTongHoaDon = new System.Windows.Forms.Label();
            this.lbTongDoanhThu = new System.Windows.Forms.Label();
            this.LabUs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLiHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuanLiHoaDon
            // 
            this.dgvQuanLiHoaDon.AllowUserToAddRows = false;
            this.dgvQuanLiHoaDon.AllowUserToDeleteRows = false;
            this.dgvQuanLiHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuanLiHoaDon.BackgroundColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuanLiHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuanLiHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanLiHoaDon.Location = new System.Drawing.Point(22, 89);
            this.dgvQuanLiHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.dgvQuanLiHoaDon.Name = "dgvQuanLiHoaDon";
            this.dgvQuanLiHoaDon.ReadOnly = true;
            this.dgvQuanLiHoaDon.RowHeadersVisible = false;
            this.dgvQuanLiHoaDon.RowHeadersWidth = 102;
            this.dgvQuanLiHoaDon.RowTemplate.Height = 28;
            this.dgvQuanLiHoaDon.Size = new System.Drawing.Size(1042, 402);
            this.dgvQuanLiHoaDon.TabIndex = 10;
            this.dgvQuanLiHoaDon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLiHoaDon_CellDoubleClick_1);
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
            // btndelete
            // 
            this.btndelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btndelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btndelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btndelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btndelete.FillColor = System.Drawing.Color.White;
            this.btndelete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.Black;
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.ImageSize = new System.Drawing.Size(30, 30);
            this.btndelete.Location = new System.Drawing.Point(22, 495);
            this.btndelete.Margin = new System.Windows.Forms.Padding(2);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(203, 56);
            this.btndelete.TabIndex = 12;
            this.btndelete.Text = "Xóa Hóa Đơn";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(22, 53);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(1042, 31);
            this.txtTimKiem.TabIndex = 13;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(737, 517);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tổng Doanh Thu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tổng Hóa Đơn:";
            // 
            // lbTongHoaDon
            // 
            this.lbTongHoaDon.AutoSize = true;
            this.lbTongHoaDon.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongHoaDon.Location = new System.Drawing.Point(414, 517);
            this.lbTongHoaDon.Name = "lbTongHoaDon";
            this.lbTongHoaDon.Size = new System.Drawing.Size(20, 22);
            this.lbTongHoaDon.TabIndex = 17;
            this.lbTongHoaDon.Text = "0";
            // 
            // lbTongDoanhThu
            // 
            this.lbTongDoanhThu.AutoSize = true;
            this.lbTongDoanhThu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongDoanhThu.Location = new System.Drawing.Point(893, 517);
            this.lbTongDoanhThu.Name = "lbTongDoanhThu";
            this.lbTongDoanhThu.Size = new System.Drawing.Size(20, 22);
            this.lbTongDoanhThu.TabIndex = 17;
            this.lbTongDoanhThu.Text = "0";
            // 
            // LabUs
            // 
            this.LabUs.AutoSize = true;
            this.LabUs.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabUs.Location = new System.Drawing.Point(235, 22);
            this.LabUs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabUs.Name = "LabUs";
            this.LabUs.Size = new System.Drawing.Size(47, 19);
            this.LabUs.TabIndex = 18;
            this.LabUs.Text = "User :";
            this.LabUs.Click += new System.EventHandler(this.LabUs_Click);
            // 
            // uc_BaoCaoDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.Controls.Add(this.LabUs);
            this.Controls.Add(this.lbTongDoanhThu);
            this.Controls.Add(this.lbTongHoaDon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Button6);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dgvQuanLiHoaDon);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uc_BaoCaoDonHang";
            this.Size = new System.Drawing.Size(1079, 567);
            this.Load += new System.EventHandler(this.uc_BaoCaoDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLiHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuanLiHoaDon;
        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Button btndelete;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTongHoaDon;
        private System.Windows.Forms.Label lbTongDoanhThu;
        private System.Windows.Forms.Label LabUs;
    }
}
