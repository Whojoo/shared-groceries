using Microsoft.EntityFrameworkCore;
using SharedGrocery.Uaa.Model;

namespace SharedGrocery.Uaa.Repository.DBContext
{
    public class UaaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UaaContext(DbContextOptions<UaaContext> options) : base(options)
        {
        }
    }
}
