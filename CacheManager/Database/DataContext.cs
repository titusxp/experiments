using DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Database
{

    public class DataContext : DbContext, IDataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=CacheManager;User Id=postgres;Password=P@55w0rd");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<CachedReport> CachedReports { get; set; }
    }
}
