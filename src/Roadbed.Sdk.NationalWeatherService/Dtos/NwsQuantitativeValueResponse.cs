namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using Newtonsoft.Json;

/// <summary>
/// Quantitative Value from the National Weather Service.
/// </summary>
/// <remarks>
/// Represents a measurement value with its unit of measure.
/// </remarks>
internal sealed record NwsQuantitativeValueResponse
{
    /// <summary>
    /// Gets or sets the unit code (WMO unit identifier).
    /// </summary>
    [JsonProperty("unitCode")]
    public string? UnitCode { get; set; }

    /// <summary>
    /// Gets or sets the numeric value.
    /// </summary>
    [JsonProperty("value")]
    public double? Value { get; set; }
}