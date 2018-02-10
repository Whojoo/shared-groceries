namespace SharedGrocery.Models
{
    public class Item : AbstractEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Barcode { get; set; }
    }
}