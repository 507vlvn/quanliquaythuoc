using QuanLyQuayThuoc.Adminn;
using QuanLyQuayThuoc.User;
using System;
using System.Windows.Forms;

namespace QuanLyQuayThuoc
{
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }

        private void admin2_Load(object sender, EventArgs e)
        {

        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uc_Dashbord db  = new uc_Dashbord();
            db.Dock = DockStyle.Fill;  // Cho vừa khít panel
            panel1.Controls.Clear();   // Xóa các control cũ (nếu có)
            panel1.Controls.Add(db);   // Thêm usercontrol mới vào panel
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            uc_User user = new uc_User();
            user.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(user);
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            uc_ThongKeDoanhThu thongke = new uc_ThongKeDoanhThu();
            thongke.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(thongke);
        }

        private void btnOder_Click(object sender, EventArgs e)
        {
            uc_BanThuoc banThuoc = new uc_BanThuoc();
            banThuoc.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1 .Controls.Add(banThuoc);
        }

        private void btnKiemTraDonHang_Click(object sender, EventArgs e)
        {
           uc_BaoCaoDonHang baocao = new uc_BaoCaoDonHang();
            baocao.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(baocao);
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            uc_Product themthuoc = new uc_Product();
            themthuoc.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls .Add(themthuoc);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }    
}
