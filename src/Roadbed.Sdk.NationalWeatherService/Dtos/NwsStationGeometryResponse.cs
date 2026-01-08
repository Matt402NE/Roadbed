namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using Newtonsoft.Json;

/// <summary>
/// GeoJSON Geometry from the National Weather Service.
/// </summary>
/// <remarks>
/// Represents the geographic location of an observation station.
/// </remarks>
internal sealed record NwsStationGeometryResponse
{
    /// <summary>
    /// Gets or sets the geometry type (e.g., "Point").
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the coordinates [longitude, latitude].
    /// </summary>
    /// <remarks>
    /// GeoJSON uses [longitude, latitude] order, which is opposite of typical latitude/longitude order.
    /// Index 0 = Longitude, Index 1 = Latitude.
    /// </remarks>
    [JsonProperty("coordinates")]
    public double[]? Coordinates { get; set; }
}