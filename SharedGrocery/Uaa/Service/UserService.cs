﻿using Microsoft.Extensions.Logging;
 using SharedGrocery.Models;
 using SharedGrocery.Uaa.Model;
 using SharedGrocery.Uaa.Repository;

namespace SharedGrocery.Uaa.Service
{
    public class UserService : IUserService
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        public UserService(ILogger<UserService> logger, ILoggerFactory loggerFactory, IUserRepository userRepository)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
            _userRepository = userRepository;
        }

        public User GetUser(string tokenId, TokenType tokenType)
        {
            return _userRepository.FindByTokenIdAndTokenType(tokenId, tokenType);
        }

        public User GetUser(int id)
        {
            return _userRepository.FindOne(id);
        }

        public User Save(User user)
        {
            return _userRepository.Save(user);
        }
    }
}