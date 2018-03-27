using System.Text;
using Microsoft.Extensions.Configuration;

namespace SharedGrocery.Common.Config
{
    public class ApiConfig
    {
        public byte[] ApiSecret { get; }

        public ApiConfig(IConfiguration configuration)
        {
            ApiSecret = Encoding.UTF8.GetBytes(configuration.GetValue<string>("ApiSecret"));
        }
    }
}