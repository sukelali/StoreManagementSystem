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

            modelBuilder.Entity<Unit>().HasData(
               new Unit { Id = 1, Name = "Piece", Symbol = "PCS", CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
               new Unit { Id = 2, Name = "Yards", Symbol = "YDS", CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
               new Unit { Id = 3, Name = "Centimeter", Symbol = "CM", CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
               new Unit { Id = 4, Name = "Milimeter", Symbol = "MM", CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
               new Unit { Id = 5, Name = "Gauss", Symbol = "GS", CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
               new Unit { Id = 6, Name = "Cone", Symbol = "Cone", CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow }
               );
        }

        public DbSet<Unit> Units { get; set; } = default!;
        public DbSet<ItemCategory> ItemCategories { get; set; } = default!;
        public DbSet<Item> Items { get; set; } = default!;
        public DbSet<Requisition> Requisitions { get; set; } = default!;
        public DbSet<RequisitionItem> RequisitionItems { get; set; } = default!;
    }
}
