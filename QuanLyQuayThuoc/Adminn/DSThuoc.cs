namespace QuanLyQuayThuoc.Adminn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSThuoc")]
    public partial class DSThuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DSThuoc()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(50)]
        public string MaThuoc { get; set; }

        [Required]
        [StringLength(50)]
        public string TenThuoc { get; set; }

        [Required]
        [StringLength(50)]
        public string Loai { get; set; }

        [Required]
        [StringLength(50)]
        public string NgaySX { get; set; }

        [Required]
        [StringLength(50)]
        public string HSD { get; set; }

        public int SL { get; set; }

        public int DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
