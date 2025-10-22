using QuanLyQuayThuoc.sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuayThuoc.User
{
    public partial class uc_proNv : UserControl
    {   private ModelSQL db = new ModelSQL();

    

        public uc_proNv()
        {
            InitializeComponent();
        }
        public void loaddata()
        {
            var user = db.People.FirstOrDefault(p => p.UserID == CurrentUser.UserID);
            if (user != null)
            {
                txtUserID.Text = user.UserID;
                txtFullName.Text = user.FullName;   
            }
        }

        private void uc_proNv_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
