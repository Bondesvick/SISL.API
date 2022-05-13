using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SISL.Core.Entities; //using DistributionRewardAutomation.Data.Models;

namespace SISL.Infrastructure.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Just for development: Remove for production
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<CustomerAccount> Audits { get; set; }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public DbSet<SislHistory> SislHistories { get; set; }
        public DbSet<SislStatus> SislStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}