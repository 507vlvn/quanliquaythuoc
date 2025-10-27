using QuanLyQuayThuoc.Adminn;
using QuanLyQuayThuoc.sql;
using QuanLyQuayThuoc.uc_con;
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
            uc_ChartTron banThuoc = new uc_ChartTron();
            banThuoc.Dock = DockStyle.Fill;  // Cho vừa khít panel
            panel1.Controls.Clear();   // Xóa các control cũ (nếu có)
            panel1.Controls.Add(banThuoc);   // Thêm usercontrol mới vào panel.
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
