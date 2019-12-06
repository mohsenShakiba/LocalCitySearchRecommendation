using System.Threading;
using System.Threading.Tasks;
using LCSR.Domain.Aggregates.Cities;
using LCSR.Domain.SeedWorks;
using LCSR.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LCSR.Infrastructure
{
    public class LCSRContext: DbContext, IUnitOfWork
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<CitySearchHistory> CitySearchHistories { get; set; }
        public LCSRContext(DbContextOptions<LCSRContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CitySearchHistoryEntityTypeConfiguration());
        }

    }
}