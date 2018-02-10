using System.Collections.Generic;

namespace SharedGrocery.Models
{
    public class GroceryList : AbstractEntity
    {
        public User Owner { get; set; }
        public ICollection<Grocery> Groceries { get; } = new List<Grocery>();
    }
}