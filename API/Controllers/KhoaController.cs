using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaController : ControllerBase

    {
        private readonly MyDbContext _db;
        public KhoaController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khoa>>> GetKhoas()
        {
            
            return Ok(await _db.Khoas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Khoa>>> GetKhoas(int id)
        {
            var result = await ( from sv in _db.SinhViens
                         join k in _db.Khoas on sv.KhId equals k.KhoaId
                         where k.KhoaId == id
                         select new
                         {
                             maKhoa = sv.KhId,
                             maSinhVien = sv.MaSV,
                             tenSinhVien = sv.TenSV,
                             ngaySinh = sv.NgaySinh,
                             gioiTinh = sv.GioiTinh,
                             khoa = k.TenKhoa,
                         }
            ).ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Khoa>> CreateKhoa(KhoaDTO requestKhoa)
        {
            var khoa = new Khoa()
            {
                SoHieuKhoa = requestKhoa.SoHieuKhoa,
                TenKhoa = requestKhoa.TenKhoa
            };
            _db.Khoas.Add(khoa);
            await _db.SaveChangesAsync();
            return Ok(khoa);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Khoa>> EditKhoa (int id,  KhoaDTO requestKhoa)
        {
            var khoa = await _db.Khoas.FindAsync(id);
            if (khoa == null) return NotFound("Không tìm thấy khoa");
            khoa.SoHieuKhoa = requestKhoa.SoHieuKhoa;
            khoa.TenKhoa = requestKhoa.TenKhoa;
            await _db.SaveChangesAsync();
            return Ok(khoa);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoa(int id)
        {
            var person = await _db.Khoas.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _db.Khoas.Remove(person);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _db.Khoas.Any(e => e.KhoaId == id);
        }
    }
}
