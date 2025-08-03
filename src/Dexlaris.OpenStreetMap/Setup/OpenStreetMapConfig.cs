namespace Dexlaris.OpenStreetMap.Setup;

public record OpenStreetMapConfig
{
    public const string SectionName = "OpenStreetMap";

    /// <summary>Base URI of the Nominatim API (e.g. https://nominatim.openstreetmap.org/).</summary>
    public string BaseUri { get; init; } = "https://nominatim.openstreetmap.org/";

    /// <summary>User-Agent header to identify your application.</summary>
    public string UserAgent { get; init; } = "Dexlaris.OSM/1.0";

    /// <summary>Delay between requests in milliseconds to comply with rate limits.</summary>
    public int RateLimitMs { get; init; } = 1000;
}