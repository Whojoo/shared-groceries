﻿using System;
 using System.Collections.Generic;
using SharedGrocery.Common.Model;

namespace SharedGrocery.GroceryService.Model
{
    public class GroceryList : AbstractEntity
    {
        public int OwnerId { get; set; }
        public ICollection<Grocery> Groceries { get; } = new List<Grocery>();
        public DateTime CreationDate { get; set; }
    }
}