using System.Collections.Generic;
using SharedGrocery.Models.Joins;

namespace SharedGrocery.Models
{
    public class Grocery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GroceryListGrocery> GroceryListGroceries { get; } = new List<GroceryListGrocery>();
    }
}