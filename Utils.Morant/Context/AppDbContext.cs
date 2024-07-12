using Microsoft.EntityFrameworkCore;
using Utils.Morant.Models;
using Utils.Morant.Models.Tiny;

namespace Utils.Morant.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new UserSeed());
            //modelBuilder.ApplyConfigurationsFromAssembly();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ShortUri> ShortUri { get; set; }
    }
}
