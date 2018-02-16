using Microsoft.EntityFrameworkCore;
using SharedGrocery.Models;

namespace SharedGrocery.Repositories.DBContexts
{
    public class GroceryDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<GroceryList> GroceryLists { get; set; }
        public DbSet<Item> Items { get; set; }

        public GroceryDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}