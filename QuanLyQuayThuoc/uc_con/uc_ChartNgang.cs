using LiveCharts;
using LiveCharts.Wpf;
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

namespace QuanLyQuayThuoc.uc_con
{
    public partial class uc_ChartNgang : UserControl
    {
        private ModelSQL db = new ModelSQL();

        public uc_ChartNgang()
        {
            InitializeComponent();
            InitializeChart();
        }


        private void uc_ChartNgang_Load(object sender, EventArgs e)
        {
            LoadMonthlyRevenueChart();
        }
        private void InitializeChart()
        {

            cartesianChart1.Background = System.Windows.Media.Brushes.White;
        }

 
        private void ResetChartBackground()
        {
            try
            {

                cartesianChart1.Background = System.Windows.Media.Brushes.White;
                cartesianChart1.Update(true, true);
            }
            catch { }
        }

        private void LoadMonthlyRevenueChart()
        {
            try
            {
                // Lấy tháng và năm hiện tại
                DateTime now = DateTime.Now;
                LoadRevenueChart(now.Month, now.Year);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ doanh thu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức tải doanh thu theo tháng và năm tùy chỉnh
        public void LoadRevenueChart(int thang, int nam)
        {
            try
            {
                // Lấy số ngày trong tháng
                int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);

                // Lấy dữ liệu doanh thu từ database
                var doanhThuTheoNgay = db.HoaDons
                    .Where(hd => hd.Ngay_ban.Month == thang && hd.Ngay_ban.Year == nam)
                    .GroupBy(hd => hd.Ngay_ban.Day)
                    .Select(g => new
                    {
                        Ngay = g.Key,
                        DoanhThu = g.Sum(hd => hd.Tong_Tien),
                        SoHoaDon = g.Count()
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                // Chuẩn bị dữ liệu cho biểu đồ
                var doanhThuValues = new List<double>();
                var labels = new List<string>();

                for (int ngay = 1; ngay <= soNgayTrongThang; ngay++)
                {
                    var doanhThu = doanhThuTheoNgay.FirstOrDefault(d => d.Ngay == ngay);
                    decimal giaTriDoanhThu = doanhThu?.DoanhThu ?? 0;

                    doanhThuValues.Add((double)giaTriDoanhThu);
                    labels.Add(ngay.ToString());
                }

                // Cấu hình biểu đồ cột dọc
                cartesianChart1.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Doanh Thu Tháng " + thang + "/" + nam,
                        Values = new ChartValues<double>(doanhThuValues),
                        Fill = System.Windows.Media.Brushes.CornflowerBlue,
                        DataLabels = soNgayTrongThang <= 31,
                        LabelPoint = point => point.Y > 0 ? (point.Y / 1000).ToString("N0") + "k" : "",
                        MaxColumnWidth = 30
                    }
                };

                // Cấu hình trục X (ngày)
                cartesianChart1.AxisX = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Ngày",
                        Labels = labels,
                        Separator = new Separator
                        {
                            Step = soNgayTrongThang > 31 ? 2 : 1,
                            IsEnabled = false
                        }
                    }
                };

                // Cấu hình trục Y (doanh thu)
                cartesianChart1.AxisY = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Doanh Thu (VNĐ)",
                        LabelFormatter = value => (value / 1000000).ToString("N0") + "M",
                        MinValue = 0,
                        Separator = new Separator
                        {
                            Stroke = System.Windows.Media.Brushes.LightGray,
                            StrokeThickness = 1
                        }
                    }
                };

                cartesianChart1.LegendLocation = LegendLocation.Top;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ doanh thu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức tải biểu đồ theo khoảng thời gian
        public void LoadRevenueChartByDateRange(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                if (tuNgay > denNgay)
                {
                    var temp = tuNgay;
                    tuNgay = denNgay;
                    denNgay = temp;
                }

                tuNgay = tuNgay.Date;
                denNgay = denNgay.Date.AddDays(1).AddSeconds(-1);

                int soNgay = (int)(denNgay.Date - tuNgay.Date).TotalDays;

                var doanhThuTheoNgay = db.HoaDons
                    .Where(hd => hd.Ngay_ban >= tuNgay && hd.Ngay_ban <= denNgay)
                    .GroupBy(hd => new { hd.Ngay_ban.Year, hd.Ngay_ban.Month, hd.Ngay_ban.Day })
                    .Select(g => new
                    {
                        Nam = g.Key.Year,
                        Thang = g.Key.Month,
                        Ngay = g.Key.Day,
                        DoanhThu = g.Sum(hd => hd.Tong_Tien),
                        SoHoaDon = g.Count()
                    })
                    .OrderBy(x => x.Nam).ThenBy(x => x.Thang).ThenBy(x => x.Ngay)
                    .ToList();

                var doanhThuValues = new List<double>();
                var labels = new List<string>();

                DateTime currentDate = tuNgay.Date;
                while (currentDate <= denNgay.Date)
                {
                    var doanhThu = doanhThuTheoNgay.FirstOrDefault(d =>
                        d.Ngay == currentDate.Day &&
                        d.Thang == currentDate.Month &&
                        d.Nam == currentDate.Year);

                    decimal giaTriDoanhThu = doanhThu?.DoanhThu ?? 0;
                    doanhThuValues.Add((double)giaTriDoanhThu);
                    labels.Add(currentDate.ToString("dd/MM"));

                    currentDate = currentDate.AddDays(1);
                }

                cartesianChart1.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = $"Doanh Thu ({tuNgay:dd/MM/yyyy} - {denNgay.Date:dd/MM/yyyy})",
                        Values = new ChartValues<double>(doanhThuValues),
                        Fill = System.Windows.Media.Brushes.SteelBlue,
                        DataLabels = soNgay <= 31,
                        LabelPoint = point => point.Y > 0 ? (point.Y / 1000000).ToString("N1") + "M" : "",
                        MaxColumnWidth = 40
                    }
                };

                cartesianChart1.AxisX = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Ngày",
                        Labels = labels,
                        Separator = new Separator { Step = soNgay > 31 ? 2 : 1, IsEnabled = false },
                        LabelsRotation = soNgay > 15 ? 45 : 0
                    }
                };

                cartesianChart1.AxisY = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Doanh Thu (VNĐ)",
                        LabelFormatter = value => (value / 1000000).ToString("N0") + "M",
                        Separator = new Separator { Stroke = System.Windows.Media.Brushes.LightGray }
                    }
                };

                cartesianChart1.LegendLocation = LegendLocation.Top;
                ResetChartBackground();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uc_ChartNgang_Load_1(object sender, EventArgs e)
        {
            LoadMonthlyRevenueChart();
        }

      

    }
}
