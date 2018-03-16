﻿using System.Threading.Tasks;

namespace SharedGrocery.Uaa.Service
{
    public interface IAuthenticationService
    {
        Task<bool> VerifyGoogleIdToken(string idToken);
    }
}