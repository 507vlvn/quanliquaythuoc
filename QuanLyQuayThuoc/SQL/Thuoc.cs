namespace QuanLyQuayThuoc.SQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuoc")]
    public partial class Thuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thuoc()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [Column("Ma san pham")]
        [StringLength(50)]
        public string Ma_san_pham { get; set; }

        [Column("Ten san pham")]
        [StringLength(100)]
        public string Ten_san_pham { get; set; }

        [Column("Thanh phan")]
        [StringLength(200)]
        public string Thanh_phan { get; set; }

        [Column("Cong dung")]
        [StringLength(200)]
        public string Cong_dung { get; set; }

        [Column("Tac dung phu")]
        [StringLength(200)]
        public string Tac_dung_phu { get; set; }

        [Column("Nha san xuat")]
        [StringLength(100)]
        public string Nha_san_xuat { get; set; }

        [Column("So Luong")]
        public int? So_Luong { get; set; }

        [Column("Gia ban")]
        public decimal? Gia_ban { get; set; }

        [Column("Ngay san xuat", TypeName = "date")]
        public DateTime? Ngay_san_xuat { get; set; }

        [Column("Ngay het han", TypeName = "date")]
        public DateTime? Ngay_het_han { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
