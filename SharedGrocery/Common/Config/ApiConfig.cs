using Microsoft.Extensions.Configuration;

namespace SharedGrocery.Common.Config
{
    public class ApiConfig
    {
        public string ApiSecret { get; }
        public long ApiExp { get; }

        public ApiConfig(IConfiguration configuration)
        {
            ApiSecret = configuration.GetValue<string>("ApiSecret");
            ApiExp = configuration.GetValue<long>("ApiExp");
        }

        public ApiConfig(string secret, long exp)
        {
            ApiSecret = secret;
            ApiExp = exp;
        }
    }
}