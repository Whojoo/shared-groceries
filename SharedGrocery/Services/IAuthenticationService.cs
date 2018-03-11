using System.Threading.Tasks;

namespace SharedGrocery.Services
{
    public interface IAuthenticationService
    {
        Task<bool> VerifyGoogleIdToken(string idToken);
    }
}