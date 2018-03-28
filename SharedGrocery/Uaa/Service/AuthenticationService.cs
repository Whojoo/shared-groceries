﻿using System.IdentityModel.Tokens.Jwt;
 using System.Security.Claims;
 using System.Threading.Tasks;
 using Microsoft.Extensions.Logging;
 using Microsoft.IdentityModel.Tokens;
 using SharedGrocery.Common.Api.Util;
 using SharedGrocery.Common.Config;
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

            var jwt = GenerateJwt(user);
            _logger.LogInformation($"Generated for user {user.Id} jwt {jwt}");
            return jwt;
        }

        private string GenerateJwt(User user)
        {
            var claims = new[]
            {
                new Claim("subject", user.Id.ToString()),
                new Claim("subjectType", user.TokenType.ToString())
            };

            var key = new SymmetricSecurityKey(_apiConfig.ApiSecret);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken("robindegier.nl", "robindegier.nl", claims,
                expires: _clock.Now().AddHours(1), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}