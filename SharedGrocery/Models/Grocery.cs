using System.Collections.Generic;
using SharedGrocery.Models.Joins;

namespace SharedGrocery.Models
{
    public class Grocery : AbstractEntity
    {
        public string Name { get; set; }
        public ICollection<GroceryListGrocery> GroceryListGroceries { get; } = new List<GroceryListGrocery>();
    }
}