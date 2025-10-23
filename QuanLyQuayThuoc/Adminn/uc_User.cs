using QuanLyQuayThuoc.sql;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuayThuoc.Adminn
{
    public partial class uc_User : UserControl
    {
        private ModelSQL db = new ModelSQL();

        public uc_User()
        {
            InitializeComponent();
        }

        private void uc_User_Load(object sender, EventArgs e)
        {
            try
            {
                var listPerson = db.People.ToList();
                var listRole = db.Roles.ToList();
                FillDgvNguoiDung(listPerson);
                FillCbbChucVu(listRole);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void FillCbbChucVu(List<Role> listRole)
        {
            cbChucVu.DataSource = listRole;
            cbChucVu.DisplayMember = "Role1";
            cbChucVu.ValueMember = "RoleID";
        }
        private void FillDgvNguoiDung(List<Person> listPerson)
        {
            var list = listPerson.Select(p => new
            {
                p.UserID,
                p.FullName,
                p.Sex,
                p.DateOfBirth,
                p.PhoneNumber,
                p.Address,
                RoleName = p.Role != null ? p.Role.Role1 : "",
                p.PasswordHash,
            }).ToList();
            dgvNguoiDung.DataSource = list;
            dgvNguoiDung.Columns["UserID"].HeaderText = "Tên Đăng Nhập";
            dgvNguoiDung.Columns["FullName"].HeaderText = "Tên Người Dùng";
            dgvNguoiDung.Columns["Sex"].HeaderText = "Giới Tính";
            dgvNguoiDung.Columns["DateOfBirth"].HeaderText = "Ngày Sinh";
            dgvNguoiDung.Columns["PhoneNumber"].HeaderText = "Số Điện Thoại";
            dgvNguoiDung.Columns["Address"].HeaderText = "Địa Chỉ";
            dgvNguoiDung.Columns["RoleName"].HeaderText = "Chức Vụ";
            dgvNguoiDung.Columns["PasswordHash"].HeaderText = "Mật Khẩu";
            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaND.Text) ||
                    string.IsNullOrWhiteSpace(txtTenND.Text) ||
                    string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                    string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin người dùng!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbChucVu.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn chức vụ!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string userID = txtMaND.Text.Trim();

                if (db.People.Any(p => p.UserID == userID))
                {
                    MessageBox.Show($"Mã người dùng '{userID}' đã tồn tại. Vui lòng chọn mã khác.", "Lỗi trùng lặp",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fullName = txtTenND.Text.Trim();
                string passwordHash = txtMatKhau.Text.Trim();
                string diachi = txtDiaChi.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string sex = rdNam.Checked ? "Nam" : "Nữ".Trim();
                int roleId = (int)cbChucVu.SelectedValue;

                Person newUser = new Person
                {
                    UserID = userID,
                    FullName = fullName,
                    PasswordHash = passwordHash,
                    Address = diachi,
                    PhoneNumber = sdt,
                    Sex = sex,
                    DateOfBirth = dtpNgaySinh.Value,
                    RoleID = roleId
                };


                db.People.Add(newUser);
                db.SaveChanges();

                FillDgvNguoiDung(db.People.ToList());
                ClearFormInputs();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormInputs()
        {

            txtMaND.Clear();
            txtTenND.Clear();
            txtMatKhau.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            rdNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            cbChucVu.SelectedIndex = 0;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {


            string userID = dgvNguoiDung.CurrentRow.Cells["UserID"].Value.ToString();
            if (!string.IsNullOrEmpty(userID))
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa người dùng không '{userID} không ?'", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var user = db.People.FirstOrDefault(p => p.UserID == userID);
                        if (user != null)
                        {
                            db.People.Remove(user);
                            db.SaveChanges();
                            List<Person> listPerson = db.People.ToList();
                            FillDgvNguoiDung(listPerson);

                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private void txtseach_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtseach.Text.ToLower();
            var filteredList = db.People
                .Where(p => p.UserID.ToLower().Contains(searchText) ||
                            p.FullName.ToLower().Contains(searchText) ||
                            p.Role.Role1.ToLower().Contains(searchText))
                .ToList();
        }

        private void btmFix_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng để sửa!", "Chưa chọn người dùng",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string userID = dgvNguoiDung.CurrentRow.Cells["UserID"].Value.ToString();
            var user = db.People.FirstOrDefault(p => p.UserID == userID);
            if (user != null)
            {
                user.FullName = txtTenND.Text.Trim();
                user.PasswordHash = txtMatKhau.Text.Trim();
                user.Address = txtDiaChi.Text.Trim();
                user.PhoneNumber = txtSDT.Text.Trim();
                user.Sex = rdNam.Checked ? "Nam" : "Nữ".Trim();
                user.DateOfBirth = dtpNgaySinh.Value;
                user.RoleID = (int)cbChucVu.SelectedValue;
                db.SaveChanges();
                FillDgvNguoiDung(db.People.ToList());

            }
        }

        private void dgvNguoiDung_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaND.Text = dgvNguoiDung.CurrentRow.Cells["UserID"].Value.ToString();
            txtTenND.Text = dgvNguoiDung.CurrentRow.Cells["FullName"].Value.ToString();
            txtMatKhau.Text = dgvNguoiDung.CurrentRow.Cells["PasswordHash"].Value.ToString();
            txtDiaChi.Text = dgvNguoiDung.CurrentRow.Cells["Address"].Value.ToString();
            txtSDT.Text = dgvNguoiDung.CurrentRow.Cells["PhoneNumber"].Value.ToString();
            string sexx = dgvNguoiDung.CurrentRow.Cells["Sex"].Value.ToString();
        if (sexx == "N?   ")
            {
                rdNu.Checked = true;
            }
            else
            {
               
                rdNam.Checked = true;
            }
            dtpNgaySinh.Text = dgvNguoiDung.CurrentRow.Cells["DateOfBirth"].Value.ToString();
            cbChucVu.Text = dgvNguoiDung.CurrentRow.Cells["RoleName"].Value.ToString();

        }
    }
}
    

