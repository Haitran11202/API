using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly MyDbContext _db;
        public StudentController(MyDbContext db)
        {
            _db = db;
        }
        // GET: api/student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SinhVien>>> GetSinhViens()
        {
            var result = await (
                    from sv in _db.SinhViens
                    join kh in _db.Khoas
                    on sv.KhId equals kh.KhoaId
                    select new
                    {
                        sinhvienId = sv.SinhVienId,
                        masinhvien = sv.MaSV,
                        tensinhvien = sv.TenSV,
                        ngaySinh = sv.NgaySinh,
                        gioiTinh = sv.GioiTinh,
                        khoa = kh.TenKhoa,
                    }
                ).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SinhVien>> GetSinhVien(int id)
        {
            var sinhvien = await _db.SinhViens.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            return sinhvien;
        }

        [HttpPost]
        public async Task<ActionResult<SinhVien>> PostSinhVien(SinhVienDTO requestSinhVien)
        {
            var sinhvien = new SinhVien()
            {
                TenSV = requestSinhVien.TenSV,
                MaSV = requestSinhVien.MaSV,
                NgaySinh = requestSinhVien.NgaySinh,
                GioiTinh = requestSinhVien.GioiTinh,
                KhId = requestSinhVien.khoaId,
            };
            
            _db.SinhViens.Add(sinhvien);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinhVien(int id, SinhVienDTO requestSV)
        {
            var sinhvien = await _db.SinhViens.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound("Không tìm thấy sinh viên!");
            }

            sinhvien.MaSV = requestSV.MaSV;
            sinhvien.TenSV = requestSV.TenSV;
            sinhvien.NgaySinh = requestSV.NgaySinh;
            sinhvien.GioiTinh = requestSV.GioiTinh;
            sinhvien.KhId = requestSV.khoaId;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhVien(int id)
        {
            var sinhVien = await _db.SinhViens.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            _db.SinhViens.Remove(sinhVien);
            await _db.SaveChangesAsync();

            return NoContent();


        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            var sinhViens = _db.SinhViens.Include(s => s.Khoa).AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                sinhViens = sinhViens.Where(s => s.TenSV.Contains(query));
            }

            if (!string.IsNullOrEmpty(query))
            {
                sinhViens = sinhViens.Where(s => s.Khoa.TenKhoa.Contains(query));
            }

            return Ok(sinhViens.ToList());
        }
    }
}
