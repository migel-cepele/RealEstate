using Microsoft.EntityFrameworkCore;
using RealEstate.API.Domain;

namespace RealEstate.API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<House> Houses { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ClientItem> ClientItems { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
    }
}
