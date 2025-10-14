namespace QuanLyQuayThuoc.Adminn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(50)]
        public string MaNv { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNV { get; set; }

        public int sdt { get; set; }

        [Required]
        [StringLength(50)]
        public string Gmail { get; set; }

        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(50)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
