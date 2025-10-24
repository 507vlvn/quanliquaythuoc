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
            dateStart.MinDate = DateTime.Now.AddMonths(-5);
            dateEnd.MaxDate = DateTime.Now.Date;
            loadccb();
            loadtongtien();

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

 
        private void XemChiTietHoaDon(string maHoaDon)
        {
            var hoaDon = db.HoaDons.FirstOrDefault(hd => hd.Ma_hoa_don == maHoaDon);
            if (hoaDon == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var chiTiet = db.ChiTietHoaDons
                .Where(ct => ct.Ma_Hoa_Don == maHoaDon)
                .Select(ct => new
                {
                    Ma_San_Pham = ct.Ma_san_pham,
                    Ten_San_Pham = ct.Thuoc.Ten_san_pham,
                    So_Luong = ct.So_luong,
                    So_Ngay_Uong = ct.So_Ngay_Uong,
                    Gia_Ban = ct.Gia_Ban,
                    Thanh_Tien = ct.Thanh_Tien
                })
                .ToList();

            string thongTin = $"===== CHI TIẾT HÓA ĐƠN =====\n\n";
            thongTin += $"Mã hóa đơn: {hoaDon.Ma_hoa_don}\n";
            thongTin += $"Ngày bán: {hoaDon.Ngay_ban:dd/MM/yyyy HH:mm}\n";
            thongTin += $"Số điện thoại: {hoaDon.So_Dien_Thoai}\n";
            thongTin += $"Tổng tiền: {hoaDon.Tong_Tien:N0} VNĐ\n\n";
            thongTin += "===== DANH SÁCH SẢN PHẨM =====\n\n";

            int stt = 1;
            foreach (var item in chiTiet)
            {
                thongTin += $"{stt}. {item.Ten_San_Pham}\n";
                thongTin += $"   Số lượng: {item.So_Luong}\n";
                thongTin += $"   Số ngày uống: {item.So_Ngay_Uong}\n";
                thongTin += $"   Giá bán: {item.Gia_Ban:N0} VNĐ\n";
                thongTin += $"   Thành tiền: {item.Thanh_Tien:N0} VNĐ\n\n";
                stt++;
            }

            MessageBox.Show(thongTin, "Chi tiết hóa đơn",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void loadccb() {
            guna2ComboBox1.Items.Add("Top 5 sp bán chạy nhất");
            guna2ComboBox1.Items.Add("Doanh thu theo năm");
            guna2ComboBox1.Items.Add("Số hóa đơn theo năm");
            guna2ComboBox1.SelectedIndex = 0;

        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chon loa tu cbb
            string selectedOption = guna2ComboBox1.SelectedItem.ToString();
            if (selectedOption == "Doanh thu theo năm")
            {
                // Hiển thị doanh thu năm 2025
                uc_ChartTron1.LoadRevenueByMonthChart(2025);
            }
            else if (selectedOption == "Số hóa đơn theo năm")
            {
                // Hiển thị số hóa đơn năm 2025
                uc_ChartTron1.LoadInvoiceCountByMonthChart(2025);
            }
            else
            {
                // Quay về biểu đồ mặc định
                uc_ChartTron1.RefreshChart();
            }

            // Hiển thị doanh thu năm 2025
            //uc_ChartTron1.LoadRevenueByMonthChart(2025);

            //// Hiển thị số hóa đơn năm 2025
            //uc_ChartTron1.LoadInvoiceCountByMonthChart(2025);
            //// Quay về biểu đồ mặc định
            //uc_ChartTron1.RefreshChart();
        }

        private void dgvdsthongke_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    string maHoaDon = dgvdsthongke.Rows[e.RowIndex].Cells["Ma_Hoa_Don"].Value.ToString();
                    XemChiTietHoaDon(maHoaDon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xem chi tiết: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void loadtongtien()
        {
            decimal tongtien = 0;
            foreach (DataGridViewRow row in dgvdsthongke.Rows)
            {
                tongtien += Convert.ToDecimal(row.Cells["Tong_Tien"].Value);
            }
            txttongtien.Text = string.Format("{0:N0} VNĐ", tongtien);
        }
    }
}
