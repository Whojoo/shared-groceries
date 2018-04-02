using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SharedGrocery.GroceryService.Rest
{
    [Authorize]
    [Route("api/[controller]")]
    public class GroceryListController
    {
        
    }
}