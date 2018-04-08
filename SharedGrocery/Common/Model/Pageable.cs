namespace SharedGrocery.Common.Model
{
    /// <summary>
    /// Page options
    /// </summary>
    public class Pageable
    {
        public int Page { get; set; }
        public int Size { get; set; } = 10;
    }
}