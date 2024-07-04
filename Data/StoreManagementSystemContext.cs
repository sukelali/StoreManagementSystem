using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Models;

namespace StoreManagementSystem.Data
{
    public class StoreManagementSystemContext : DbContext
    {
        public StoreManagementSystemContext (DbContextOptions<StoreManagementSystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        public DbSet<Unit> Unit { get; set; } = default!;
    }
}
