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
    public partial class uc_BaoCaoDonHang : UserControl
    {  
        private ModelSQL db = new ModelSQL();
        public uc_BaoCaoDonHang()
        {
            InitializeComponent();
        }
        private void uc_BaoCaoDonHang_Load(object sender, EventArgs e)
        {
            List<ChiTietHoaDon> listChiTietHoaDon = db.ChiTietHoaDons.ToList();
            dgvQuanLiHoaDon.DataSource = listChiTietHoaDon;
            dgvQuanLiHoaDon.DataSource = db.ChiTietHoaDons.Select(cthd => new
            {
                cthd.Ma_Chi_Tiet_HD,
                cthd.Ma_san_pham,
                cthd.So_luong,
                cthd.So_Ngay_Uong,
                cthd.Gia_ban,
                cthd.Thanh_tien,
                cthd.Ma_Hoa_Don
            }).ToList();
            dgvQuanLiHoaDon.Columns["Ma_Chi_Tiet_HD"].HeaderText = "Mã Chi Tiết HĐ";
            dgvQuanLiHoaDon.Columns["Ma_san_pham"].HeaderText = "Mã Sản Phẩm";
            dgvQuanLiHoaDon.Columns["So_luong"].HeaderText = "Số Lượng";
            dgvQuanLiHoaDon.Columns["So_Ngay_Uong"].HeaderText = "Số Ngày Uống";
            dgvQuanLiHoaDon.Columns["Gia_ban"].HeaderText = "Giá Bán";
            dgvQuanLiHoaDon.Columns["Thanh_tien"].HeaderText = "Thành Tiền";
            dgvQuanLiHoaDon.Columns["Ma_Hoa_Don"].HeaderText = "Mã Hóa Đơn";
            dgvQuanLiHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuanLiHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower();
            var result =db.ChiTietHoaDons.Where(cthd =>
                cthd.Ma_Chi_Tiet_HD.ToString().ToLower().Contains(keyword) ||
                cthd.Ma_san_pham.ToLower().Contains(keyword) ||
                cthd.Ma_Hoa_Don.ToString().ToLower().Contains(keyword) ||
                cthd.So_luong.ToString().ToLower().Contains(keyword) ||
                cthd.So_Ngay_Uong.ToString().ToLower().Contains(keyword) ||
                cthd.Gia_ban.ToString().ToLower().Contains(keyword) ||
                cthd.Thanh_tien.ToString().ToLower().Contains(keyword)||
                cthd.Ma_Hoa_Don.ToString().ToLower().Contains(keyword)
                ).ToList();
           dgvQuanLiHoaDon.DataSource = result;
        }
     }
 }

