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
            if (dgvNguoiDung.Columns.Count == 0)
            {
                dgvNguoiDung.Columns.Add("UserID", "Mã Người Dùng");
                dgvNguoiDung.Columns.Add("PasswordHash", "Mật Khẩu");
                dgvNguoiDung.Columns.Add("FullName", "Họ Tên");
                dgvNguoiDung.Columns.Add("Role", "Chức Vụ");
            }
            dgvNguoiDung.Rows.Clear();
            foreach (var item in listPerson)
            {
                int index = dgvNguoiDung.Rows.Add();
                dgvNguoiDung.Rows[index].Cells[0].Value = item.UserID;  
                dgvNguoiDung.Rows[index].Cells[1].Value = item.PasswordHash;
                dgvNguoiDung.Rows[index].Cells[2].Value = item.FullName;
                dgvNguoiDung.Rows[index].Cells[3].Value = item.Role.Role1;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = txtTenND.Text;
                string passwordHash = txtMatKhau.Text;
                int roleId = (int)cbChucVu.SelectedValue;
                Person newUser = new Person
                { 
                    UserID = txtMaND.Text,
                    FullName = fullName,
                    PasswordHash = passwordHash,
                    RoleID = roleId
                };
                db.People.Add(newUser);
                db.SaveChanges();
                // Cập nhật lại DataGridView
                var listPerson = db.People.ToList();
                FillDgvNguoiDung(listPerson);
                MessageBox.Show("Thêm Người Dùng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Người Dùng: " + ex.Message);
            }
        }

        
    }
}
    

