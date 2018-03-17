﻿using SharedGrocery.Models;
 using SharedGrocery.Uaa.Model;

namespace SharedGrocery.Uaa.Service
{
    public interface IUserService
    {
        User GetUser(int id);
        
        User GetUser(string tokenId, TokenType tokenType);

        User Save(User user);
    }
}