namespace SharedGrocery.Models
{
    public class Grocery : AbstractEntity
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }
    }
}