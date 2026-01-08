namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using Newtonsoft.Json;

/// <summary>
/// Forecast properties from the National Weather Service.
/// </summary>
/// <remarks>
/// Contains forecast generation timestamp and the list of forecast periods.
/// </remarks>
internal sealed record NwsForecastPropertyResponse
{
    /// <summary>
    /// Gets or sets the timestamp when the forecast was generated (ISO 8601 format).
    /// </summary>
    [JsonProperty("generatedAt")]
    public string? GeneratedAt { get; set; }

    /// <summary>
    /// Gets or sets the forecast periods.
    /// </summary>
    [JsonProperty("periods")]
    public NwsForecastPeriodResponse[]? Periods { get; set; }
}