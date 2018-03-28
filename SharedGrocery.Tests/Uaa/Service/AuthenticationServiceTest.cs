using System;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using SharedGrocery.Common.Api.Util;
using SharedGrocery.Common.Config;
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
        private static readonly byte[] ApiSecret = Encoding.UTF8.GetBytes("thisisnotthesecretyouarelookingfor");
        
        private readonly AuthenticationService _authenticationService;
        
        // Configs
        private readonly ApiConfig _apiConfig = new ApiConfig(ApiSecret);

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
            var now = new DateTime(0, DateTimeKind.Utc);
            var hour = now.AddHours(1);

            // WHEN
            _googleIdUtilMock.Setup(util => util.ValidateExternalId(It.Is<string>(token => tokenId.Equals(token))))
                .ReturnsAsync(payload);
            _userServiceMock.Setup(service =>
                service.GetUser(
                    It.Is<string>(subjectString => subject.Equals(subjectString)),
                    It.Is<TokenType>(token => TokenType.GOOGLE.Equals(token))))
                .Returns(user);
            _clockMock.Setup(clock => clock.Now()).Returns(now);

            // INVOKE
            var jwtTaskResult = _authenticationService.GenerateJwtFromGoogleToken(tokenId);

            // THEN
            var jwtResult = jwtTaskResult.Result;
            Assert.NotNull(jwtResult);
            var jwtPayload = jwtResult.Split('.')[1];
            // Base64 strings are multiple of 4, if not then add =. C# is not smart enough to do so itself...
            while (jwtPayload.Length % 4 != 0)
            {
                jwtPayload += '=';
            }
            var jwtPayloadDecoded = Convert.FromBase64String(jwtPayload);
            var jObject = JObject.Parse(Encoding.UTF8.GetString(jwtPayloadDecoded));
            Assert.NotNull(jObject);
            Assert.Equal(userId.ToString(), jObject["subject"].Value<string>());
            Assert.Equal(TokenType.GOOGLE.ToString(), jObject["subjectType"].Value<string>());
            Assert.Equal((hour - now).Seconds, jObject["exp"].Value<int>());
        }
    }
}