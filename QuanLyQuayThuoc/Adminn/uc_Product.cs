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
            List<Thuoc> listThuoc = db.Thuocs.ToList();
            dgvdsthuoc.DataSource = listThuoc;
            dgvdsthuoc.DataSource = db.Thuocs
       .Select(t => new
       {
           t.Ma_san_pham,
           t.Ten_san_pham,
           t.Thanh_phan,
           t.Cong_dung,
           t.Tac_dung_phu,
           t.Nha_san_xuat,
           t.So_Luong_ton,t.Gia_ban,t.Ngay_san_xuat,t.Ngay_het_han      
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
        private void dgvDsthuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}
