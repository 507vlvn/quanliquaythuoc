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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
         
        private void btnLogOut_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
            return;
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            uC_DashB1.Visible = false;
            uc_adduse1.Visible = false;
          
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uC_DashB1.Visible=true;
            uc_adduse1.Visible = false;
            uC_DashB1.BringToFront();
        }

        private void uC_DashB1_Load(object sender, EventArgs e)
        {

        }

        private void btmaddser_Click(object sender, EventArgs e)
        {
            uC_DashB1.Visible = false;
       uc_adduse1.Visible = true;
        }
    }
}
