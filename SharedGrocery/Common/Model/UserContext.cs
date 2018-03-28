﻿using System;
using SharedGrocery.Models;

namespace SharedGrocery.Common.Model
{
    public class UserContext
    {
        public int Subject { get; set; }
        public TokenType SubjectType { get; set; }
        public DateTime Exp { get; set; }
    }
}