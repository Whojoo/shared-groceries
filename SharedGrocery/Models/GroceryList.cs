using System.Collections.Generic;
using SharedGrocery.Models.Joins;

namespace SharedGrocery.Models
{
    public class GroceryList
    {
        public int Id { get; set; }
        public User Owner { get; set; }
        public ICollection<GroceryListGrocery> GroceryListGroceries { get; } = new List<GroceryListGrocery>();
    }
}