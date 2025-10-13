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
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
            return;
        }

        private void addControlsToPanel(Control c)
        {
            panel1.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panel1.Controls.Add(c);
        }
                private void btnOder_Click(object sender, EventArgs e)
            {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is uc_Dashbord)
                {
                    panel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                    break;
                }
            }
            uc_BanThuoc uc_BanThuoc = new uc_BanThuoc();
            addControlsToPanel(uc_BanThuoc);
        }

        private void btnKiemTraDonHang_Click(object sender, EventArgs e)
        {

            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is uc_Dashbord)
                {
                    panel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                    break;
                }
            }
            uc_BaoCaoDonHang uc_BaoCaoDonHang = new uc_BaoCaoDonHang();
            addControlsToPanel(uc_BaoCaoDonHang);
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is uc_Dashbord)
                {
                    panel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                    break;
                }
            }
          uc_XemThuoc uc_XemThuoc = new uc_XemThuoc();
            addControlsToPanel(uc_XemThuoc);
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is uc_Dashbord)
                {
                    panel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                    break;
                }
            }
            uc_proNv uc_ProNv = new uc_proNv(); 
            addControlsToPanel(uc_ProNv);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }
    }
}
