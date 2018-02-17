using System.Collections.Generic;

namespace SharedGrocery.Models
{
    public class GroceryList : AbstractEntity
    {
        public int OwnerId { get; set; }
        public ICollection<Grocery> Groceries { get; } = new List<Grocery>();
    }
}