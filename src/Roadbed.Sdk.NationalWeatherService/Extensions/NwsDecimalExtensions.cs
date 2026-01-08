/*
 * The namespace Roadbed.Sdk.NationalWeatherService.Extensions was removed on purpose and replaced with Roadbed.Sdk.NationalWeatherService so that no additional using statements are required.
 */

namespace Roadbed.Sdk.NationalWeatherService;

/// <summary>
/// Extensions for weather unit conversions.
/// </summary>
public static class NwsDecimalExtensions
{
    #region Private Constants

    /// <summary>
    /// Conversion factor for Celsius to Fahrenheit: (9/5).
    /// </summary>
    private const decimal CelsiusToFahrenheitMultiplier = 9m / 5m;

    /// <summary>
    /// Offset for Celsius to Fahrenheit conversion.
    /// </summary>
    private const decimal CelsiusToFahrenheitOffset = 32m;

    /// <summary>
    /// Conversion factor for Fahrenheit to Celsius: (5/9).
    /// </summary>
    private const decimal FahrenheitToCelsiusMultiplier = 5m / 9m;

    /// <summary>
    /// Offset for Fahrenheit to Celsius conversion.
    /// </summary>
    private const decimal FahrenheitToCelsiusOffset = 32m;

    /// <summary>
    /// Conversion factor: 1 mile = 1.609 kilometers.
    /// </summary>
    private const decimal KilometersPerMile = 1.609m;

    /// <summary>
    /// Conversion factor: 1 meter per second = 2.23694 miles per hour.
    /// </summary>
    private const decimal MetersPerSecondToMilesPerHourFactor = 2.23694m;

    /// <summary>
    /// Conversion factor: 1 mile per hour = 0.44704 meters per second.
    /// </summary>
    private const decimal MilesPerHourToMetersPerSecondFactor = 0.44704m;

    #endregion Private Constants

    #region Public Methods

    /// <summary>
    /// Converts temperature from Celsius to Fahrenheit.
    /// </summary>
    /// <param name="celsius">Temperature in Celsius (can be negative).</param>
    /// <returns>Temperature in Fahrenheit.</returns>
    /// <example>
    /// <code>
    /// decimal freezing = 0m.ConvertCelsiusToFahrenheit();    // Returns 32°F
    /// decimal boiling = 100m.ConvertCelsiusToFahrenheit();   // Returns 212°F
    /// decimal cold = (-40m).ConvertCelsiusToFahrenheit();    // Returns -40°F
    /// </code>
    /// </example>
    public static decimal ConvertCelsiusToFahrenheit(this decimal celsius)
    {
        return (celsius * CelsiusToFahrenheitMultiplier) + CelsiusToFahrenheitOffset;
    }

    /// <summary>
    /// Converts temperature from Fahrenheit to Celsius.
    /// </summary>
    /// <param name="fahrenheit">Temperature in Fahrenheit (can be negative).</param>
    /// <returns>Temperature in Celsius.</returns>
    /// <example>
    /// <code>
    /// decimal freezing = 32m.ConvertFahrenheitToCelsius();   // Returns 0°C
    /// decimal boiling = 212m.ConvertFahrenheitToCelsius();   // Returns 100°C
    /// </code>
    /// </example>
    public static decimal ConvertFahrenheitToCelsius(this decimal fahrenheit)
    {
        return (fahrenheit - FahrenheitToCelsiusOffset) * FahrenheitToCelsiusMultiplier;
    }

    /// <summary>
    /// Converts speed from kilometers per hour to miles per hour.
    /// </summary>
    /// <param name="kilometersPerHour">Speed in kilometers per hour.</param>
    /// <returns>Speed in miles per hour.</returns>
    /// <example>
    /// <code>
    /// decimal speed = 100m.ConvertKilometersPerHourToMilesPerHour();  // Returns ~62.14 mph
    /// </code>
    /// </example>
    public static decimal ConvertKilometersPerHourToMilesPerHour(this decimal kilometersPerHour)
    {
        return kilometersPerHour / KilometersPerMile;
    }

    /// <summary>
    /// Converts speed from miles per hour to kilometers per hour.
    /// </summary>
    /// <param name="milesPerHour">Speed in miles per hour.</param>
    /// <returns>Speed in kilometers per hour.</returns>
    /// <example>
    /// <code>
    /// decimal speed = 60m.ConvertMilesPerHourToKilometersPerHour();  // Returns ~96.54 km/h
    /// </code>
    /// </example>
    public static decimal ConvertMilesPerHourToKilometersPerHour(this decimal milesPerHour)
    {
        return milesPerHour * KilometersPerMile;
    }

    /// <summary>
    /// Converts speed from meters per second to miles per hour.
    /// </summary>
    /// <param name="metersPerSecond">Speed in meters per second.</param>
    /// <returns>Speed in miles per hour.</returns>
    /// <example>
    /// <code>
    /// decimal speed = 10m.ConvertMetersPerSecondToMilesPerHour();  // Returns ~22.37 mph
    /// </code>
    /// </example>
    public static decimal ConvertMetersPerSecondToMilesPerHour(this decimal metersPerSecond)
    {
        return metersPerSecond * MetersPerSecondToMilesPerHourFactor;
    }

    /// <summary>
    /// Converts speed from miles per hour to meters per second.
    /// </summary>
    /// <param name="milesPerHour">Speed in miles per hour.</param>
    /// <returns>Speed in meters per second.</returns>
    /// <example>
    /// <code>
    /// decimal speed = 60m.ConvertMilesPerHourToMetersPerSecond();  // Returns ~26.82 m/s
    /// </code>
    /// </example>
    public static decimal ConvertMilesPerHourToMetersPerSecond(this decimal milesPerHour)
    {
        return milesPerHour * MilesPerHourToMetersPerSecondFactor;
    }

    #endregion Public Methods
}