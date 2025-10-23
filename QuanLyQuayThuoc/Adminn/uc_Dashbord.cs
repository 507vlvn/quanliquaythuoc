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
using System.Windows.Ink;

namespace QuanLyQuayThuoc.Adminn
{
    public partial class uc_Dashbord : UserControl
    {
        private ModelSQL db = new ModelSQL();
        public uc_Dashbord()
        {
            InitializeComponent();
        }
       
        private void HienThiTongDoanhThu()
        {
            try
            {
               
                decimal tongDoanhThu = db.HoaDons
                    .Where(hd => hd.Tong_Tien != 0)
                    .Sum(hd => (decimal?)hd.Tong_Tien) ?? 0;

                btnDoanhThu.Text = $"Doanh Thu: {tongDoanhThu:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng doanh thu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TongSoHoaDon()
        {
            try
            {
                int tongSoHoaDon = db.HoaDons
                .Select(hd => hd.Ma_hoa_don)
                .Distinct()
                .Count();
                btnTongHoaDon.Text =$"Tổng Hóa Đơn: {tongSoHoaDon:N0}" ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng số hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkHSD()
        {
            try
            {
                var today = DateTime.Now.Date;
                var futureDate = today.AddDays(30);

                var expiringMedicines = db.Thuocs
                    .Where(med => med.Ngay_het_han >= today && med.Ngay_het_han <= futureDate)
                    .ToList();

                btnHSD.Text = $"Thuốc sắp hết hạn: {expiringMedicines.Count}";
                btnHSD.FillColor = Color.OrangeRed;
                btnHSD.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra hạn sử dụng thuốc: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
        private void TongNhanVien()
        {
            try
            {
                    int tongNhanVien = db.People
                    .Where(nv => nv.Role.Role1.ToLower() == "Staff" || nv.Role.Role1.ToLower() == "Admin")
                    .Count();

                btnTNV.Text = $"Tổng Nhân Viên: {tongNhanVien}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng nhân viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void uc_Dashbord_Load(object sender, EventArgs e)
        {
            HienThiTongDoanhThu();
            TongSoHoaDon();
            TongNhanVien();
            uc_ChartNgang1.Refresh();
            uc_ChartTron1.Refresh();
            checkHSD();

        }

        private void btnTongNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Refresh all charts in the dashboard
        /// </summary>
        public void RefreshAllCharts()
        {
            try
            {
       
                uc_ChartTron1?.RefreshChart();
            }
            catch (Exception ex)
            {
                // Silently handle any refresh errors
                System.Diagnostics.Debug.WriteLine($"Error refreshing charts: {ex.Message}");
            }
        }

        private void btnHSD_DoubleClick(object sender, EventArgs e)
        {
            uc_Product uc_Product = new uc_Product();
            Panel parentPanel = this.Parent as Panel;




            parentPanel.Controls.Clear();
            parentPanel.Controls.Add(uc_Product);

        }

        private void btnHSD_TextChanged(object sender, EventArgs e)
        {

        }
    }
 } 

