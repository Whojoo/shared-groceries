using Microsoft.EntityFrameworkCore;
using SharedGrocery.Models;

namespace SharedGrocery.Repositories.DBContexts
{
    public class UaaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UaaContext(DbContextOptions<UaaContext> options) : base(options)
        {
        }
    }
}
