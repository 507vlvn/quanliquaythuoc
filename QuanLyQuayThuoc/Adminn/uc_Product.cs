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

            dgvdsthuoc.DataSource = db.Thuocs
        .Where(t => t.So_Luong_ton > 0) 
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
            dgvdsthuoc.Columns["Ngay_san_xuat"].HeaderText = "NSX";
            dgvdsthuoc.Columns["Ngay_het_han"].HeaderText = "NHH";
            dgvdsthuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdsthuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void uc_Product_Load(object sender, EventArgs e)
        {
            LoadData();
            txtSLTon.Enabled = false;


        }

        private void btnThem_Click(object sender, EventArgs e)
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
                MessageBox.Show($"Mã sản phẩm '{maSanPham}' đã tồn tại. Vui lòng sử dụng mã khác.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongTon;
            if (!int.TryParse(txtSoLuongNhap.Text.Trim(), out soLuongTon))
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
                    So_Luong_ton = int.Parse(txtSoLuongNhap.Text),
                    Ngay_san_xuat = dateTimePicker1.Value,
                    Ngay_het_han = dateTimePicker2.Value
                };

                db.Thuocs.Add(newthuoc);
                db.SaveChanges();

                LoadData();

                MessageBox.Show("Thêm Thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi thêm Thuốc: " + ex, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSanPham = txtmasp.Text.Trim();
            string tenSanPham = txtsp.Text.Trim();
            string thanhphan = txtthanhphan.Text.Trim();
            string congDung = txtDonGia.Text.Trim();
            string tacDungPhu = txttdp.Text.Trim();
            string nhaSanXuat = txtnsx.Text.Trim();

            if (string.IsNullOrEmpty(maSanPham) || string.IsNullOrEmpty(tenSanPham) ||
                string.IsNullOrEmpty(thanhphan) || string.IsNullOrEmpty(congDung) ||
                string.IsNullOrEmpty(tacDungPhu) || string.IsNullOrEmpty(nhaSanXuat))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các thông tin bắt buộc.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaBan;
            if (!decimal.TryParse(txtgia.Text.Trim(), out giaBan))
            {
                MessageBox.Show("Giá Bán phải là một số hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            if (txtSoLuongNhap.Text == "")
            { txtSoLuongNhap.Text = "0"; }
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
                    thuoc.So_Luong_ton = int.Parse(txtSoLuongNhap.Text) + int.Parse(txtSLTon.Text);
                    thuoc.Ngay_san_xuat = dateTimePicker1.Value;
                    thuoc.Ngay_het_han = dateTimePicker2.Value;
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Sửa Thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show($"Không tìm thấy thuốc với mã sản phẩm '{maSanPham}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi sửa Thuốc: " + ex, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtmasp.Enabled = true;
            btnThem.Enabled = true;
            txtSLTon.Enabled = true;
            clear();
            txtSLTon.Enabled = false;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvdsthuoc.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn thuốc cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maSP = dgvdsthuoc.CurrentRow.Cells["Ma_san_pham"].Value?.ToString();

                if (string.IsNullOrEmpty(maSP))
                {
                    MessageBox.Show("Không tìm thấy mã sản phẩm hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var thuoc = db.Thuocs.FirstOrDefault(t => t.Ma_san_pham == maSP);

                if (thuoc == null)
                {
                    MessageBox.Show("Thuốc không tồn tại hoặc đã bị xóa!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isUsed = db.ChiTietHoaDons.Any(ct => ct.Ma_san_pham == maSP);

                if (isUsed)
                {
                    MessageBox.Show(

                        "Hãy đánh dấu là 'Ngừng kinh doanh' thay vì xóa.",
                        "Không thể xóa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;


                }

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa thuốc này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.No)
                    return;

                db.Thuocs.Remove(thuoc);
                db.SaveChanges();

                MessageBox.Show("Xóa thuốc thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                clear();
                LoadData();
                btnThem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa thuốc:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvdsthuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = dgvdsthuoc.CurrentRow;
            txtmasp.Text = index.Cells["Ma_san_pham"].Value.ToString();
            txtsp.Text = index.Cells["Ten_san_pham"].Value.ToString();
            txtthanhphan.Text = index.Cells["Thanh_phan"].Value.ToString();
            txtDonGia.Text = index.Cells["Cong_dung"].Value.ToString();
            txttdp.Text = index.Cells["Tac_dung_phu"].Value.ToString();
            txtnsx.Text = index.Cells["Nha_san_xuat"].Value.ToString();
            txtSLTon.Text = index.Cells["So_luong_ton"].Value.ToString();
            txtgia.Text = index.Cells["Gia_ban"].Value.ToString();
            dateTimePicker1.Text = index.Cells["Ngay_san_xuat"].Value.ToString();
            dateTimePicker2.Text = index.Cells["Ngay_het_han"].Value.ToString();
            txtmasp.Enabled = false;
            txtSLTon.Enabled = false;
            btnThem.Enabled = false;
        }
        private void clear()
        {
            txtmasp.Clear();
            txtsp.Clear();
            txtthanhphan.Clear();
            txtDonGia.Clear();
            txttdp.Clear();
            txtnsx.Clear();
            txtSLTon.Clear();
            txtSoLuongNhap.Clear();
            txtgia.Clear();
        }

        private void txtseach_TextChanged(object sender, EventArgs e)
        {
            var keyword = txtseach.Text.Trim().ToLower();
            var filteredData = db.Thuocs
                .Where(t => t.Ma_san_pham.ToLower().Contains(keyword) ||
                            t.Ten_san_pham.ToLower().Contains(keyword))

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
            dgvdsthuoc.DataSource = filteredData;
        }

        private void btnrefech_Click(object sender, EventArgs e)
        {
            txtmasp.Enabled = true;
            txtSLTon.Enabled = true;
            clear();
            txtSLTon.Enabled = false;
            btnThem.Enabled = true;
        }
        private void chkSlThuioc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSlThuioc.Checked == true)
            {
                var expiredDrugs = db.Thuocs
                    .Where(t => t.So_Luong_ton < 10)
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
                dgvdsthuoc.DataSource = expiredDrugs;
            }
            else
            {
                LoadData();
            }
        }

    }
}