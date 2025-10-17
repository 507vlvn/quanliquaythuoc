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
using QuanLyQuayThuoc.sql;

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
           List<Role> listRole = db.Roles.ToList();
            fillcombobox(listRole);
            clear();    

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void fillcombobox(List<Role> listRole)
        {
            cbChucVu.DataSource = listRole;
            cbChucVu.DisplayMember = "Role1";
            cbChucVu.ValueMember = "RoleID";
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            var selectedRole = cbChucVu.Text;
           

            var user = db.People.FirstOrDefault(p =>p.UserID == txtName.Text &&
                    p.PasswordHash == txtMK.Text &&
                    p.Role.Role1 == selectedRole);

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
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            cbChucVu.SelectedIndex = -1;
            txtName.Clear();
            txtMK.Clear();
        }
        private void clear()
        {
            cbChucVu.SelectedIndex = -1;
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
            if(btnanmk.Visible == false)
            {
                btnhienMk.Visible = false;
                btnanmk.Visible = true;
            }
            if(txtMK.UseSystemPasswordChar == true)
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
