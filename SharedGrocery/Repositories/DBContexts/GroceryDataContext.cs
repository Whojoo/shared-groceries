using Microsoft.EntityFrameworkCore;
using SharedGrocery.Models;
using SharedGrocery.Models.Joins;

namespace SharedGrocery.Repositories.DBContexts
{
    public class GroceryDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<GroceryList> GroceryLists { get; set; }

        public GroceryDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryListGrocery>()
                .HasKey(glg => new {glg.GroceryId, glg.GroceryListId});
        }
    }
}