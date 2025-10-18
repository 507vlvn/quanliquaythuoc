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

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            clear();

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Vui lòng nhập tên đăng nhập");
            }
            else if (string.IsNullOrEmpty(txtMK.Text))

            {
                errorProvider1.SetError(txtMK, "Vui lòng nhập mật khẩu");

            }
            else
            {

                var user = db.People.FirstOrDefault(p => p.UserID == txtName.Text &&
                            p.PasswordHash == txtMK.Text);

                if (user != null)
                {

                    if (user.Role.Role1 == "Admin")
                    {

                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon1.BalloonTipTitle = "Thông báo";
                        notifyIcon1.BalloonTipText = "Đăng nhập thành công với vai trò Quản trị viên";
                        notifyIcon1.ShowBalloonTip(1000);

                        this.Hide();
                        admin2 ad = new admin2();
                        ad.ShowDialog();
                        this.Close();

                    }
                    else
                    {
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon1.BalloonTipTitle = "Thông báo";
                        notifyIcon1.BalloonTipText = "Đăng nhập thành công với vai trò " + user.Role.Role1;
                        notifyIcon1.ShowBalloonTip(1000);

                        this.Hide();
                        FormNV nv = new FormNV();
                        nv.ShowDialog();
                        this.Close();   
                    }
                }
                else
                {
                    errorProvider1.SetError(txtMK, "Tên đăng nhập hoặc mật khẩu không đúng");
                    errorProvider1.SetError(txtName, "Tên đăng nhập hoặc mật khẩu không đúng");
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                    notifyIcon1.BalloonTipTitle = "Thông báo";
                    notifyIcon1.BalloonTipText = "sai ten dang nhap hoac mk";
                    notifyIcon1.ShowBalloonTip(1000);
                }
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

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtName_TextChanged(object sender, EventArgs e)
        {


        }
    }
}
