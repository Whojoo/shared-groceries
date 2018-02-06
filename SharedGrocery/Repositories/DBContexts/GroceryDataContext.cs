using Microsoft.EntityFrameworkCore;
using SharedGrocery.Models;
using SharedGrocery.Models.Joins;

namespace SharedGrocery.Repositories.DBContexts
{
    public partial class GroceryDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<GroceryList> GroceryLists { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=localhost,1433;Initial Catalog=groceries;Integrated Security=False;User ID=sa;Password=Passw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryListGrocery>()
                .HasKey(glg => new {glg.GroceryId, glg.GroceryListId});
        }
    }
}