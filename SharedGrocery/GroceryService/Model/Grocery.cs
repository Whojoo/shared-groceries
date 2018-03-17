﻿using SharedGrocery.Common.Model;

namespace SharedGrocery.GroceryService.Model
{
    public class Grocery : AbstractEntity
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }
    }
}