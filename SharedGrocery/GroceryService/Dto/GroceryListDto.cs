using System;
using System.Collections.Generic;

namespace SharedGrocery.GroceryService.Dto
{
    public class GroceryListDto
    {
        public IEnumerable<GroceryDto> Groceries { get; set; } = new List<GroceryDto>();
        public DateTime CreationDate { get; set; }
    }
}