using System;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Logging;
using Moq;
using SharedGrocery.Common.Api.Util;
using SharedGrocery.Common.Config;
using SharedGrocery.Common.Model;
using SharedGrocery.Common.Util;
using SharedGrocery.Models;
using SharedGrocery.Uaa.Api.Model;
using SharedGrocery.Uaa.Api.Service;
using SharedGrocery.Uaa.Api.Util;
using SharedGrocery.Uaa.Model;
using SharedGrocery.Uaa.Service;
using Xunit;

namespace SharedGrocery.Tests.Uaa.Service
{
    public class AuthenticationServiceTest
    {
        private const string ApiSecret = "thisisnotthesecretyouarelookingfor";
        private const long ExpTime = 3600;

        private readonly AuthenticationService _authenticationService;
        
        // Configs
        private readonly ApiConfig _apiConfig = new ApiConfig(ApiSecret, ExpTime);

        // Mocks
        private readonly Mock<IUserService> _userServiceMock = new Mock<IUserService>();
        private readonly Mock<ILogger<AuthenticationService>> _loggerMock = new Mock<ILogger<AuthenticationService>>();
        private readonly Mock<IExternalIdUtil> _googleIdUtilMock = new Mock<IExternalIdUtil>();
        private readonly Mock<IClock> _clockMock = new Mock<IClock>();

        public AuthenticationServiceTest()
        {
            _authenticationService = new AuthenticationService(_loggerMock.Object, _userServiceMock.Object,
                _apiConfig, _googleIdUtilMock.Object, _clockMock.Object);
        }

        [Fact]
        public void TestGenerateJwtFromGoogleToken()
        {
            // GIVEN
            const string subject = "subject";
            const string tokenId = "tokenId";
            const int userId = 1337;
            var payload = new ExternalIdPayload
            {
                Id = subject
            };
            var user = new User
            {
                Id = userId,
                TokenId = tokenId,
                TokenType = TokenType.GOOGLE
            };
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            var future = now + ExpTime;

            // WHEN
            _googleIdUtilMock.Setup(util => util.ValidateExternalId(It.Is<string>(token => tokenId.Equals(token))))
                .ReturnsAsync(payload);
            _userServiceMock.Setup(service =>
                service.GetUser(
                    It.Is<string>(subjectString => subject.Equals(subjectString)),
                    It.Is<TokenType>(token => TokenType.GOOGLE.Equals(token))))
                .Returns(user);
            _clockMock.Setup(clock => clock.NowSeconds()).Returns(now);

            // INVOKE
            var jwtTaskResult = _authenticationService.GenerateJwtFromGoogleToken(tokenId);

            // THEN
            var jwt = jwtTaskResult.Result;
            Assert.NotNull(jwt);
            var userContext = new JwtBuilder()
                .GetDefaultJwtConfig(_apiConfig)
                .MustVerifySignature()
                .Decode<UserContext>(jwt);
            
            Assert.NotNull(userContext);
            Assert.Equal(userId, userContext.Subject);
            Assert.Equal(TokenType.GOOGLE, userContext.SubjectType);
            Assert.Equal(future, userContext.Exp);
        }
    }
}