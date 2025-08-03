using System.Text.Json;
using Dexlaris.OpenStreetMap.Abstractions;
using Dexlaris.OpenStreetMap.DTOs;
using Dexlaris.OpenStreetMap.Setup;
using Microsoft.Extensions.Options;

namespace Dexlaris.OpenStreetMap;

public class OpenStreetMapService(
    HttpClient httpClient,
    IOptions<OpenStreetMapConfig> options
) : IOpenStreetMapService
{
    private readonly OpenStreetMapConfig _config = options.Value;

    private readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<OsmAddressDto?> LookupByCoordinatesAsync(
        decimal latitude,
        decimal longitude,
        CancellationToken cancellationToken = default)
    {
        // Respect Nominatim rate limits
        await Task.Delay(_config.RateLimitMs, cancellationToken);

        var url = $"reverse?format=jsonv2&lat={latitude}&lon={longitude}&addressdetails=1";
        using var response = await httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<OsmLocationNominatimResponseDto>(json, _jsonOptions);

        if (result?.Address is null)
            return null;

        return result.Address with
        {
            DisplayName = result.DisplayName ?? string.Empty,
            Latitude = latitude,
            Longitude = longitude
        };
    }

    public async Task<OsmAddressDto?> LookupByQueryAsync(
        string query,
        CancellationToken cancellationToken = default)
    {
        await Task.Delay(_config.RateLimitMs, cancellationToken);

        var encoded = Uri.EscapeDataString(query);
        var url = $"search?format=jsonv2&q={encoded}&addressdetails=1&limit=1";
        using var response = await httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var results = JsonSerializer.Deserialize<OsmLocationNominatimResponseDto[]>(json, _jsonOptions);

        return results?.FirstOrDefault()?.Address;
    }
}