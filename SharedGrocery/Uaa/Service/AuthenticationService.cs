﻿using System;
 using System.IdentityModel.Tokens.Jwt;
 using System.Security.Claims;
 using System.Text;
 using System.Threading.Tasks;
 using Google.Apis.Auth;
 using Microsoft.Extensions.Logging;
 using Microsoft.IdentityModel.Tokens;
 using SharedGrocery.Common;
 using SharedGrocery.Common.Config;
 using SharedGrocery.Models;
 using SharedGrocery.Uaa.Config;
 using SharedGrocery.Uaa.Model;

namespace SharedGrocery.Uaa.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string _googleClientId;
        private readonly byte[] _apiSecret;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IUserService _userService;

        public AuthenticationService(ILogger<AuthenticationService> logger, IUserService userService,
            GoogleClientConfig googleClientConfig, ApiConfig apiConfig)
        {
            _logger = logger;
            _userService = userService;
            _googleClientId = googleClientConfig.ClientId;
            _apiSecret = apiConfig.ApiSecret;
        }

        public async Task<string> GenerateJwtFromGoogleToken(string idToken)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            if (!IsPayloadValid(payload))
            {
                return null;
            }
            
            var user = _userService.GetUser(payload.Subject, TokenType.GOOGLE);
            if (user == null)
            {
                user = new User
                {
                    TokenId = payload.Subject,
                    TokenType = TokenType.GOOGLE
                };
                user = _userService.Save(user);
            }

            return GenerateJwt(user);
        }

        private string GenerateJwt(User user)
        {
            var claims = new[]
            {
                new Claim("subject", user.Id.ToString()),
                new Claim("subjectType", user.TokenType.ToString())
            };

            var key = new SymmetricSecurityKey(_apiSecret);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken("robindegier.nl", "robindegier.nl", claims,
                expires: DateTime.Now.AddHours(1), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool IsPayloadValid(GoogleJsonWebSignature.Payload arg)
        {
            return _googleClientId.Equals(arg.Audience);
        }
    }
}