namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using Newtonsoft.Json;

/// <summary>
/// Location properties from the National Weather Service grid coordinate response.
/// </summary>
/// <remarks>
/// Contains grid coordinates, URLs to forecast products, and zone information
/// for a specific geographic location.
/// </remarks>
internal sealed record NwsLocationPropertyResponse
{
    /// <summary>
    /// Gets or sets the grid X coordinate.
    /// </summary>
    [JsonProperty("gridX")]
    public int? GridCoordinateX { get; set; }

    /// <summary>
    /// Gets or sets the grid Y coordinate.
    /// </summary>
    [JsonProperty("gridY")]
    public int? GridCoordinateY { get; set; }

    /// <summary>
    /// Gets or sets the county zone URL.
    /// </summary>
    [JsonProperty("county")]
    public string? County { get; set; }

    /// <summary>
    /// Gets or sets the fire weather zone URL.
    /// </summary>
    [JsonProperty("fireWeatherZone")]
    public string? FireWeatherZone { get; set; }

    /// <summary>
    /// Gets or sets the forecast grid data URL.
    /// </summary>
    [JsonProperty("forecastGridData")]
    public string? ForecastGridData { get; set; }

    /// <summary>
    /// Gets or sets the hourly forecast URL.
    /// </summary>
    [JsonProperty("forecastHourly")]
    public string? ForecastHourly { get; set; }

    /// <summary>
    /// Gets or sets the forecast office URL.
    /// </summary>
    [JsonProperty("forecastOffice")]
    public string? ForecastOffice { get; set; }

    /// <summary>
    /// Gets or sets the forecast office identifier (grid ID).
    /// </summary>
    [JsonProperty("gridId")]
    public string? ForecastOfficeId { get; set; }

    /// <summary>
    /// Gets or sets the daily forecast URL.
    /// </summary>
    [JsonProperty("forecast")]
    public string? ForecastUrl { get; set; }

    /// <summary>
    /// Gets or sets the forecast zone URL.
    /// </summary>
    [JsonProperty("forecastZone")]
    public string? ForecastZone { get; set; }

    /// <summary>
    /// Gets or sets the observation stations URL.
    /// </summary>
    [JsonProperty("observationStations")]
    public string? ObservationStations { get; set; }

    /// <summary>
    /// Gets or sets the IANA time zone identifier.
    /// </summary>
    [JsonProperty("timeZone")]
    public string? TimeZone { get; set; }
}