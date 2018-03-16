using SharedGrocery.Common.Model;

namespace SharedGrocery.GroceryService.Model
{
    public class Item : AbstractEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Barcode { get; set; }
    }
}