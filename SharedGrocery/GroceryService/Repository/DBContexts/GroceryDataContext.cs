using Microsoft.EntityFrameworkCore;
using SharedGrocery.GroceryService.Model;
using SharedGrocery.Models;

namespace SharedGrocery.GroceryService.Repository.DBContexts
{
    public class GroceryDataContext : DbContext
    {
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<GroceryList> GroceryLists { get; set; }
        public DbSet<Item> Items { get; set; }

        public GroceryDataContext(DbContextOptions<GroceryDataContext> options) : base(options)
        {
        }
    }
}