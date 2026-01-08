namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using Newtonsoft.Json;

/// <summary>
/// Precipitation probability from the National Weather Service forecast.
/// </summary>
/// <remarks>
/// Represents the probability of precipitation for a forecast period.
/// </remarks>
internal sealed record NwsForecastPrecipitationResponse
{
    /// <summary>
    /// Gets or sets the unit code (typically "wmoUnit:percent").
    /// </summary>
    [JsonProperty("unitCode")]
    public string? Unit { get; set; }

    /// <summary>
    /// Gets or sets the precipitation probability value (0-100).
    /// </summary>
    [JsonProperty("value")]
    public string? Value { get; set; }
}