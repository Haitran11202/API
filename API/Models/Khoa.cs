using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("KHOA")]
    public class Khoa
    {
        [Key]
        [Column("KHOA_ID")]
        public int KhoaId { get; set; }
        [Column("SO_HIEU_KHOA")]
        public string SoHieuKhoa { get; set; }
        [Column("TEN_KHOA")]
        public string TenKhoa { get; set; }

        public List<SinhVien> SinhViens { get; set; }

        public Khoa()
        {
            SinhViens = new List<SinhVien>();
        }
        public void addSinhVien(SinhVien sinhVien)
        {
            SinhViens.Add(sinhVien);
        }
        
        
    }
}
