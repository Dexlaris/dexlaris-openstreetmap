using Dexlaris.OpenStreetMap.DTOs;

namespace Dexlaris.OpenStreetMap.Abstractions;

public interface IOpenStreetMapService
{
    Task<OsmAddressDto?> LookupByCoordinatesAsync(
        decimal latitude,
        decimal longitude,
        CancellationToken cancellationToken = default);

    Task<OsmAddressDto?> LookupByQueryAsync(
        string query,
        CancellationToken cancellationToken = default);
}