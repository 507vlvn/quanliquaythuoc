using QuanLyQuayThuoc.sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyQuayThuoc.Adminn
{
    public partial class uc_Product : UserControl
    {
        ModelSQL db = new ModelSQL();
        public uc_Product()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            // Tải dữ liệu thuốc và chọn các cột cần hiển thị
            dgvdsthuoc.DataSource = db.Thuocs
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
            dgvdsthuoc.Columns["Ma_san_pham"].HeaderText = "Mã thuốc";
            dgvdsthuoc.Columns["Ten_san_pham"].HeaderText = "Tên thuốc";
            dgvdsthuoc.Columns["Thanh_phan"].HeaderText = "Thành Phần";
            dgvdsthuoc.Columns["Cong_dung"].HeaderText = "Công Dụng";
            dgvdsthuoc.Columns["Tac_dung_phu"].HeaderText = "Tác dụng phụ";
            dgvdsthuoc.Columns["Nha_san_xuat"].HeaderText = "Nhà sản xuất";
            dgvdsthuoc.Columns["So_Luong_ton"].HeaderText = "Số Lượng Tồn";
            dgvdsthuoc.Columns["Gia_ban"].HeaderText = "Giá Bán";
            dgvdsthuoc.Columns["Ngay_san_xuat"].HeaderText = "Ngày sản Xuất";
            dgvdsthuoc.Columns["Ngay_het_han"].HeaderText = "Ngày hết hạn";
            dgvdsthuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdsthuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void uc_Product_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            string tenSanPham = txtmasp.Text.Trim();
            string maSanPham = txtsp.Text.Trim();
            string thanhphan = txtthanhphan.Text.Trim();
            string congDung = txtDonGia.Text.Trim();
            string tacDungPhu = txttdp.Text.Trim();
            string nhaSanXuat = txtnsx.Text.Trim();
            if (string.IsNullOrEmpty(tenSanPham) || string.IsNullOrEmpty(maSanPham) ||
                string.IsNullOrEmpty(thanhphan) || string.IsNullOrEmpty(congDung) ||
                string.IsNullOrEmpty(tacDungPhu) || string.IsNullOrEmpty(nhaSanXuat))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các thông tin bắt buộc.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var existingDrug = db.Thuocs.FirstOrDefault(t => t.Ma_san_pham == maSanPham);
            if (existingDrug != null)
            {

                MessageBox.Show($"Mã sản phẩm '{maSanPham}' đã tồn tại. Vui lòng nhập mã khác.", "Lỗi Trùng Mã Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra Số Lượng Tồn (int)
            int soLuongTon;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out soLuongTon))
            {
                MessageBox.Show("Số Lượng Tồn phải là một số nguyên hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal giaBan;
            if (!decimal.TryParse(txtgia.Text.Trim(), out giaBan))
            {
                MessageBox.Show("Giá Bán phải là một số hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Thuoc newthuoc = new Thuoc
                {
                    Ma_san_pham = maSanPham,
                    Ten_san_pham = tenSanPham,                   
                    Thanh_phan = thanhphan,
                    Cong_dung = congDung,
                    Tac_dung_phu = tacDungPhu,
                    Nha_san_xuat = nhaSanXuat,
                    Gia_ban = giaBan,

                    Ngay_san_xuat = dateTimePicker1.Value,
                    Ngay_het_han = dateTimePicker2.Value
                };

                db.Thuocs.Add(newthuoc);
                db.SaveChanges();

                LoadData();

                MessageBox.Show("Thêm Thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasp.Clear();
                txtsp.Clear();
                txtthanhphan.Clear();
                txtDonGia.Clear();
                txttdp.Clear();
                txtnsx.Clear();
                txtSoLuong.Clear();
                txtgia.Clear();
            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;
                Exception inner = ex;
                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }
                errorMessage += "\nChi tiết lỗi SQL Server: " + inner.Message;

                MessageBox.Show("Lỗi khi thêm Thuốc: " + errorMessage, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSanPham = txtmasp.Text.Trim();
            string tenSanPham = txtsp.Text.Trim();
            string thanhphan = txtthanhphan.Text.Trim();
            string congDung = txtDonGia.Text.Trim();
            string tacDungPhu = txttdp.Text.Trim();
            string nhaSanXuat = txtnsx.Text.Trim();
            string slt= txtSoLuong.Text.Trim();
            if (string.IsNullOrEmpty(maSanPham) || string.IsNullOrEmpty(tenSanPham) ||
                string.IsNullOrEmpty(thanhphan) || string.IsNullOrEmpty(congDung) ||
                string.IsNullOrEmpty(tacDungPhu) || string.IsNullOrEmpty(nhaSanXuat))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các thông tin bắt buộc.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra Số Lượng Tồn (int)
            int soLuongTon;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out soLuongTon))
            {
                MessageBox.Show("Số Lượng Tồn phải là một số nguyên hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal giaBan;
            if (!decimal.TryParse(txtgia.Text.Trim(), out giaBan))
            {
                MessageBox.Show("Giá Bán phải là một số hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Thuoc thuoc = db.Thuocs.SingleOrDefault(t => t.Ma_san_pham == maSanPham);
                if (thuoc != null)
                {
                    thuoc.Ten_san_pham = tenSanPham;
                    thuoc.Thanh_phan = thanhphan;
                    thuoc.Cong_dung = congDung;
                    thuoc.Tac_dung_phu = tacDungPhu;
                    thuoc.Nha_san_xuat = nhaSanXuat;
                    thuoc.Gia_ban = giaBan;
                    thuoc.So_Luong_ton= soLuongTon;
                    thuoc.Ngay_san_xuat = dateTimePicker1.Value;
                    thuoc.Ngay_het_han = dateTimePicker2.Value;
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Sửa Thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmasp.Clear();
                    txtsp.Clear();
                    txtthanhphan.Clear();
                    txtDonGia.Clear();
                    txttdp.Clear();
                    txtnsx.Clear();
                    txtSoLuong.Clear();
                    txtgia.Clear();
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy thuốc với mã sản phẩm '{maSanPham}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                Exception inner = ex;
                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }
                errorMessage += "\nChi tiết lỗi SQL Server: " + inner.Message;
                MessageBox.Show("Lỗi khi sửa Thuốc: " + errorMessage, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            var selectedRows = dgvdsthuoc.CurrentRow;
           
            if (selectedRows != null)
            {

                string masp = selectedRows.Cells["Ma_san_pham"].Value.ToString();
                var xoa = db.Thuocs.FirstOrDefault(p => p.Ma_san_pham == masp);
                if (xoa != null)
                {

                    db.Thuocs.Remove(xoa);
                    db.SaveChanges();
                    LoadData();
                }
                else
                {
                }
            }
           

        }

        private void dgvdsthuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = dgvdsthuoc.CurrentRow;
               txtmasp.Text= index.Cells["Ma_san_pham"].Value.ToString();      
               txtsp.Text= index.Cells["Ten_san_pham"].Value.ToString();      
               txtthanhphan.Text= index.Cells["Thanh_phan"].Value.ToString();      
               txtDonGia.Text= index.Cells["Cong_dung"].Value.ToString();      
               txttdp.Text= index.Cells["Tac_dung_phu"].Value.ToString();      
               txtnsx.Text= index.Cells["Nha_san_xuat"].Value.ToString();      
               txtSoLuong.Text= index.Cells["So_luong_ton"].Value.ToString();      
               txtgia.Text= index.Cells["Gia_ban"].Value.ToString();      
               dateTimePicker1.Text= index.Cells["Ngay_san_xuat"].Value.ToString();      
               dateTimePicker2.Text= index.Cells["Ngay_het_han"].Value.ToString();      



            
        }
    }
}