using Microsoft.EntityFrameworkCore;
using RealEstate.Domain;

namespace RealEstate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<House> Houses { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
    }
}