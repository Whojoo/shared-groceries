﻿namespace SharedGrocery.Models
{
    public class User : AbstractEntity
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}