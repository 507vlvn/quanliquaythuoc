using QuanLyQuayThuoc.Adminn;
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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }

        private void admin2_Load(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();

            uc_prof prof = new uc_prof();
            prof.Visible = false;


         

            return;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uc_prof prof = new uc_prof();
            prof.Visible = true;
        }
    }
}
