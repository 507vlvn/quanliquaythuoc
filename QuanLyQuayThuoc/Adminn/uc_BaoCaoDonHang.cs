using QuanLyQuayThuoc.sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Ink;

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
            LoadData();
            ConfigureDataGridView();
            fllcbbUser();
            if (CurrentUser.Role != "Admin")
            {
                //btndelete.Enabled = false; // Vô hiệu hóa nút xóa nếu không phải Admin
                btndelete.Visible = false;
            }
        }

        private void ConfigureDataGridView()
        {
            dgvQuanLiHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuanLiHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuanLiHoaDon.ReadOnly = true;
            dgvQuanLiHoaDon.MultiSelect = true;
            dgvQuanLiHoaDon.AllowUserToAddRows = false;
            
            // Định dạng tiền tệ cho cột Tổng Tiền nếu có
            if (dgvQuanLiHoaDon.Columns["Tong_Tien"] != null)
            {
                dgvQuanLiHoaDon.Columns["Tong_Tien"].DefaultCellStyle.Format = "N0";
                dgvQuanLiHoaDon.Columns["Tong_Tien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void fllcbbUser()
        {
            if (!string.IsNullOrEmpty(CurrentUser.UserID))
            {
                var currentUser = db.People
                    .Where(p => p.UserID == CurrentUser.UserID)
                    .Select(p => new
                    {
                        p.UserID,
                        p.FullName
                    })
                    .FirstOrDefault();

                if (currentUser != null)
                {
                    LabUs.Text = "User: " + currentUser.FullName;

                }
            }
        }
        
        private void LoadData()
        {
            try
            {
                var list = db.HoaDons
                    .Select(hd => new
                    {
                        Ma_Hoa_Don = hd.Ma_hoa_don,
                        Ngay_Ban = hd.Ngay_ban,
                        So_Dien_Thoai = hd.So_Dien_Thoai,
                        Tong_Tien = hd.Tong_Tien,
                        So_San_Pham = hd.ChiTietHoaDons.Count()
                    })
                    .OrderByDescending(hd => hd.Ngay_Ban)
                    .ToList();

                dgvQuanLiHoaDon.DataSource = list;

                // Đặt tên hiển thị cho các cột
                if (dgvQuanLiHoaDon.Columns["Ma_Hoa_Don"] != null)
                    dgvQuanLiHoaDon.Columns["Ma_Hoa_Don"].HeaderText = "Mã Hóa Đơn";
                
                if (dgvQuanLiHoaDon.Columns["Ngay_Ban"] != null)
                {
                    dgvQuanLiHoaDon.Columns["Ngay_Ban"].HeaderText = "Ngày Bán";
                    dgvQuanLiHoaDon.Columns["Ngay_Ban"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                
                if (dgvQuanLiHoaDon.Columns["So_Dien_Thoai"] != null)
                    dgvQuanLiHoaDon.Columns["So_Dien_Thoai"].HeaderText = "Số Điện Thoại";
                
                if (dgvQuanLiHoaDon.Columns["Tong_Tien"] != null)
                {
                    dgvQuanLiHoaDon.Columns["Tong_Tien"].HeaderText = "Tổng Tiền (VNĐ)";
                    dgvQuanLiHoaDon.Columns["Tong_Tien"].DefaultCellStyle.Format = "N0";
                    dgvQuanLiHoaDon.Columns["Tong_Tien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                
                if (dgvQuanLiHoaDon.Columns["So_San_Pham"] != null)
                {
                    dgvQuanLiHoaDon.Columns["So_San_Pham"].HeaderText = "Số Sản Phẩm";
                    dgvQuanLiHoaDon.Columns["So_San_Pham"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Tính tổng doanh thu
                decimal tongDoanhThu = list.Sum(x => x.Tong_Tien);
                int tongSoDonHang = list.Count;
                HienThiTongDoanhThu();
                HienThiTongSoDonHang();

                // Hiển thị thống kê (nếu có label)
                // lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} VNĐ";
                // lblTongDonHang.Text = $"Tổng số đơn hàng: {tongSoDonHang}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    LoadData();
                    return;
                }

                var result = db.HoaDons
                    .Where(hd =>
                        hd.Ma_hoa_don.ToLower().Contains(keyword) ||
                        hd.So_Dien_Thoai.Contains(keyword))
                    .Select(hd => new
                    {
                        Ma_Hoa_Don = hd.Ma_hoa_don,
                        Ngay_Ban = hd.Ngay_ban,
                        So_Dien_Thoai = hd.So_Dien_Thoai,
                        Tong_Tien = hd.Tong_Tien,
                        So_San_Pham = hd.ChiTietHoaDons.Count()
                    })
                    .OrderByDescending(hd => hd.Ngay_Ban)
                    .ToList();

                dgvQuanLiHoaDon.DataSource = result;

                // Đặt lại format cho các cột sau khi search
                if (dgvQuanLiHoaDon.Columns["Ngay_Ban"] != null)
                    dgvQuanLiHoaDon.Columns["Ngay_Ban"].DefaultCellStyle.Format = "dd/MM/yyyy";
                
                if (dgvQuanLiHoaDon.Columns["Tong_Tien"] != null)
                {
                    dgvQuanLiHoaDon.Columns["Tong_Tien"].DefaultCellStyle.Format = "N0";
                    dgvQuanLiHoaDon.Columns["Tong_Tien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvQuanLiHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một hóa đơn để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa {dgvQuanLiHoaDon.SelectedRows.Count} hóa đơn đã chọn?\n" +
                "Thao tác này sẽ xóa cả chi tiết hóa đơn và không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int successCount = 0;
                    int failCount = 0;

                    foreach (DataGridViewRow row in dgvQuanLiHoaDon.SelectedRows)
                    {
                        try
                        {
                            string maHoaDon = row.Cells["Ma_Hoa_Don"].Value.ToString();

                            // Xóa chi tiết hóa đơn trước
                            var chiTietList = db.ChiTietHoaDons
                                .Where(ct => ct.Ma_Hoa_Don == maHoaDon)
                                .ToList();

                            foreach (var chiTiet in chiTietList)
                            {
                                db.ChiTietHoaDons.Remove(chiTiet);
                            }

                            // Xóa hóa đơn
                            var hoaDon = db.HoaDons.FirstOrDefault(hd => hd.Ma_hoa_don == maHoaDon);
                            if (hoaDon != null)
                            {
                                db.HoaDons.Remove(hoaDon);
                                successCount++;
                            }
                        }
                        catch
                        {
                            failCount++;
                        }
                    }

                    db.SaveChanges();
                    if (failCount > 0)
                    {
                        MessageBox.Show(
                            $"Đã xóa thành công {successCount} hóa đơn.\n" +
                            $"Không thể xóa {failCount} hóa đơn.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Đã xóa thành công {successCount} hóa đơn!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    

        // Thêm event double click để xem chi tiết
   

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

        //// Thêm phương thức lọc theo ngày (nếu có DateTimePicker)
        //private void FilterByDate(DateTime? tuNgay, DateTime? denNgay)
        //{
        //    try
        //    {
        //        var query = db.HoaDons.AsQueryable();

        //        if (tuNgay.HasValue)
        //        {
        //            query = query.Where(hd => hd.Ngay_ban >= tuNgay.Value);
        //        }

        //        if (denNgay.HasValue)
        //        {
        //            DateTime endDate = denNgay.Value.Date.AddDays(1).AddSeconds(-1);
        //            query = query.Where(hd => hd.Ngay_ban <= endDate);
        //        }

        //        var result = query
        //            .Select(hd => new
        //            {
        //                Ma_Hoa_Don = hd.Ma_hoa_don,
        //                Ngay_Ban = hd.Ngay_ban,
        //                So_Dien_Thoai = hd.So_Dien_Thoai,
        //                Tong_Tien = hd.Tong_Tien,
        //                So_San_Pham = hd.ChiTietHoaDons.Count()
        //            })
        //            .OrderByDescending(hd => hd.Ngay_Ban)
        //            .ToList();

        //        dgvQuanLiHoaDon.DataSource = result;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi lọc theo ngày: {ex.Message}", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void dgvQuanLiHoaDon_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    string maHoaDon = dgvQuanLiHoaDon.Rows[e.RowIndex].Cells["Ma_Hoa_Don"].Value.ToString();
                    XemChiTietHoaDon(maHoaDon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xem chi tiết: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HienThiTongDoanhThu()
        {
            try
            {
                decimal tongDoanhThu = db.HoaDons
                    .Where(hd => hd.Tong_Tien != null)
                    .Sum(hd => (decimal?)hd.Tong_Tien) ?? 0;
                
                lbTongDoanhThu.Text = $"{tongDoanhThu:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng doanh thu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiTongSoDonHang()
        {
            try
            {
                int tonghoadon= db.HoaDons
                .Select(hd => hd.Ma_hoa_don)
                .Distinct()
                .Count();
                lbTongHoaDon.Text = tonghoadon.ToString("N0");
            }
            catch (Exception)
            {

                MessageBox.Show($"Lỗi khi tính tổng số đơn hàng: ", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LabUs_Click(object sender, EventArgs e)
        {

        }
    }
}
