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

        }
        private void loatdatadsthuoc()
        {

            dgvdsThuoc.DataSource = db.Thuocs.Select(p => new
            {
                p.Ma_san_pham,
                p.Ten_san_pham,
            }).ToList();
            dgvdsThuoc.Columns["Ten_san_pham"].HeaderText = "Tên Sản Phẩm";
            dgvdsThuoc.Columns["Ma_san_pham"].HeaderText = "Mã Sản Phẩm";
            dgvdsThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Hàm tạo mã chi tiết hóa đơn tự động
        private string TaoMaChiTietHD()
        {
            try
            {
                // Lấy mã chi tiết hóa đơn cuối cùng trong database
                var lastChiTiet = db.ChiTietHoaDons
                    .OrderByDescending(c => c.Ma_Chi_Tiet_HD)
                    .FirstOrDefault();

                if (lastChiTiet == null)
                {
                    return "CT001";
                }

                string lastMa = lastChiTiet.Ma_Chi_Tiet_HD;

                if (lastMa.Length >= 5 && lastMa.StartsWith("CT"))
                {
                    string soThuTu = lastMa.Substring(2);
                    if (int.TryParse(soThuTu, out int number))
                    {
                        number++;
                        return "CT" + number.ToString("D3");
                    }
                }

                return "CT001";
            }
            catch
            {
                return "CT001";
            }
        }

        // Hàm tạo mã hóa đơn tự động
        private string TaoMaHoaDon()
        {
            try
            {
                // Lấy mã hóa đơn cuối cùng trong database
                var lastHoaDon = db.HoaDons
                    .OrderByDescending(h => h.Ma_hoa_don)
                    .FirstOrDefault();

                if (lastHoaDon == null)
                {
                    return "HD001";
                }

                string lastMa = lastHoaDon.Ma_hoa_don;

                if (lastMa.Length >= 5 && lastMa.StartsWith("HD"))
                {
                    string soThuTu = lastMa.Substring(2);
                    if (int.TryParse(soThuTu, out int number))
                    {
                        number++;
                        return "HD" + number.ToString("D3");
                    }
                }

                return "HD001";
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
           
            if (string.IsNullOrWhiteSpace(labMHD.Text) || labMHD.Text == "Mã hóa đơn")
            {
                dgvchitiethoadon.DataSource = null;
                return;
            }

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
            dgvchitiethoadon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvchitiethoadon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvchitiethoadon.ReadOnly = true;

            labelTongCong.Text = db.ChiTietHoaDons
                .Where(p => p.Ma_Hoa_Don == labMHD.Text)
                .Sum(p => p.Thanh_Tien).GetValueOrDefault().ToString("N0");
        }

        private void dgvdsThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = dgvdsThuoc.CurrentRow.Cells["Ma_san_pham"].Value.ToString();
            var b = dgvdsThuoc.CurrentRow.Cells["Ten_san_pham"].Value.ToString();

            txtmasanpham.Text = $"{a}";
            txttenthuoc.Text = $"{b}";
            txtDonGia.Text = db.Thuocs.Where(p => p.Ma_san_pham == a).Select(p => p.Gia_ban).FirstOrDefault().ToString();
        }
        private void btnaddbill_Click(object sender, EventArgs e)
        {
            var soLuongText = txtSoVien.Text;
            var soNgayUongText = txtSoNgayUong.Text;
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

        private void bntTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

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
        } 
        private void clearInputFields()
        {
            txtmasanpham.Text = string.Empty;
            txttenthuoc.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            txtSoVien.Text = string.Empty;
            txtSoNgayUong.Text = string.Empty;
            txtSDT.Text = string.Empty;
        }

        private void buttonHoanThanh_Click(object sender, EventArgs e)
        {
           
            var hoaDon = db.HoaDons.FirstOrDefault(hd => hd.Ma_hoa_don == labMHD.Text);
            if (hoaDon != null)
            {
                hoaDon.Tong_Tien = decimal.Parse(labelTongCong.Text);
                db.SaveChanges();
                MessageBox.Show($"Hoàn thành hóa đơn {labMHD.Text} thành công!\n",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                db.SaveChanges();
                labelTongCong.Text = "0";
                labMHD.Text = null;
                loadgridviewchitiethoadon();
                clearInputFields();

            }
        }
    }
}



