using System.Threading.Tasks;
using SharedGrocery.Uaa.Api.Model;

namespace SharedGrocery.Uaa.Api.Util
{
    public interface IExternalIdUtil
    {
        Task<ExternalIdPayload> ValidateExternalId(string idToken);
    }
}