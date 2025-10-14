namespace QuanLyQuayThuoc.Adminn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(50)]
        public string MaThuoc { get; set; }

        [Required]
        [StringLength(50)]
        public string TenThuoc { get; set; }

        [Required]
        [StringLength(50)]
        public string TenKH { get; set; }

        [Required]
        [StringLength(50)]
        public string SDTKH { get; set; }

        public double ThanhTien { get; set; }

        public int SoNgayUong { get; set; }

        public virtual DSThuoc DSThuoc { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
