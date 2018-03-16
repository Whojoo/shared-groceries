﻿using Microsoft.Extensions.Logging;

namespace SharedGrocery.Uaa.Service
{
    public class UserService : IUserService
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
        }
    }
}