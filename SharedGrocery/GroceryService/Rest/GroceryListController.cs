using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedGrocery.Common.Config;
using SharedGrocery.Common.Model;
using SharedGrocery.Common.Rest;
using SharedGrocery.GroceryService.Api.Service;

namespace SharedGrocery.GroceryService.Rest
{
    [Authorize]
    [Route("api/[controller]")]
    public class GroceryListController : BaseController
    {
        private readonly IGroceryListService _groceryListService;

        public GroceryListController(IGroceryListService groceryListService, ApiConfig apiConfig) : base(apiConfig)
        {
            _groceryListService = groceryListService;
        }

        /// <summary>
        /// Get a page of grocery lists
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPage([FromQuery] int page, [FromQuery] int size)
        {
            if (page < 0 || size <= 0)
            {
                return BadRequest($"Page or Size was invalid. Page: {page} (0 or higher), Size: {size} (bigger than 0");
            }
            
            return Ok(_groceryListService.GetPage(new Pageable
            {
                Page = page,
                Size = size
            }, GetUserContext()));
        }

        [HttpPost]
        public IActionResult CreateList()
        {
            return Ok(_groceryListService.CreateList(GetUserContext()));
        }
    }
}