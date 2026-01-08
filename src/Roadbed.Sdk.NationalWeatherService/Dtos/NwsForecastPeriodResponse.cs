namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using System;
using Newtonsoft.Json;

/// <summary>
/// Forecast period from the National Weather Service.
/// </summary>
/// <remarks>
/// Represents a single forecast period (e.g., "Tonight", "Monday", "Tuesday Morning")
/// with weather conditions, temperature, and precipitation information.
/// </remarks>
internal sealed record NwsForecastPeriodResponse
{
    /// <summary>
    /// Gets or sets the period number (sequential ordering).
    /// </summary>
    [JsonProperty("number")]
    public int? Number { get; set; }

    /// <summary>
    /// Gets or sets the period name (e.g., "Tonight", "Monday", "Monday Night").
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the start time of the forecast period.
    /// </summary>
    [JsonProperty("startTime")]
    public DateTimeOffset? StartTime { get; set; }

    /// <summary>
    /// Gets or sets the end time of the forecast period.
    /// </summary>
    [JsonProperty("endTime")]
    public DateTimeOffset? EndTime { get; set; }

    /// <summary>
    /// Gets or sets whether this is a daytime period.
    /// </summary>
    [JsonProperty("isDaytime")]
    public bool? IsDayTime { get; set; }

    /// <summary>
    /// Gets or sets the temperature for this period.
    /// </summary>
    [JsonProperty("temperature")]
    public decimal? Temperature { get; set; }

    /// <summary>
    /// Gets or sets the temperature unit (typically "F" for Fahrenheit or "C" for Celsius).
    /// </summary>
    [JsonProperty("temperatureUnit")]
    public string? TemperatureUnit { get; set; }

    /// <summary>
    /// Gets or sets the wind speed (e.g., "5 to 10 mph").
    /// </summary>
    [JsonProperty("windSpeed")]
    public string? WindSpeed { get; set; }

    /// <summary>
    /// Gets or sets the wind direction (e.g., "N", "NE", "SW").
    /// </summary>
    [JsonProperty("windDirection")]
    public string? WindDirection { get; set; }

    /// <summary>
    /// Gets or sets the short forecast description.
    /// </summary>
    [JsonProperty("shortForecast")]
    public string? ForecastShort { get; set; }

    /// <summary>
    /// Gets or sets the detailed forecast description.
    /// </summary>
    [JsonProperty("detailedForecast")]
    public string? ForecastDetailed { get; set; }

    /// <summary>
    /// Gets or sets the probability of precipitation.
    /// </summary>
    [JsonProperty("probabilityOfPrecipitation")]
    public NwsForecastPrecipitationResponse? Precipitation { get; set; }
}