namespace QuanLyQuayThuoc.sql
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [Column("Ma hoa don")]
        [StringLength(50)]
        public string Ma_hoa_don { get; set; }

        [Column("Ngay ban", TypeName = "date")]
        public DateTime Ngay_ban { get; set; }

        [Column("So Dien Thoai")]
        [Required]
        [StringLength(20)]
        public string So_Dien_Thoai { get; set; }

        [Column("Tong Tien")]
        public decimal Tong_Tien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
