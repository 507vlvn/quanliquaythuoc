using QuanLyQuayThuoc.sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            LoadData();
        }

        private void LoadData()
        {
            var list = db.HoaDons
                .Select(cthd => new
                {
            
                    cthd.Ngay_ban,
                    
                })
                .ToList();

            dgvQuanLiHoaDon.DataSource = list;


            dgvQuanLiHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuanLiHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuanLiHoaDon.ReadOnly = true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            var result = db.ChiTietHoaDons
                .Where(cthd =>
                    cthd.Ma_Chi_Tiet_HD.ToString().Contains(keyword) ||
                    cthd.Ma_Hoa_Don.ToString().Contains(keyword))
                .Select(cthd => new
                {
                    cthd.Ma_Chi_Tiet_HD,
                    cthd.Ma_san_pham,
                    cthd.So_luong,
                    cthd.So_Ngay_Uong,
                   
                    cthd.Ma_Hoa_Don
                })
                .ToList();
            dgvQuanLiHoaDon.DataSource = result;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvQuanLiHoaDon.SelectedRows;
            if (selectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa các mục đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        int chiTietHDId = Convert.ToInt32(row.Cells["Ma_Chi_Tiet_HD"].Value);
                        var chiTietHD = db.ChiTietHoaDons.Find(chiTietHDId);
                        if (chiTietHD != null)
                        {
                            db.ChiTietHoaDons.Remove(chiTietHD);
                        }
                    }
                    db.SaveChanges();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một mục để xóa.");
            }
        }
    }
}
