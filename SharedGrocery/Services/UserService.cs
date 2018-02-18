using Microsoft.Extensions.Logging;
using SharedGrocery.Repositories;

namespace SharedGrocery.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger, ILoggerFactory loggerFactory, IUserRepository userRepository)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
            _userRepository = userRepository;
        }

        public void ValidateGoogleToken(string token)
        {
            _logger.LogInformation($"Starting google validation with token {token}");
        }
    }
}