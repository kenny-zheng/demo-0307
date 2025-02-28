using Microsoft.Extensions.Configuration;

namespace App.Common
{
    public class AppSettingHelper
    {
        private static IConfigurationRoot _configuration;
        public static IConfigurationSection GetSection(string sectionName)
        {
            if (_configuration == null)
            {
                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                string appsettingFileName = "appsettings.json";
                if (!string.IsNullOrEmpty(environmentName))
                {
                    appsettingFileName = $"appsettings.{environmentName}.json";
                }
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, appsettingFileName);
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                if (root != null)
                {
                    _configuration = root;
                }
            }
            return _configuration.GetSection(sectionName);
        }
    }
}
