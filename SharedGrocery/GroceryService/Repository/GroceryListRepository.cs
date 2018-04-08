using System.Linq;
using Microsoft.EntityFrameworkCore;
using SharedGrocery.Common.Model;
using SharedGrocery.Common.Repository;
using SharedGrocery.GroceryService.Api.Repository;
using SharedGrocery.GroceryService.Model;

namespace SharedGrocery.GroceryService.Repository
{
    public class GroceryListRepository : BaseRepository<GroceryList>, IGroceryListRepository
    {
        public GroceryListRepository(DbContext context, DbSet<GroceryList> dbSet) : base(context, dbSet)
        {
        }

        public Page<GroceryList> FindPageOrderByCreationTime(Pageable pageable, int ownerId)
        {
            var count = DbSet.Count();
            var lists = DbSet.Where(list => list.OwnerId == ownerId)
                .OrderByDescending(list => list.CreationDate)
                .Skip(pageable.Page * pageable.Size)
                .Take(pageable.Size)
                .ToList();
            
            return new Page<GroceryList>
            {
                Content = lists,
                TotalCount = count
            };
        }
    }
}