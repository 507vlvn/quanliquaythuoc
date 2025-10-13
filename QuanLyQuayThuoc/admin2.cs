using QuanLyQuayThuoc.Adminn;
using QuanLyQuayThuoc.User;
using System;
using System.Windows.Forms;

namespace QuanLyQuayThuoc
{
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }

        private void admin2_Load(object sender, EventArgs e)
        {
            uc_Dashbord uc_Dashbord = new uc_Dashbord();
            panel1.Controls.Add(uc_Dashbord);
        }
        private void addControlsToPanel(Control c)
        {
            panel1.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panel1.Controls.Add(c);
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void btnDashbord_Click(object sender, EventArgs e)
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
            uc_Dashbord dashbord = new uc_Dashbord();
            addControlsToPanel(dashbord);
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
            uc_User user = new uc_User();
            addControlsToPanel(user);
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
                uc_Product uc_Product = new uc_Product();
                addControlsToPanel(uc_Product);
            }
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }    
}
