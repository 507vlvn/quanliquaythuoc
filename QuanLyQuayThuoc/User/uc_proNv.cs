using QuanLyQuayThuoc.sql;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace QuanLyQuayThuoc.User
{
    public partial class uc_proNv : UserControl
    {
        ModelSQL db = new ModelSQL();
        public uc_proNv()
        {
            InitializeComponent();
        }

        private void uc_proNv_Load(object sender, EventArgs e)
        {
            dgv.DataSource = db.People.Select(p => new
            {
                p.Timekeeping,
            }).ToList();

            Loaddata();
        }

        private void Loaddata()
        {
            var user = db.People.Where(p => p.Role.Role1 == "Staff").ToList()
                .Select(p => new
                {
                    p.UserID,
                    p.FullName,
                    p.DateOfBirth,
                    p.Address,
                    p.PhoneNumber,
                    p.Sex,
                    p.Role.Role1,
                    p.PasswordHash,

                })
                .FirstOrDefault();
            if(user != null)
            {
                txtMaNV.Text = user.UserID.ToString();
                txtTenNV.Text = user.FullName.ToString();
                dtpNgaySinh.Value = user.DateOfBirth ?? DateTime.Now;
                txtDiaChi.Text = user.Address.ToString();
                txtSDT.Text = user.PhoneNumber.ToString();
                if (user.Sex== "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên nào trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
