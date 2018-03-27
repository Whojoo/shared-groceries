using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using SharedGrocery.Uaa.Service;
using Xunit;

namespace SharedGrocery.Tests.Uaa.Service
{
    public class AuthenticationServiceTest
    {
        private readonly IAuthenticationService _authenticationService;

        private readonly Mock<IUserService> _userService = new Mock<IUserService>();
        private readonly Mock<IConfiguration> _configuration = new Mock<IConfiguration>();
        private readonly Mock<ILogger<AuthenticationService>> _logger = new Mock<ILogger<AuthenticationService>>();

        public AuthenticationServiceTest()
        {
            _authenticationService = new AuthenticationService(_logger.Object, _configuration.Object, _userService.Object);
        }

        [Fact]
        public void TestGenerateJwtFromGoogleToken()
        {
            
        }
    }
}