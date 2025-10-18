namespace QuanLyQuayThuoc.sql
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [Column("Ma Chi Tiet HD")]
        [StringLength(50)]
        public string Ma_Chi_Tiet_HD { get; set; }

        [Column("Ma san pham")]
        [Required]
        [StringLength(50)]
        public string Ma_san_pham { get; set; }

        [Column("So luong")]
        public int So_luong { get; set; }

        [Column("Ma Hoa Don")]
        [StringLength(50)]
        public string Ma_Hoa_Don { get; set; }

        [Column("So Ngay Uong")]
        public int? So_Ngay_Uong { get; set; }

        [Column("Thanh Tien")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Thanh_Tien { get; set; }

        [Column("Gia Ban")]
        public decimal? Gia_Ban { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual Person Person { get; set; }

        public virtual Thuoc Thuoc { get; set; }
    }
}
