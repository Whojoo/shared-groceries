using SharedGrocery.Common.Config;

namespace SharedGrocery.Common.Util
{
    public static class DbConfigExtension
    {
        public static string GetConnectionString(this DbConfig config)
        {
            return $"Host={config.Host};Port={config.Port};Database={config.Database};Username={config.Username};Password={config.Password}";
        }
    }
}