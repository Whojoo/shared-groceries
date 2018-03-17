using SharedGrocery.Common.Repository;
using SharedGrocery.Models;
using SharedGrocery.Uaa.Model;

namespace SharedGrocery.Uaa.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User FindByTokenIdAndTokenType(string tokenId, TokenType tokenType);
    }
}