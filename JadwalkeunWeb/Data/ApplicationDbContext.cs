using JadwalkeunWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace JadwalkeunWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Tugas> Tugases { get; set; }
    }
}
