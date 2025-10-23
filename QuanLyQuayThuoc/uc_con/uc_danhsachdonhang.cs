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

namespace QuanLyQuayThuoc.Adminn
{
    public partial class uc_danhsachdonhang : UserControl
    {  private ModelSQL db = new ModelSQL();
        public uc_danhsachdonhang()
        {
            InitializeComponent();
        }
        private void LoadDanhSachHoaDon()
        {
            try
            {
                var danhSachHoaDon = db.HoaDons
                    .Select(hd => new
                    {
                        hd.Ma_hoa_don,
                        hd.Ngay_ban,
                        hd.So_Dien_Thoai,
                        hd.Tong_Tien
                    })
                    .ToList();
                dgvQuanLiHoaDon.DataSource = danhSachHoaDon;
                dgvQuanLiHoaDon.Columns["Ma_hoa_don"].HeaderText = "Mã Hóa Đơn";
                dgvQuanLiHoaDon.Columns["Ngay_ban"].HeaderText = "Ngày Bán";
                dgvQuanLiHoaDon.Columns["So_Dien_Thoai"].HeaderText = "Số Điện Thoại";
                dgvQuanLiHoaDon.Columns["Tong_Tien"].HeaderText = "Tổng Tiền (VNĐ)";
                dgvQuanLiHoaDon.Columns["Tong_Tien"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void uc_danhsachdonhang_Load_1(object sender, EventArgs e)
        {
            LoadDanhSachHoaDon();

        }
    }
}
