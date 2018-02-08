using SharedGrocery.Models;
using SharedGrocery.Repositories.DBContexts;

namespace SharedGrocery.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GroceryDataContext context) : base(context, context.Users)
        {
        }
    }
}