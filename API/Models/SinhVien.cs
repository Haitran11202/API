using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("SINH_VIEN")]
    public class SinhVien
    {
        [Key]
        [Column("SINH_VIEN_ID")]
        public int SinhVienId { get; set; }
        [Required]
        [StringLength(50)]
        [Column("MA_SINH_VIEN")]
        public string MaSV { get; set; }
        [Required]
        [StringLength(50)]
        [Column("TEN_SINH_VIEN")]
        public string TenSV { get; set; }
        [Required]
        [Column("NGAY_SINH")]
        public DateTime NgaySinh { get; set; }
        [Required]
        [Column("GIOI_TINH")]
        public string GioiTinh { get; set; }
        public int KhId { get; set; }
        [ForeignKey("KhId")]
        public Khoa? Khoa { get; set; }

        
    }
}
