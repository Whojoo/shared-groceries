using System.Linq;
using SharedGrocery.Common.Api.Util;
using SharedGrocery.Common.Model;
using SharedGrocery.GroceryService.Api.Repository;
using SharedGrocery.GroceryService.Api.Service;
using SharedGrocery.GroceryService.Dto;
using SharedGrocery.GroceryService.Model;

namespace SharedGrocery.GroceryService.Service
{
    public class GroceryListService : IGroceryListService
    {
        private readonly IGroceryListRepository _groceryListRepository;
        private readonly IClock _clock;

        public GroceryListService(IGroceryListRepository groceryListRepository, IClock clock)
        {
            _groceryListRepository = groceryListRepository;
            _clock = clock;
        }

        public Page<GroceryListDto> GetPage(Pageable pageable, UserContext userContext)
        {
            var page = _groceryListRepository.FindPageOrderByCreationTime(pageable, userContext.Subject);

            return new Page<GroceryListDto>
            {
                TotalCount = page.TotalCount,
                Content = page.Content.Select(list =>
                {
                    return new GroceryListDto
                    {
                        CreationDate = list.CreationDate,
                        Groceries = list.Groceries.Select(grocery => new GroceryDto())
                    };
                })
            };
        }

        public GroceryListDto CreateList(UserContext userContext)
        {
            var list = new GroceryList
            {
                CreationDate = _clock.Now(),
                OwnerId = userContext.Subject
            };
            var savedList = _groceryListRepository.Save(list);

            return new GroceryListDto
            {
                CreationDate = savedList.CreationDate
            };
        }
    }
}