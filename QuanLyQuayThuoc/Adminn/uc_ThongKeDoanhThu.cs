using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuayThuoc.sql;

namespace QuanLyQuayThuoc.Adminn
{
    public partial class uc_ThongKeDoanhThu : UserControl
    {
        ModelSQL db = new ModelSQL();
        public uc_ThongKeDoanhThu()

        {
            ModelSQL db = new ModelSQL();
            InitializeComponent();
        }

        private void uc_ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            hienthi();
        }
        private void hienthi()
        {
            var list = db.HoaDons.Select(p => new
            {
                p.Ma_hoa_don,
                p.Ngay_ban,
                p.Tong_Tien
                
            }).ToList();
            dgvdsthongke.DataSource = list;
            dgvdsthongke.Columns["Ma_hoa_don"].HeaderText = "Mã hóa đơn";
            dgvdsthongke.Columns["Ngay_ban"].HeaderText = "Ngày bán";
            dgvdsthongke.Columns["Tong_Tien"].HeaderText = "Tổng tiền";
            dgvdsthongke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
