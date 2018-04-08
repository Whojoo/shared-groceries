using SharedGrocery.Common.Api.Repository;
using SharedGrocery.Common.Model;
using SharedGrocery.GroceryService.Model;

namespace SharedGrocery.GroceryService.Api.Repository
{
    public interface IGroceryListRepository : IBaseRepository<GroceryList>
    {
        /// <summary>
        /// Find a page of a user's grocery lists ordered by creation time
        /// </summary>
        /// <param name="pageable">Page details</param>
        /// <param name="ownerId">Owner of the list</param>
        /// <returns>Page of grocery lists</returns>
        Page<GroceryList> FindPageOrderByCreationTime(Pageable pageable, int ownerId);
    }
}