using System.Collections.Generic;

namespace SharedGrocery.Common.Model
{
    /// <summary>
    /// Page of content
    /// </summary>
    public class Page<TContent>
    {
        public IEnumerable<TContent> Content { get; set; }
        public int TotalCount { get; set; }
    }
}