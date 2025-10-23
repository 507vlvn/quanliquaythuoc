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
          
          
      

            uc_ChartNgang1.LoadRevenueChartByDateRange(dateStart.Value, dateEnd.Value);
        }

        private void uc_ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            hienthi();
            dateStart.Value = DateTime.Now.Date.AddDays(-30);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {

            uc_ChartNgang1.LoadRevenueChartByDateRange(dateStart.Value, dateEnd.Value);
            uc_ChartNgang1.Refresh();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            
            uc_ChartNgang1.LoadRevenueChartByDateRange(dateStart.Value, dateEnd.Value);
            uc_ChartNgang1.Refresh();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
