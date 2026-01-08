namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using Newtonsoft.Json;

/// <summary>
/// Observation Station Properties from the National Weather Service.
/// </summary>
/// <remarks>
/// Contains detailed information about an observation station.
/// </remarks>
internal sealed record NwsStationPropertiesResponse
{
    /// <summary>
    /// Gets or sets the station ID (URL).
    /// </summary>
    [JsonProperty("@id")]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the station type.
    /// </summary>
    [JsonProperty("@type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the elevation information.
    /// </summary>
    [JsonProperty("elevation")]
    public NwsQuantitativeValueResponse? Elevation { get; set; }

    /// <summary>
    /// Gets or sets the station identifier code.
    /// </summary>
    [JsonProperty("stationIdentifier")]
    public string? StationIdentifier { get; set; }

    /// <summary>
    /// Gets or sets the station name.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the time zone (IANA time zone identifier).
    /// </summary>
    [JsonProperty("timeZone")]
    public string? TimeZone { get; set; }

    /// <summary>
    /// Gets or sets the forecast zone URL.
    /// </summary>
    [JsonProperty("forecast")]
    public string? ForecastUrl { get; set; }

    /// <summary>
    /// Gets or sets the county zone URL.
    /// </summary>
    [JsonProperty("county")]
    public string? CountyUrl { get; set; }

    /// <summary>
    /// Gets or sets the fire weather zone URL.
    /// </summary>
    [JsonProperty("fireWeatherZone")]
    public string? FireWeatherZoneUrl { get; set; }
}