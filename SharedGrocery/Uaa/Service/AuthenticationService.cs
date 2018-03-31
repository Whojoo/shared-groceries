﻿using System.Threading.Tasks;
 using JWT.Algorithms;
 using JWT.Builder;
 using Microsoft.Extensions.Logging;
 using SharedGrocery.Common.Api.Util;
 using SharedGrocery.Common.Config;
 using SharedGrocery.Common.Util;
 using SharedGrocery.Models;
 using SharedGrocery.Uaa.Api.Service;
 using SharedGrocery.Uaa.Api.Util;
 using SharedGrocery.Uaa.Model;

namespace SharedGrocery.Uaa.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApiConfig _apiConfig;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IUserService _userService;
        private readonly IExternalIdUtil _externalIdUtil;
        private readonly IClock _clock;

        public AuthenticationService(ILogger<AuthenticationService> logger, IUserService userService,
            ApiConfig apiConfig, IExternalIdUtil externalIdUtil, IClock clock)
        {
            _logger = logger;
            _userService = userService;
            _externalIdUtil = externalIdUtil;
            _clock = clock;
            _apiConfig = apiConfig;
        }

        public async Task<string> GenerateJwtFromGoogleToken(string idToken)
        {
            var payload = await _externalIdUtil.ValidateExternalId(idToken);
            
            var user = _userService.GetUser(payload.Id, TokenType.GOOGLE);
            if (user == null)
            {
                _logger.LogInformation("Creating new Google user");
                user = new User
                {
                    TokenId = payload.Id,
                    TokenType = TokenType.GOOGLE
                };
                user = _userService.Save(user);
            }

            var token = GenerateJwt(user);

            _logger.LogInformation($"Generated for user {user.Id} jwt {token}");
            
            return token;
        }

        private string GenerateJwt(User user)
        {
            return new JwtBuilder().GetDefaultJwtConfig(_apiConfig)
                .AddClaim("subject", user.Id)
                .AddClaim("subjectType", user.TokenType)
                .AddClaim("exp", _clock.NowSeconds() + _apiConfig.ApiExp)
                .Build();
        }
    }
}