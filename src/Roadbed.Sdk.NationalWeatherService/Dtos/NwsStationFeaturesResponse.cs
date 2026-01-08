namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using Newtonsoft.Json;

/// <summary>
/// Observation Station Feature from the National Weather Service.
/// </summary>
/// <remarks>
/// Represents a single observation station as a GeoJSON Feature.
/// </remarks>
internal sealed record NwsStationFeaturesResponse
{
    /// <summary>
    /// Gets or sets the station ID (URL).
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the GeoJSON type (should be "Feature").
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the geometry of the station location.
    /// </summary>
    [JsonProperty("geometry")]
    public NwsStationGeometryResponse? Geometry { get; set; }

    /// <summary>
    /// Gets or sets the station properties.
    /// </summary>
    [JsonProperty("properties")]
    public NwsStationPropertiesResponse? Properties { get; set; }
}