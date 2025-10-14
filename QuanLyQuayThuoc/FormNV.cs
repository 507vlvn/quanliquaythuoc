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
            uc_BanThuoc1.Visible = true;
            uc_BaoCaoDonHang1.Visible = false;
            uc_XemThuoc1.Visible = false;
            uc_proNv1.Visible = false;
        }

        private void FormNV_Load(object sender, EventArgs e)
        {
            uc_BanThuoc1.Visible = false;
            uc_BaoCaoDonHang1.Visible = false;
            uc_XemThuoc1.Visible = false;
            uc_proNv1.Visible = false;
        }

        private void btnKiemTraDonHang_Click(object sender, EventArgs e)
        {
            uc_BaoCaoDonHang1.Visible = true;
            uc_BanThuoc1.Visible = false;
            uc_XemThuoc1.Visible = false;
            uc_proNv1.Visible = false;
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            uc_XemThuoc1.Visible=true;
            uc_BaoCaoDonHang1.Visible = false;
            uc_BanThuoc1.Visible = false;
            uc_proNv1.Visible = false;



        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            uc_proNv1.Visible=true;
            uc_XemThuoc1.Visible = false;
            uc_BaoCaoDonHang1.Visible = false;
            uc_BanThuoc1.Visible = false;
            
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm=new Form1();
            frm.ShowDialog();
            Application.Exit();
        }
    }
}
