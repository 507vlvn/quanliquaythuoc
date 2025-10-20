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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyQuayThuoc.uc_con
{
    public partial class uc_ChartNgang : UserControl
    {
        private ModelSQL db = new ModelSQL();

        public uc_ChartNgang()
        {
            InitializeComponent();
        }

        private void uc_ChartNgang_Load(object sender, EventArgs e)
        {
            LoadMonthlyRevenueChart();
        }

        private void LoadMonthlyRevenueChart()
        {
            try
            {
                // Lấy tháng và năm hiện tại
                DateTime now = DateTime.Now;
                int thang = now.Month;
                int nam = now.Year;

                // Lấy số ngày trong tháng
                int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);

                // Lấy dữ liệu doanh thu từ database
                var doanhThuTheoNgay = db.HoaDons
                    .Where(hd => hd.Ngay_ban.Month == thang && hd.Ngay_ban.Year == nam)
                    .GroupBy(hd => hd.Ngay_ban.Day)
                    .Select(g => new
                    {
                        Ngay = g.Key,
                        DoanhThu = g.Sum(hd => hd.Tong_Tien)
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                // Xóa series cũ
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();

                // Tạo ChartArea mới
                ChartArea chartArea = new ChartArea("MainArea");
                chartArea.AxisX.Title = "Ngày";
                chartArea.AxisY.Title = "Doanh Thu (VNĐ)";
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.Minimum = 1;
                chartArea.AxisX.Maximum = soNgayTrongThang;
                chartArea.AxisY.LabelStyle.Format = "N0";
                chartArea.BackColor = Color.White;
                chart1.ChartAreas.Add(chartArea);

                // Tạo Legend
                Legend legend = new Legend("MainLegend");
                legend.Docking = Docking.Top;
                legend.Alignment = StringAlignment.Center;
                chart1.Legends.Add(legend);

                // Tạo Series cho biểu đồ cột dọc
                Series series = new Series("Doanh Thu Tháng " + thang + "/" + nam);
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.FromArgb(100, 149, 237); // CornflowerBlue
                series.BorderWidth = 2;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";

                // Thêm dữ liệu cho tất cả các ngày trong tháng
                for (int ngay = 1; ngay <= soNgayTrongThang; ngay++)
                {
                    var doanhThu = doanhThuTheoNgay.FirstOrDefault(d => d.Ngay == ngay);
                    decimal giaTriDoanhThu = doanhThu?.DoanhThu ?? 0;

                    DataPoint point = new DataPoint(ngay, (double)giaTriDoanhThu);

                    // Tô màu khác cho ngày có doanh thu cao
                    if (giaTriDoanhThu > 0)
                    {
                        var maxDoanhThu = doanhThuTheoNgay.Max(d => d.DoanhThu);
                        if (giaTriDoanhThu == maxDoanhThu)
                        {
                            point.Color = Color.FromArgb(46, 204, 113); // Xanh lá cho ngày cao nhất
                        }
                    }
                    else
                    {
                        point.Color = Color.LightGray; // Màu xám cho ngày không có doanh thu
                    }

                    series.Points.Add(point);
                }

                chart1.Series.Add(series);

                // Cập nhật tiêu đề
                chart1.Titles.Clear();
                Title title = new Title("BIỂU ĐỒ DOANH THU THÁNG " + thang + "/" + nam);
                title.Font = new Font("Arial", 14, FontStyle.Bold);
                title.ForeColor = Color.DarkSlateBlue;
                chart1.Titles.Add(title);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ doanh thu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức để tải doanh thu theo tháng và năm tùy chỉnh
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
                        DoanhThu = g.Sum(hd => hd.Tong_Tien)
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                // Xóa series cũ
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();

                // Tạo ChartArea mới
                ChartArea chartArea = new ChartArea("MainArea");
                chartArea.AxisX.Title = "Ngày";
                chartArea.AxisY.Title = "Doanh Thu (VNĐ)";
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.Minimum = 1;
                chartArea.AxisX.Maximum = soNgayTrongThang;
                chartArea.AxisY.LabelStyle.Format = "N0";
                chartArea.BackColor = Color.White;
                chart1.ChartAreas.Add(chartArea);

                // Tạo Legend
                Legend legend = new Legend("MainLegend");
                legend.Docking = Docking.Top;
                legend.Alignment = StringAlignment.Center;
                chart1.Legends.Add(legend);

                // Tạo Series cho biểu đồ cột dọc
                Series series = new Series("Doanh Thu Tháng " + thang + "/" + nam);
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.FromArgb(100, 149, 237); // CornflowerBlue
                series.BorderWidth = 2;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";

                // Thêm dữ liệu cho tất cả các ngày trong tháng
                for (int ngay = 1; ngay <= soNgayTrongThang; ngay++)
                {
                    var doanhThu = doanhThuTheoNgay.FirstOrDefault(d => d.Ngay == ngay);
                    decimal giaTriDoanhThu = doanhThu?.DoanhThu ?? 0;

                    DataPoint point = new DataPoint(ngay, (double)giaTriDoanhThu);

                    // Tô màu khác cho ngày có doanh thu cao
                    if (giaTriDoanhThu > 0)
                    {
                        var maxDoanhThu = doanhThuTheoNgay.Max(d => d.DoanhThu);
                        if (giaTriDoanhThu == maxDoanhThu)
                        {
                            point.Color = Color.FromArgb(46, 204, 113); // Xanh lá cho ngày cao nhất
                        }
                    }
                    else
                    {
                        point.Color = Color.LightGray; // Màu xám cho ngày không có doanh thu
                    }

                    series.Points.Add(point);
                }

                chart1.Series.Add(series);

                // Cập nhật tiêu đề
                chart1.Titles.Clear();
                Title title = new Title("BIỂU ĐỒ DOANH THU THÁNG " + thang + "/" + nam);
                title.Font = new Font("Arial", 14, FontStyle.Bold);
                title.ForeColor = Color.DarkSlateBlue;
                chart1.Titles.Add(title);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ doanh thu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void uc_ChartNgang_Load_1(object sender, EventArgs e)
        {
            LoadMonthlyRevenueChart();
            //LoadRevenueChart(10, 2025);
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
