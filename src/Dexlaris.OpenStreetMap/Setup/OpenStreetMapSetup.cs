using Dexlaris.OpenStreetMap.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dexlaris.OpenStreetMap.Setup;

public static class OpenStreetMapSetup
{
    public static void ConfigureOpenStreetMap(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureOptions<OpenStreetMapConfigSetup>();

        var osmConfig = config.GetSection(OpenStreetMapConfig.SectionName).Get<OpenStreetMapConfig>();
        ArgumentNullException.ThrowIfNull(osmConfig, nameof(osmConfig));

        services
            .AddHttpClient<IOpenStreetMapService, OpenStreetMapService>((sp, client) =>
            {
                client.BaseAddress = new Uri(osmConfig.BaseUri);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(osmConfig.UserAgent);
            })
            // optional: tweak handler lifetime or add retry policies here
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));
    }
}