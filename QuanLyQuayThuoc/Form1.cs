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
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "Hieu" && txtMK.Text == "123")
            {
                FromAdmin admin = new FromAdmin();
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
    }
}
