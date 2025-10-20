using LiveCharts;
using LiveCharts.Wpf;
using QuanLyQuayThuoc.sql;
using QuanLyQuayThuoc.uc_con;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuayThuoc.uc_con
{
    public partial class uc_ChartTron : UserControl
    {
        private ModelSQL db = new ModelSQL();

        public uc_ChartTron()
        {
            InitializeComponent();
        }

        private void uc_ChartTron_Load(object sender, EventArgs e)
        {
            LoadTopProductsChart();
        }

        /// <summary>
        /// Tải biểu đồ Top 5 sản phẩm bán chạy nhất
        /// </summary>
        private void LoadTopProductsChart()
        {
            try
            {
                // Lấy dữ liệu top 5 sản phẩm bán chạy
                var topProducts = db.ChiTietHoaDons
                    .GroupBy(ct => new { ct.Ma_san_pham, ct.Thuoc.Ten_san_pham })
                    .Select(g => new
                    {
                        MaSanPham = g.Key.Ma_san_pham,
                        TenSanPham = g.Key.Ten_san_pham,
                        TongSoLuong = g.Sum(ct => ct.So_luong),
                        DoanhThu = g.Sum(ct => ct.Thanh_Tien)
                    })
                    .OrderByDescending(x => x.TongSoLuong)
                    .Take(5)
                    .ToList();

                if (!topProducts.Any())
                {
                    MessageBox.Show("Chưa có dữ liệu bán hàng để hiển thị!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2HtmlLabel2.Text = "Chưa có dữ liệu";
                    return;
                }

                // Chuẩn bị dữ liệu cho biểu đồ
                var tenSanPham = new List<string>();
                var soLuongBan = new List<int>();

                foreach (var product in topProducts)
                {
                    // Rút gọn tên sản phẩm nếu quá dài
                    string tenRutGon = product.TenSanPham.Length > 20
                        ? product.TenSanPham.Substring(0, 17) + "..."
                        : product.TenSanPham;

                    tenSanPham.Add(tenRutGon);
                    soLuongBan.Add(product.TongSoLuong);
                }

                // Cấu hình biểu đồ cột ngang (RowSeries)
                cartesianChart1.Series = new SeriesCollection
                {
                    new RowSeries
                    {
                        Title = "Số lượng đã bán",
                        Values = new ChartValues<int>(soLuongBan),
                        DataLabels = true,
                        Fill = System.Windows.Media.Brushes.MediumSeaGreen,
                        LabelPoint = point => $"{point.Y} viên",
                        MaxRowHeigth = 40
                    }
                };

                // Cấu hình trục X (số lượng)
                cartesianChart1.AxisX = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Số lượng bán ra",
                        LabelFormatter = value => value.ToString("N0"),
                        MinValue = 0,
                        Separator = new Separator
                        {
                            Stroke = System.Windows.Media.Brushes.LightGray,
                            StrokeThickness = 1
                        }
                    }
                };

                // Cấu hình trục Y (tên sản phẩm)
                cartesianChart1.AxisY = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Sản phẩm",
                        Labels = tenSanPham,
                        Separator = new Separator
                        {
                            Step = 1,
                            IsEnabled = false
                        }
                    }
                };

                // Cấu hình Legend
                cartesianChart1.LegendLocation = LegendLocation.Top;

                // Cập nhật tiêu đề
                guna2HtmlLabel2.Text = "Top 5 Sản Phẩm Bán Chạy";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ: {ex.Message}\n{ex.StackTrace}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải biểu đồ doanh thu theo tháng trong năm
        /// </summary>
        public void LoadRevenueByMonthChart(int nam)
        {
            try
            {
                var doanhThuTheoThang = db.HoaDons
                    .Where(hd => hd.Ngay_ban.Year == nam && hd.Tong_Tien > 0)
                    .GroupBy(hd => hd.Ngay_ban.Month)
                    .Select(g => new
                    {
                        Thang = g.Key,
                        DoanhThu = g.Sum(hd => hd.Tong_Tien)
                    })
                    .OrderBy(x => x.Thang)
                    .ToList();

                // Tạo mảng đầy đủ 12 tháng
                double[] doanhThuValues = new double[12];
                string[] labels = new string[12];

                for (int i = 1; i <= 12; i++)
                {
                    var dt = doanhThuTheoThang.FirstOrDefault(d => d.Thang == i);
                    doanhThuValues[i - 1] = (double)(dt?.DoanhThu ?? 0);
                    labels[i - 1] = "T" + i;
                }

                // Cấu hình biểu đồ cột dọc
                cartesianChart1.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Doanh Thu",
                        Values = new ChartValues<double>(doanhThuValues),
                        Fill = System.Windows.Media.Brushes.SteelBlue,
                        DataLabels = true,
                        LabelPoint = point => point.Y > 0 ? (point.Y / 1000000).ToString("N1") + "M" : "",
                        MaxColumnWidth = 30
                    }
                };

                cartesianChart1.AxisX = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Tháng",
                        Labels = labels,
                        Separator = new Separator
                        {
                            Step = 1,
                            IsEnabled = false
                        }
                    }
                };

                cartesianChart1.AxisY = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Doanh Thu (VNĐ)",
                        LabelFormatter = value => (value / 1000000).ToString("N0") + "M",
                        Separator = new Separator
                        {
                            Stroke = System.Windows.Media.Brushes.LightGray
                        }
                    }
                };

                cartesianChart1.LegendLocation = LegendLocation.Top;
                guna2HtmlLabel2.Text = $"Doanh Thu Năm {nam}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ doanh thu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải biểu đồ số lượng hóa đơn theo tháng
        /// </summary>
        public void LoadInvoiceCountByMonthChart(int nam)
        {
            try
            {
                var hoaDonTheoThang = db.HoaDons
                    .Where(hd => hd.Ngay_ban.Year == nam)
                    .GroupBy(hd => hd.Ngay_ban.Month)
                    .Select(g => new
                    {
                        Thang = g.Key,
                        SoLuong = g.Count()
                    })
                    .OrderBy(x => x.Thang)
                    .ToList();

                int[] soLuongValues = new int[12];
                string[] labels = new string[12];

                for (int i = 1; i <= 12; i++)
                {
                    var sl = hoaDonTheoThang.FirstOrDefault(d => d.Thang == i);
                    soLuongValues[i - 1] = sl?.SoLuong ?? 0;
                    labels[i - 1] = "T" + i;
                }

                cartesianChart1.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Số Hóa Đơn",
                        Values = new ChartValues<int>(soLuongValues),
                        Fill = System.Windows.Media.Brushes.Orange,
                        DataLabels = true,
                        MaxColumnWidth = 30
                    }
                };

                cartesianChart1.AxisX = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Tháng",
                        Labels = labels
                    }
                };

                cartesianChart1.AxisY = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Số lượng hóa đơn",
                        LabelFormatter = value => value.ToString("N0")
                    }
                };

                cartesianChart1.LegendLocation = LegendLocation.Top;
                guna2HtmlLabel2.Text = $"Số Hóa Đơn Năm {nam}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Làm mới biểu đồ
        /// </summary>
        public void RefreshChart()
        {
            LoadTopProductsChart();
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            // Event handler cho CartesianChart
        }
    }
}
// Hiển thị doanh thu năm 2025
//uc_ChartTron1.LoadRevenueByMonthChart(2025);

//// Hiển thị số hóa đơn năm 2025
//uc_ChartTron1.LoadInvoiceCountByMonthChart(2025);

//// Quay về biểu đồ mặc định
//uc_ChartTron1.RefreshChart();