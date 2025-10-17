using QuanLyQuayThuoc.SQL;
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
    {   private ModelSQL db = new ModelSQL();
        public uc_Product()
        {
            InitializeComponent();
            

        }

        private void uc_Product_Load(object sender, EventArgs e)
        {
            var listThuoc = db.Thuocs.ToList();
            dgvQLSP.DataSource = listThuoc;



        }
        private void dgvDsthuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
