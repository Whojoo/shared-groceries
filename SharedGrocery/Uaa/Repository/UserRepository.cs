using System.Linq;
using SharedGrocery.Common.Repository;
using SharedGrocery.Models;
using SharedGrocery.Uaa.Model;
using SharedGrocery.Uaa.Repository.DBContext;

namespace SharedGrocery.Uaa.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UaaContext uaaContext) : base(uaaContext, uaaContext.Users)
        {
        }

        public User FindByTokenIdAndTokenType(string tokenId, TokenType tokenType)
        {
            return DbSet.FirstOrDefault(user => user.TokenId == tokenId && user.TokenType == tokenType);
        }
    }
}