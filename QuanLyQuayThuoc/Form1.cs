using QuanLyQuayThuoc.sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using NotifyIconEx;

namespace QuanLyQuayThuoc
{
    public partial class Form1 : Form
    {
        ModelSQL db = new ModelSQL();
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Icon = SystemIcons.WinLogo;
            this.MaximizeBox = false; // Không cho phóng to
            this.MinimizeBox = false; // Không cho thu nhỏ
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Không cho thay đổi kích thước
            this.FormBorderStyle = FormBorderStyle.None;
         

        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
            clear();

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            

        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Vui lòng nhập tên đăng nhập");
                return;
            }

            if (string.IsNullOrEmpty(txtMK.Text))
            {
                errorProvider1.SetError(txtMK, "Vui lòng nhập mật khẩu");
                return;
            }

            var user = db.People.FirstOrDefault(p => p.UserID == txtName.Text && p.PasswordHash == txtMK.Text);

            if (user != null)
            {
               
                CurrentUser.UserID = user.UserID;
                CurrentUser.FullName = user.FullName;
                CurrentUser.Role = user.Role.Role1;

                this.Hide();
                if (user.Role.Role1 == "Admin")
                {

                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.BalloonTipTitle = "Thông báo";
                    notifyIcon1.BalloonTipText = "Bạn Đang Đăng Nhập Với Chức Vụ Là Quản Trị Viên";
                    notifyIcon1.ShowBalloonTip(1000);
                    new admin2().ShowDialog();
                }
                else
                {

                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.BalloonTipTitle = "Thông báo";
                    notifyIcon1.BalloonTipText = "Bạn Đang Đăng Nhập Với Chức Vụ Là Nhân Viên";
                    notifyIcon1.ShowBalloonTip(1000);
                    new FormNV().ShowDialog();
                }

                this.Close();
            }
            else
            {
                errorProvider1.SetError(txtMK, "Tên đăng nhập hoặc mật khẩu không đúng");
                errorProvider1.SetError(txtName, "Tên đăng nhập hoặc mật khẩu không đúng");

                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon1.BalloonTipTitle = "Thông báo";
                notifyIcon1.BalloonTipText = "Sai tên đăng nhập hoặc mật khẩu";
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

            txtName.Clear();
            txtMK.Clear();
        }
        private void clear()
        {

            txtName.Clear();
            txtMK.Clear();
        }



        private void btnanmk_Click(object sender, EventArgs e)
        {
            if (btnhienMk.Visible == false)
            {
                btnhienMk.Visible = true;
                btnanmk.Visible = false;
            }
            if (txtMK.UseSystemPasswordChar == true)
            {
                txtMK.UseSystemPasswordChar = false;
            }
            else
            {
                txtMK.UseSystemPasswordChar = true;
            }

        }

        private void btnhienMk_Click(object sender, EventArgs e)
        {
            if (btnanmk.Visible == false)
            {
                btnhienMk.Visible = false;
                btnanmk.Visible = true;
            }
            if (txtMK.UseSystemPasswordChar == true)
            {
                txtMK.UseSystemPasswordChar = false;
            }
            else
            {
                txtMK.UseSystemPasswordChar = true;
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

