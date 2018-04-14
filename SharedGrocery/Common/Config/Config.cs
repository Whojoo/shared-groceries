using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharedGrocery.Common.Config
{
    public class Config
    {
        public Logging Logging { get; set; }
        
        public AppConfig SharedGroceries { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; } = false;

        public LogDetails Debug { get; set; }
        
        public LogDetails Console { get; set; }
        
        public IDictionary<string, string> LogLevel { get; set; } = new Dictionary<string, string>();
    }

    public class LogDetails
    {
        public IDictionary<string, string> LogLevel { get; set; } = new Dictionary<string, string>();
    }

    public class AppConfig
    {
        public ApiConfig Api { get; set; }
        
        public DbConfigs Data { get; set; }
        
        public UaaConfig Uaa { get; set; }
    }

    public class UaaConfig
    {
        public UaaGoogleConfig Google { get; set; }
    }

    public class UaaGoogleConfig
    {
        public string ClientId { get; set; }
    }
    
    public class DbConfigs
    {
        public DbConfig Uaa { get; set; }
        
        public DbConfig Groceries { get; set; }
    }

    public class DbConfig
    {
        public string Host { get; set; }
        
        public string Port { get; set; }
        
        public string Database { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
    }
    
    public class ApiConfig
    {
        public string ApiSecret { get; set; }
        
        public long ApiExp { get; set; }
    }
}