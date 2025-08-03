using System.Text.Json.Serialization;

namespace Dexlaris.OpenStreetMap.DTOs;

// x, Džohara Dudajeva gatve, Purvciems, Teikas apkaime, Rīga, LV-1084, Latvija
public record OsmAddressDto
{
    public string DisplayName { get; set; } = string.Empty;
    
    public decimal Latitude { get; init; }

    public decimal Longitude { get; init; }

    [JsonPropertyName("house_number")]
    public string? HouseNumber { get; set; }

    [JsonPropertyName("road")]
    public string? Road { get; set; } 
    
    [JsonPropertyName("municipality")]
    public string? Municipality { get; set; }

    [JsonPropertyName("suburb")]
    public string? Suburb { get; set; }

    [JsonPropertyName("city_district")]
    public string? CityDistrict { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("ISO3166-2-lvl5")]
    public string? Iso { get; set; }

    [JsonPropertyName("postcode")]
    public string? Postcode { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }
}