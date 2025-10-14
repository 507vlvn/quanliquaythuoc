using QuanLyQuayThuoc.Adminn;
using QuanLyQuayThuoc.User;
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
    public partial class FormNV : Form
    {
        public FormNV()
        {
            InitializeComponent();
        }

        private void btnOder_Click(object sender, EventArgs e)
        {
            uc_BanThuoc banThuoc = new uc_BanThuoc();
            banThuoc.Dock = DockStyle.Fill;  // Cho vừa khít panel
            panel1.Controls.Clear();   // Xóa các control cũ (nếu có)
            panel1.Controls.Add(banThuoc);   // Thêm usercontrol mới vào panel
        }

        private void FormNV_Load(object sender, EventArgs e)
        {
           
           
        }

        private void btnKiemTraDonHang_Click(object sender, EventArgs e)
        {
           uc_BaoCaoDonHang b = new uc_BaoCaoDonHang();
            b.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(b);
        }



   

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm=new Form1();
            frm.ShowDialog();
            Application.Exit();
        }

        private void btnXemDuLieuThuoc_Click(object sender, EventArgs e)
        {
            uc_XemThuoc xemthuoc = new uc_XemThuoc();
            xemthuoc.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(xemthuoc);
        }

        private void btnProfilde_Click(object sender, EventArgs e)
        {
            uc_proNv profi = new uc_proNv();
            profi.Dock = DockStyle.Fill;
            panel1 .Controls.Clear();
            panel1.Controls.Add(profi);
        }
    }
}
