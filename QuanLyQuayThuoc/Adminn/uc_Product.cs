using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuayThuoc.Adminn
{
    public partial class uc_Product : UserControl
    {
        public uc_Product()
        {
            InitializeComponent();
        }

        private void uc_Product_Load(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            List<DSThuoc> ds = db.DSThuocs.ToList();
            dgvDsthuoc.DataSource = ds;
        }
    }
}
