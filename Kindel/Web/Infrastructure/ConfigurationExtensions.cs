using Microsoft.Extensions.Configuration;

namespace Web.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetDataBaseConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString(ConfigurationSectionNameConstants.DatabaseConnectionStringKey);
        }
    }
}
