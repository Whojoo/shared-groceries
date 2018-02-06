namespace SharedGrocery.Models.Joins
{
    public class GroceryListGrocery
    {
        public int GroceryListId { get; set; }
        public GroceryList GroceryList { get; set; }
        
        public int GroceryId { get; set; }
        public Grocery Grocery { get; set; }
    }
}