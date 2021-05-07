
using Microsoft.EntityFrameworkCore;

using SelfCheckoutMachine.Models;

namespace SelfCheckoutMachine.Data
{
    public class CashDbContext : DbContext
    {
        public CashDbContext(DbContextOptions<CashDbContext> options) : base(options)
        {
        }

        public DbSet<Cash> CashSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cash>().ToTable("Cash");
        }
    }
}
