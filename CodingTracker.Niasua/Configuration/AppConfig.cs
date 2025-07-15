using Microsoft.Extensions.Configuration;

namespace CodingTracker.Niasua.Configuration;

internal static class AppConfig
{
    private static IConfigurationRoot configuration;

    static AppConfig()
    {
        configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public static string GetConnectionString()
    {
        return configuration.GetConnectionString("DefaultConnection");
    }
}
