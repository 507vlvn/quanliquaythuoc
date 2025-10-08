using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuayThuoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //hhau ne

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string role = cbChucVu.SelectedItem?.ToString();
            string username = txtName.Text.Trim();
            string password = txtMK.Text.Trim();

            // Kiểm tra nếu chưa chọn chức vụ
            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng chọn chức vụ trước khi đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username == "1" && password == "1")
            {
                if (role != "Admin")
                {
                    MessageBox.Show("Tài khoản này thuộc quyền Admin. Vui lòng chọn lại chức vụ 'Admin'.", "Sai chức vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FormAdmin admin = new FormAdmin();
                admin.Show();
                this.Hide();
                return;
            }

            if (username == "" && password == "")
            {
                if (role != "Nhân viên")
                {
                    MessageBox.Show("Tài khoản này thuộc quyền Nhân viên. Vui lòng chọn lại chức vụ 'Nhân viên'.", "Sai chức vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide();
                FormNV formNV = new FormNV();
                formNV.ShowDialog();

                return;
            }

            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnReload_Click(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            cbChucVu.Items.Add("Admin");
            cbChucVu.Items.Add("Nhân viên");
            cbChucVu.SelectedIndex = -1; // Chưa chọn gì ban đầu
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
  

        }
    }
}
