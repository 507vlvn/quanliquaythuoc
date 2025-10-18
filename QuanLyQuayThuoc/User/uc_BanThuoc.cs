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
            loaddataban();
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
        private void loaddataban()
        {
            var list = db.ChiTietHoaDons
                .Select(cthd => new
                {
                    cthd.Ma_Hoa_Don,
                    cthd.Ma_san_pham,
                    cthd.Thuoc.Ten_san_pham,
                    cthd.So_luong,
                    cthd.So_Ngay_Uong,
                    cthd.Gia_ban,
                    cthd.Thanh_tien,
                    cthd.HoaDon.Ngay_ban,
                    cthd.Thuoc.Ngay_het_han,
                    cthd.HoaDon.UserID,
                    cthd.HoaDon.So_Dien_Thoai,

                })
                .ToList();
            dgvDshoadon.DataSource = list;
            labelTongCong.Text = "Tổng Cộng: " + list.Sum(x => x.Thanh_tien) + " VND";
            dgvDshoadon.Columns["Ma_Hoa_Don"].HeaderText = "Mã Hóa Đơn";
            dgvDshoadon.Columns["Ma_san_pham"].HeaderText = "Mã Sản Phẩm";
            dgvDshoadon.Columns["Ten_san_pham"].HeaderText = "Tên Sản Phẩm";
            dgvDshoadon.Columns["So_luong"].HeaderText = "Tổng Số Lượng";
            dgvDshoadon.Columns["So_Ngay_Uong"].HeaderText = "Số Ngày Uống";
            dgvDshoadon.Columns["Gia_ban"].HeaderText = "Giá Bán";
            dgvDshoadon.Columns["Thanh_tien"].HeaderText = "Thành Tiền";
            dgvDshoadon.Columns["Ngay_ban"].HeaderText = "Ngày Bán";
            dgvDshoadon.Columns["Ngay_het_han"].HeaderText = "Ngày Hết Hạn";
            dgvDshoadon.Columns["UserID"].HeaderText = "Mã Nhân Viên";
            dgvDshoadon.Columns["So_Dien_Thoai"].HeaderText = "Số Điện Thoại";
            dgvDshoadon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void clear()
        {
            txtHienThi.Clear();
            txtSoNgayUong.Clear();
            txtSoVien.Clear();
        }
        private void insertbill()
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            
        }
        private void btnaddbill_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon();
       cthd.Ma_Hoa_Don = null;
            cthd.Ma_san_pham = dgvdsThuoc.CurrentRow.Cells["Ma_san_pham"].Value.ToString();
            cthd.So_luong =null
            cthd.So_Ngay_Uong = int.Parse( txtSoNgayUong.Text);
            cthd.Gia_ban = decimal.Parse( txtDonGia.Text);
            cthd.Thanh_tien = null;
            db.ChiTietHoaDons.Add(cthd);
            db.SaveChanges();
            loaddataban();
            clear();



        }

        private void dgvdsThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          var a = dgvdsThuoc.CurrentRow.Cells["Ma_san_pham"].Value.ToString();
          var b = dgvdsThuoc.CurrentRow.Cells["Ten_san_pham"].Value.ToString();
          
            txtHienThi.Text = $"{a}";
            txttenthuoc.Text = $"{b}";
            txtDonGia.Text = db.Thuocs.Where(p => p.Ma_san_pham == a).Select(p => p.Gia_ban).FirstOrDefault().ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSoNgayUong_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSoNgayUong_Click(object sender, EventArgs e)
        {

        }

        private void txtSoVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtHienThi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
