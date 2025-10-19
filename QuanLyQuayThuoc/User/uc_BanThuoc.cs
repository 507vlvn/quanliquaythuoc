using QuanLyQuayThuoc.sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyQuayThuoc.User
{

    public partial class uc_BanThuoc : UserControl
    {
        ModelSQL db = new ModelSQL();
        public uc_BanThuoc()
        {
            InitializeComponent();
        }

        private void uc_BanThuoc_Load(object sender, EventArgs e)
        {
            loatdatadsthuoc();
            fllcbbUser();
            loadgridviewchitiethoadon();

            dgvdsThuoc.Enabled = false;
        }

        private void loatdatadsthuoc()
        {

            dgvdsThuoc.DataSource = db.Thuocs.Select(p => new
            {
                p.Ma_san_pham,
                p.Ten_san_pham,
                p.Thanh_phan,
            }).ToList();
            dgvdsThuoc.Columns["Ten_san_pham"].HeaderText = "Tên Sản Phẩm";
            dgvdsThuoc.Columns["Ma_san_pham"].HeaderText = "Mã Sản Phẩm";
            dgvdsThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        // Hàm tạo mã chi tiết hóa đơn tự động - Tìm số nhỏ nhất còn trống
        private string TaoMaChiTietHD()
        {
            try
            {
                // Lấy tất cả mã chi tiết hóa đơn có định dạng CTxxx
                var allChiTiet = db.ChiTietHoaDons
                    .Where(c => c.Ma_Chi_Tiet_HD != null && c.Ma_Chi_Tiet_HD.StartsWith("CT"))
                    .Select(c => c.Ma_Chi_Tiet_HD)
                    .ToList();

                if (allChiTiet == null || allChiTiet.Count == 0)
                {
                    return "CT001";
                }

                // Chuyển đổi tất cả mã thành số và lưu vào HashSet để tìm nhanh
                HashSet<int> existingNumbers = new HashSet<int>();
                int maxNumber = 0;

                foreach (var ma in allChiTiet)
                {
                    if (ma.Length >= 3)
                    {
                        string soThuTu = ma.Substring(2); // Lấy phần sau "CT"
                        if (int.TryParse(soThuTu, out int number))
                        {
                            existingNumbers.Add(number);
                            if (number > maxNumber)
                            {
                                maxNumber = number;
                            }
                        }
                    }
                }

                // Tìm số nhỏ nhất còn trống từ 1 đến maxNumber
                for (int i = 1; i <= maxNumber; i++)
                {
                    if (!existingNumbers.Contains(i))
                    {
                        return "CT" + i.ToString("D3");
                    }
                }

                // Nếu không có khoảng trống, tăng lên từ maxNumber
                maxNumber++;
                return "CT" + maxNumber.ToString("D3");
            }
            catch
            {
                return "CT001";
            }
        }

        // Hàm tạo mã hóa đơn tự động - Tìm số nhỏ nhất còn trống
        private string TaoMaHoaDon()
        {
            try
            {
                // Lấy tất cả mã hóa đơn có định dạng HDxxx
                var allHoaDon = db.HoaDons
                    .Where(h => h.Ma_hoa_don != null && h.Ma_hoa_don.StartsWith("HD"))
                    .Select(h => h.Ma_hoa_don)
                    .ToList();

                if (allHoaDon == null || allHoaDon.Count == 0)
                {
                    return "HD001";
                }

                // Chuyển đổi tất cả mã thành số và lưu vào HashSet để tìm nhanh
                HashSet<int> existingNumbers = new HashSet<int>();
                int maxNumber = 0;

                foreach (var ma in allHoaDon)
                {
                    if (ma.Length >= 3)
                    {
                        string soThuTu = ma.Substring(2); // Lấy phần sau "HD"
                        if (int.TryParse(soThuTu, out int number))
                        {
                            existingNumbers.Add(number);
                            if (number > maxNumber)
                            {
                                maxNumber = number;
                            }
                        }
                    }
                }

                // Tìm số nhỏ nhất còn trống từ 1 đến maxNumber
                for (int i = 1; i <= maxNumber; i++)
                {
                    if (!existingNumbers.Contains(i))
                    {
                        return "HD" + i.ToString("D3");
                    }
                }

                // Nếu không có khoảng trống, tăng lên từ maxNumber
                maxNumber++;
                return "HD" + maxNumber.ToString("D3");
            }
            catch
            {
                return "HD001";
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

        private void loadgridviewchitiethoadon()
        {

            if (string.IsNullOrWhiteSpace(labMHD.Text) || labMHD.Text == "0")
            {
                dgvchitiethoadon.DataSource = null;
                return;
            }
            else
            {
                var list = db.ChiTietHoaDons
                    .Where(cthd => cthd.Ma_Hoa_Don == labMHD.Text)
                    .Select(cthd => new
                    {
                        cthd.Ma_Hoa_Don,
                        cthd.Ma_Chi_Tiet_HD,
                        cthd.Ma_san_pham,
                        cthd.So_luong,
                        cthd.So_Ngay_Uong,
                        cthd.Gia_Ban,
                        cthd.Thanh_Tien,
                        cthd.UserID

                    }).ToList();

                dgvchitiethoadon.DataSource = list;
                dgvchitiethoadon.Columns["Ma_Hoa_Don"].HeaderText = "Mã Hóa Đơn";
                dgvchitiethoadon.Columns["Ma_Chi_Tiet_HD"].HeaderText = "Mã Chi Tiết HĐ";
                dgvchitiethoadon.Columns["Ma_san_pham"].HeaderText = "Mã Sản Phẩm";
                dgvchitiethoadon.Columns["So_luong"].HeaderText = "Số Lượng";
                dgvchitiethoadon.Columns["So_Ngay_Uong"].HeaderText = "Số Ngày Uống";
                dgvchitiethoadon.Columns["Gia_Ban"].HeaderText = "Giá Bán";
                dgvchitiethoadon.Columns["Thanh_Tien"].HeaderText = "Thành Tiền";

                dgvchitiethoadon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvchitiethoadon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvchitiethoadon.ReadOnly = true;

                labelTongCong.Text = db.ChiTietHoaDons
                    .Where(p => p.Ma_Hoa_Don == labMHD.Text)
                    .Sum(p => p.Thanh_Tien).GetValueOrDefault().ToString("N0");
            }
        }

        private void dgvdsThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = dgvdsThuoc.CurrentRow.Cells["Ma_san_pham"].Value.ToString();
            var b = dgvdsThuoc.CurrentRow.Cells["Ten_san_pham"].Value.ToString();
            var c = dgvdsThuoc.CurrentRow.Cells["Thanh_phan"].Value.ToString();

            txtmasanpham.Text = $"{a}";
            txttenthuoc.Text = $"{b}";
            txtThanhPhan.Text = $"{c}";
            txtTon.Text = db.Thuocs.Where(p => p.Ma_san_pham == a).Select(p => p.So_Luong_ton).FirstOrDefault().ToString();
            txtChiDinh.Text = db.Thuocs.Where(p => p.Ma_san_pham == a).Select(p => p.Cong_dung).FirstOrDefault().ToString();
            txtDonGia.Text = db.Thuocs.Where(p => p.Ma_san_pham == a).Select(p => p.Gia_ban).FirstOrDefault().ToString();
            txtSoNgayUong.Clear();
            txtSoVien.Clear();
        }
        private void btnaddbill_Click(object sender, EventArgs e)
        {
            var soLuongText = txtSoVien.Text;
            var soNgayUongText = txtSoNgayUong.Text;
            if (soLuongText == "" || soNgayUongText == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng và số ngày uống!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmasanpham.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (labMHD.Text == "0")
            {
                MessageBox.Show("Vui lòng Tạo Hóa Đơn Trước !", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (db.Thuocs.Where(p => p.Ma_san_pham == txtmasanpham.Text).Select(p => p.So_Luong_ton).FirstOrDefault() < int.Parse(soLuongText) * int.Parse(soNgayUongText))
            {
                MessageBox.Show("Số lượng trong kho không đủ!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var cthd = new ChiTietHoaDon
                {
                    Ma_Chi_Tiet_HD = TaoMaChiTietHD(),
                    Ma_san_pham = txtmasanpham.Text,
                    So_luong = int.Parse(soLuongText) * int.Parse(soNgayUongText),
                    So_Ngay_Uong = int.Parse(txtSoNgayUong.Text),
                    Ma_Hoa_Don = labMHD.Text,
                    UserID = CurrentUser.UserID
                };
                dgvchitiethoadon.DataSource = cthd;
                db.ChiTietHoaDons.Add(cthd);
                db.SaveChanges();
                loadgridviewchitiethoadon();
            }
        }

        private void bntTaoHoaDon_Click(object sender, EventArgs e)
        {

            if (labMHD.Text != "0")
            {
                MessageBox.Show("Đang có hóa đơn chưa hoàn thành. Vui lòng hoàn thành hoặc hủy hóa đơn trước khi tạo mới.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            else
            if (LabUs.Text == "User :")
            {
                MessageBox.Show("Vui lòng đăng nhập để tạo hóa đơn!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else


            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại Khách Hàng!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else if (txtSDT.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại khách hàng không hợp lệ !", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            else
            {
                labMHD.Text = TaoMaHoaDon();
                var hd = new HoaDon
                {
                    Ma_hoa_don = labMHD.Text,
                    Ngay_ban = DateTime.Now,
                    So_Dien_Thoai = txtSDT.Text,
                    Tong_Tien = 0
                };
                db.HoaDons.Add(hd);
                db.SaveChanges();
                loadgridviewchitiethoadon();
                clearInputFields();
                dgvdsThuoc.Enabled = true;
            }
        }

        private void clearInputFields()
        {
            txtmasanpham.Clear();
            txttenthuoc.Clear();
            txtDonGia.Clear();
            txtSoVien.Clear();
            txtSoNgayUong.Clear();
            txtSDT.Clear();
            txtChiDinh.Clear();
            txtThanhPhan.Clear();
            txtTon.Clear();
        }

        private void buttonHoanThanh_Click(object sender, EventArgs e)
        {

            var hoaDon = db.HoaDons.FirstOrDefault(hd => hd.Ma_hoa_don == labMHD.Text);
            if (labMHD.Text == "0")
            {
                MessageBox.Show("Bạn Chưa Tạo Hóa Đơn Vui Lòng Tạo Hóa Đơn Trước.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                bntTaoHoaDon.Focus();
                return;
            }
            else
             if (!db.ChiTietHoaDons.Any(ct => ct.Ma_Hoa_Don == labMHD.Text))
            {
                MessageBox.Show("Hóa đơn không có sản phẩm nào. Bạn Không Thể Tạo Đơn Hàng Trống.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            else
            {
                hoaDon.Tong_Tien = decimal.Parse(labelTongCong.Text);
                db.SaveChanges();
                MessageBox.Show($"Hoàn thành hóa đơn {labMHD.Text} thành công!\n",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                db.SaveChanges();
                labelTongCong.Text = "0";
                labMHD.Text = "0";
                loadgridviewchitiethoadon();
                clearInputFields();
                dgvdsThuoc.Enabled = false;
            }

        }

        private void buttonHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (labMHD.Text == "0")
            {
                MessageBox.Show("Không có hóa đơn nào để hủy!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn hủy hóa đơn {labMHD.Text}?",
                                                  "Xác nhận hủy",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa các chi tiết hóa đơn trước
                var chiTietList = db.ChiTietHoaDons.Where(ct => ct.Ma_Hoa_Don == labMHD.Text).ToList();
                foreach (var chiTiet in chiTietList)
                {
                    db.ChiTietHoaDons.Remove(chiTiet);
                }

                // Xóa hóa đơn
                var hoaDon = db.HoaDons.FirstOrDefault(hd => hd.Ma_hoa_don == labMHD.Text);
                if (hoaDon != null)
                {
                    db.HoaDons.Remove(hoaDon);
                    db.SaveChanges();

                    MessageBox.Show($"Đã hủy hóa đơn {labMHD.Text} thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset giao diện
                    labMHD.Text = string.Empty;
                    labelTongCong.Text = "0đ";
                    clearInputFields();
                    loadgridviewchitiethoadon();
                    labMHD.Text = "0";
                }
            }
        }

        private void txtseach_TextChanged(object sender, EventArgs e)
        {
            String seach = txtseach.Text;
            dgvdsThuoc.DataSource = db.Thuocs.Where(p => p.Ten_san_pham.Contains(seach) || p.Ma_san_pham.Contains(seach))
                .Select(p => new
                {
                    p.Ma_san_pham,
                    p.Ten_san_pham,
                    p.Thanh_phan,
                }).ToList();
        }

        private void btndeleteCT_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvchitiethoadon.CurrentRow;
            if (selectedRow != null)
            {
                string maChiTietHD = selectedRow.Cells["Ma_Chi_Tiet_HD"].Value.ToString();
                var chiTietToDelete = db.ChiTietHoaDons.FirstOrDefault(ct => ct.Ma_Chi_Tiet_HD == maChiTietHD);
                if (chiTietToDelete != null)
                {
                    DialogResult rd = MessageBox.Show($"Bạn có chắc chắn muốn xóa chi tiết hóa đơn {maChiTietHD}?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
                    if (rd == DialogResult.Yes)
                    {
                        db.ChiTietHoaDons.Remove(chiTietToDelete);
                        db.SaveChanges();
                        loadgridviewchitiethoadon();
                    }
                }
            }
        }
    }
}




