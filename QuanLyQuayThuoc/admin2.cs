using QuanLyQuayThuoc.Adminn;
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
            
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            
            //uc_prof prof = new uc_prof();
            //prof.Dock = DockStyle.Fill;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
          this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();

            this.Close();

        }
    }
}
