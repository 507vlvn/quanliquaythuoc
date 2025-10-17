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

namespace QuanLyQuayThuoc.User
{
    public partial class uc_BaoCaoDonHang : UserControl
    {  
        private ModelSQL db = new ModelSQL();
        public uc_BaoCaoDonHang()
        {
            InitializeComponent();
        }
        private void uc_BaoCaoDonHang_Load(object sender, EventArgs e)
        {
            try
            {
                var listChiTietHoaDon = db.ChiTietHoaDons;
                dgvQuanLiHoaDon.DataSource = listChiTietHoaDon.ToList();
                dgvQuanLiHoaDon.Columns["HoaDon"].Visible = false;
                dgvQuanLiHoaDon.Columns["Thuoc"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu","Thong Bao",MessageBoxButtons.OK);
            }
        }
    }
}
