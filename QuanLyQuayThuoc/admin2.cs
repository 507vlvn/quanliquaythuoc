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
            uc_Dashbord1.Visible = false;
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uc_Dashbord1.Visible = true;
        }
    }    
}
