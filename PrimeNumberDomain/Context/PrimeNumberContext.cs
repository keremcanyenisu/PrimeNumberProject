using Microsoft.EntityFrameworkCore;
using PrimeNumberDomain.Configurations;
using PrimeNumberDomain.Entities;

namespace PrimeNumberDomain.Context
{
    public class PrimeNumberContext : DbContext
    {
        public PrimeNumberContext(DbContextOptions<PrimeNumberContext> options)
    : base(options)
        { }

        public DbSet<PrimeNumberHistory> PrimeNumberHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrimeNumberHistoryConfiguration).Assembly);
        }

    }
}
