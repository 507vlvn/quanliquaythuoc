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

namespace QuanLyQuayThuoc.User
{

    public partial class uc_XemThuoc : UserControl
    {
        ModelSQL db = new ModelSQL();
        public uc_XemThuoc()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            // Tải dữ liệu thuốc và chọn các cột cần hiển thị
            dgvDsThuoc.DataSource = db.Thuocs
                .Select(t => new
                {
                    t.Ma_san_pham,
                    t.Ten_san_pham,
                    t.Thanh_phan,
                    t.Cong_dung,
                    t.Tac_dung_phu,
                    t.Nha_san_xuat,
                    t.So_Luong_ton,
                    t.Gia_ban,
                    t.Ngay_san_xuat,
                    t.Ngay_het_han
                })
                .ToList();
            dgvDsThuoc.Columns["Ma_san_pham"].HeaderText = "Mã thuốc";
            dgvDsThuoc.Columns["Ten_san_pham"].HeaderText = "Tên thuốc";
            dgvDsThuoc.Columns["Thanh_phan"].HeaderText = "Thành Phần";
            dgvDsThuoc.Columns["Cong_dung"].HeaderText = "Công Dụng";
            dgvDsThuoc.Columns["Tac_dung_phu"].HeaderText = "Tác dụng phụ";
            dgvDsThuoc.Columns["Nha_san_xuat"].HeaderText = "Nhà sản xuất";
            dgvDsThuoc.Columns["So_Luong_ton"].HeaderText = "Số Lượng Tồn";
            dgvDsThuoc.Columns["Gia_ban"].HeaderText = "Giá Bán";
            dgvDsThuoc.Columns["Ngay_san_xuat"].HeaderText = "Ngày sản Xuất";
            dgvDsThuoc.Columns["Ngay_het_han"].HeaderText = "Ngày hết hạn";
            dgvDsThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDsThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void uc_XemThuoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimkiem.Text.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    LoadData();
                    return;
                }

                var result = db.Thuocs
                    .Where(t =>
                        t.Ma_san_pham.ToLower().Contains(keyword) ||
                        t.Ten_san_pham.ToLower().Contains(keyword) ||
                        t.Thanh_phan.ToLower().Contains(keyword) ||
                        t.Cong_dung.ToLower().Contains(keyword) ||
                        t.Tac_dung_phu.ToLower().Contains(keyword) ||
                        t.Nha_san_xuat.ToLower().Contains(keyword) ||
                        t.So_Luong_ton.ToString().Contains(keyword) ||
                        t.Gia_ban.ToString().Contains(keyword) ||
                        t.Ngay_san_xuat.ToString().Contains(keyword) ||
                        t.Ngay_het_han.ToString().Contains(keyword)
                    )
                    .Select(t => new
                    {
                        t.Ma_san_pham,
                        t.Ten_san_pham,
                        t.Thanh_phan,
                        t.Cong_dung,
                        t.Tac_dung_phu,
                        t.Nha_san_xuat,
                        t.So_Luong_ton,
                        t.Gia_ban,
                        t.Ngay_san_xuat,
                        t.Ngay_het_han
                    })
                    .ToList();

                dgvDsThuoc.DataSource = result;

                dgvDsThuoc.Columns["Ma_san_pham"].HeaderText = "Mã thuốc";
                dgvDsThuoc.Columns["Ten_san_pham"].HeaderText = "Tên thuốc";
                dgvDsThuoc.Columns["Thanh_phan"].HeaderText = "Thành Phần";
                dgvDsThuoc.Columns["Cong_dung"].HeaderText = "Công Dụng";
                dgvDsThuoc.Columns["Tac_dung_phu"].HeaderText = "Tác dụng phụ";
                dgvDsThuoc.Columns["Nha_san_xuat"].HeaderText = "Nhà sản xuất";
                dgvDsThuoc.Columns["So_Luong_ton"].HeaderText = "Số Lượng Tồn";
                dgvDsThuoc.Columns["Gia_ban"].HeaderText = "Giá Bán";
                dgvDsThuoc.Columns["Ngay_san_xuat"].HeaderText = "Ngày sản Xuất";
                dgvDsThuoc.Columns["Ngay_het_han"].HeaderText = "Ngày hết hạn";

                // Format lại hiển thị
                if (dgvDsThuoc.Columns["Gia_ban"] != null)
                {
                    dgvDsThuoc.Columns["Gia_ban"].DefaultCellStyle.Format = "N0";
                    dgvDsThuoc.Columns["Gia_ban"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvDsThuoc.Columns["Ngay_san_xuat"] != null)
                    dgvDsThuoc.Columns["Ngay_san_xuat"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvDsThuoc.Columns["Ngay_het_han"] != null)
                    dgvDsThuoc.Columns["Ngay_het_han"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDsThuoc_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    string maHoaDon = dgvDsThuoc.Rows[e.RowIndex].Cells["Ma_san_pham"].Value.ToString();
                    XemChiTietHoaDon(maHoaDon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xem chi tiết: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void XemChiTietHoaDon(string masp)
        {

            var thuoc = db.Thuocs.FirstOrDefault(med => med.Ma_san_pham == masp);
                if (thuoc == null)
            {
                MessageBox.Show("Không tìm thấy thuốc!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var chiTiet = db.ChiTietHoaDons
            .Where(ct => ct.Ma_san_pham == masp)
            .Select(ct => new
            {
                Ma_San_Pham = ct.Ma_san_pham,
                Ten_San_Pham = ct.Thuoc.Ten_san_pham,
                So_Luong = ct.So_luong,
                So_Ngay_Uong = ct.So_Ngay_Uong,
                Gia_Ban = ct.Gia_Ban,
                Thanh_Tien = ct.Thanh_Tien
            }).ToList();

            string thongTin = $"===== CHI TIẾT THUỐC =====\n\n";
            thongTin += $"Mã thuốc: {thuoc.Ma_san_pham}\n";
            thongTin += $"Tên thuốc: {thuoc.Ten_san_pham}\n";
            thongTin += $"Thành phần: {thuoc.Thanh_phan}\n";
            thongTin += $"Công dụng: {thuoc.Cong_dung}\n";
            thongTin += $"Tác dụng phụ: {thuoc.Tac_dung_phu}\n";
            thongTin += $"Nhà sản xuất: {thuoc.Nha_san_xuat}\n";
            thongTin += $"Số lượng tồn: {thuoc.So_Luong_ton}\n";
            thongTin += $"Giá bán: {thuoc.Gia_ban:N0} VNĐ\n";
            thongTin += $"Ngày sản xuất: {thuoc.Ngay_san_xuat:dd/MM/yyyy}\n";
            thongTin += $"Ngày hết hạn: {thuoc.Ngay_het_han:dd/MM/yyyy}\n\n";
            MessageBox.Show(thongTin, "Chi tiết thuốc",
                MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}
