using API.Models;
using Microsoft.EntityFrameworkCore;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<SinhVien> SinhViens { get; set; }
    public DbSet<Khoa> Khoas { get; set; }

}
