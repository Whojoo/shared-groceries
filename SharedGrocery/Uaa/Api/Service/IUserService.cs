using SharedGrocery.Models;
using SharedGrocery.Uaa.Model;

namespace SharedGrocery.Uaa.Api.Service
{
    public interface IUserService
    {
        /// <summary>
        /// Find a single user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User or null if none was found</returns>
        User GetUser(int id);
        
        /// <summary>
        /// Find a single user using an external id and token type
        /// </summary>
        /// <param name="tokenId">External id</param>
        /// <param name="tokenType">Token type</param>
        /// <returns>User or null if none was found</returns>
        User GetUser(string tokenId, TokenType tokenType);

        /// <summary>
        /// Save a user (also used for update).
        /// </summary>
        /// <param name="user">User to save</param>
        /// <returns>Saved user</returns>
        User Save(User user);
    }
}