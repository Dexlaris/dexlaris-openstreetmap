using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Dexlaris.OpenStreetMap.Setup;

public class OpenStreetMapConfigSetup(IConfiguration configuration)
    : IConfigureOptions<OpenStreetMapConfig>
{
    public void Configure(OpenStreetMapConfig options)
    {
        configuration
            .GetSection(OpenStreetMapConfig.SectionName)
            .Bind(options);
    }
}