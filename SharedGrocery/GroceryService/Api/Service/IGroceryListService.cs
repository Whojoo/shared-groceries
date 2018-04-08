using SharedGrocery.Common.Model;
using SharedGrocery.GroceryService.Dto;

namespace SharedGrocery.GroceryService.Api.Service
{
    public interface IGroceryListService
    {
        /// <summary>
        /// Returns a page of grocery lists, orderd by creation date.
        /// </summary>
        /// <param name="pageable">Page details</param>
        /// <param name="userContext">Current user context</param>
        /// <returns>Page of grocery lists</returns>
        Page<GroceryListDto> GetPage(Pageable pageable, UserContext userContext);

        /// <summary>
        /// Create a new list for a user.
        /// </summary>
        /// <param name="userContext">Current user context</param>
        /// <returns>The newly created list</returns>
        GroceryListDto CreateList(UserContext userContext);
    }
}