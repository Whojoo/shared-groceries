using SharedGrocery.Common.Api.Repository;
using SharedGrocery.Models;
using SharedGrocery.Uaa.Model;

namespace SharedGrocery.Uaa.Api.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Find a user by external id and token type.
        /// </summary>
        /// <param name="tokenId">External id</param>
        /// <param name="tokenType">Token type</param>
        /// <returns>User or null of none was found</returns>
        User FindByTokenIdAndTokenType(string tokenId, TokenType tokenType);
    }
}