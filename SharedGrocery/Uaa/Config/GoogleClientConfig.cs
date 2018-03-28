using System;
using Microsoft.Extensions.Configuration;

namespace SharedGrocery.Uaa.Config
{
    public class GoogleClientConfig
    {
        public string ClientId { get; }

        public GoogleClientConfig(IConfiguration configuration)
        {
            ClientId = configuration.GetValue<string>("GOOGLE_CLIENT_ID");
            if (ClientId == null)
            {
                throw new ArgumentException("Need Google client id to perform authentication!");
            }
        }
    }
}