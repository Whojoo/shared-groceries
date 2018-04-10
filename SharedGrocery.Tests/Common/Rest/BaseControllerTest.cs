using System;
using System.Collections.Generic;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;
using SharedGrocery.Common.Api.Util;
using SharedGrocery.Common.Config;
using SharedGrocery.Common.Model;
using SharedGrocery.Common.Util;
using SharedGrocery.Models;
using SharedGrocery.Tests.TestUtil.Rest;
using Xunit;

namespace SharedGrocery.Tests.Common.Rest
{
    public class BaseControllerTest
    {
        private const String Secret = "thisisasecret";
        private const long Exp = 3600;
        
        private readonly TestBaseController _controller;
        private readonly ApiConfig _apiConfig;
        private readonly ControllerContext _context;
        private readonly IClock _clock;

        public BaseControllerTest()
        {
            _apiConfig = new ApiConfig(Secret, Exp);
            _controller = new TestBaseController(_apiConfig);
            _context = new ControllerContext();
            _controller.ControllerContext = _context;
            _clock = new Clock();
        }

        [Fact]
        public void TestGetUserContext()
        {
            // GIVEN;
            const int userId = 1;
            const TokenType tokenType = TokenType.GOOGLE;
            var now = _clock.NowSeconds();
            var jwt = new JwtBuilder().GetDefaultJwtConfig(_apiConfig)
                .AddClaim("subject", userId)
                .AddClaim("subjectType", tokenType)
                .AddClaim("exp", now + Exp)
                .Build();
            var userContext = new UserContext
            {
                Exp = now + Exp,
                Subject = userId,
                SubjectType = TokenType.GOOGLE
            };
            
            IHeaderDictionary headerDictionary = new HeaderDictionary();
            headerDictionary.Add("Authorization", new StringValues($"Bearer {jwt}"));
            var request = new TestHttpRequest(headerDictionary);
            var requestContext = new TestHttpContext(request);
            _context.HttpContext = requestContext;
            
            // WHEN
            
            // INVOKE
            var result = _controller.CallGetUserContext();

            // THEN
            Assert.NotNull(result);
            Assert.Equal(userContext.Subject, result.Subject);
            Assert.Equal(userContext.Exp, result.Exp);
            Assert.Equal(userContext.SubjectType, result.SubjectType);
        }
    }
}