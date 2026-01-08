namespace Roadbed.Test.Unit.NationalWeatherService;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadbed.Sdk.NationalWeatherService;
using System;

/// <summary>
/// Unit tests for the NwsDecimalExtensions class.
/// </summary>
[TestClass]
public class NwsDecimalExtensionsTests
{
    #region Public Methods

    /// <summary>
    /// Verifies that ConvertCelsiusToFahrenheit returns -459.67 when provided with -273.15 degrees Celsius (absolute zero).
    /// </summary>
    [TestMethod]
    public void ConvertCelsiusToFahrenheit_AbsoluteZero_ReturnsNegative459Point67()
    {
        // Arrange (Given)
        decimal celsius = -273.15m;

        // Act (When)
        decimal result = celsius.ConvertCelsiusToFahrenheit();

        // Assert (Then)
        Assert.AreEqual(
            -459.67m,
            result,
            "Absolute zero (-273.15°C) should equal -459.67°F.");
    }

    /// <summary>
    /// Verifies that ConvertCelsiusToFahrenheit returns 98.6 when provided with 37 degrees Celsius (body temperature).
    /// </summary>
    [TestMethod]
    public void ConvertCelsiusToFahrenheit_BodyTemperature_Returns98Point6()
    {
        // Arrange (Given)
        decimal celsius = 37m;

        // Act (When)
        decimal result = celsius.ConvertCelsiusToFahrenheit();

        // Assert (Then)
        Assert.AreEqual(
            98.6m,
            result,
            "Body temperature (37°C) should equal 98.6°F.");
    }

    /// <summary>
    /// Verifies that ConvertCelsiusToFahrenheit returns 212 when provided with 100 degrees Celsius (boiling point).
    /// </summary>
    [TestMethod]
    public void ConvertCelsiusToFahrenheit_BoilingPoint_Returns212()
    {
        // Arrange (Given)
        decimal celsius = 100m;

        // Act (When)
        decimal result = celsius.ConvertCelsiusToFahrenheit();

        // Assert (Then)
        Assert.AreEqual(
            212m,
            result,
            "Boiling point (100°C) should equal 212°F.");
    }

    /// <summary>
    /// Verifies that ConvertCelsiusToFahrenheit correctly handles decimal precision with fractional values.
    /// </summary>
    [TestMethod]
    public void ConvertCelsiusToFahrenheit_DecimalValue_ReturnsAccurateResult()
    {
        // Arrange (Given)
        decimal celsius = 23.5m;

        // Act (When)
        decimal result = celsius.ConvertCelsiusToFahrenheit();

        // Assert (Then)
        Assert.AreEqual(
            74.3m,
            result,
            "23.5°C should equal 74.3°F.");
    }

    /// <summary>
    /// Verifies that ConvertCelsiusToFahrenheit returns 32 when provided with 0 degrees Celsius (freezing point).
    /// </summary>
    [TestMethod]
    public void ConvertCelsiusToFahrenheit_FreezingPoint_Returns32()
    {
        // Arrange (Given)
        decimal celsius = 0m;

        // Act (When)
        decimal result = celsius.ConvertCelsiusToFahrenheit();

        // Assert (Then)
        Assert.AreEqual(
            32m,
            result,
            "Freezing point (0°C) should equal 32°F.");
    }

    /// <summary>
    /// Verifies that ConvertCelsiusToFahrenheit returns -40 when provided with -40 degrees Celsius (equal point).
    /// </summary>
    [TestMethod]
    public void ConvertCelsiusToFahrenheit_NegativeForty_ReturnsNegativeForty()
    {
        // Arrange (Given)
        decimal celsius = -40m;

        // Act (When)
        decimal result = celsius.ConvertCelsiusToFahrenheit();

        // Assert (Then)
        Assert.AreEqual(
            -40m,
            result,
            "-40°C should equal -40°F (the point where both scales meet).");
    }

    /// <summary>
    /// Verifies that ConvertCelsiusToFahrenheit returns a negative value when provided with a negative Celsius value below -40.
    /// </summary>
    [TestMethod]
    public void ConvertCelsiusToFahrenheit_NegativeValue_ReturnsNegativeValue()
    {
        // Arrange (Given)
        decimal celsius = -50m;

        // Act (When)
        decimal result = celsius.ConvertCelsiusToFahrenheit();

        // Assert (Then)
        Assert.AreEqual(
            -58m,
            result,
            "-50°C should equal -58°F.");
    }

    /// <summary>
    /// Verifies that ConvertCelsiusToFahrenheit returns a positive value when provided with a positive Celsius value.
    /// </summary>
    [TestMethod]
    public void ConvertCelsiusToFahrenheit_PositiveValue_ReturnsPositiveValue()
    {
        // Arrange (Given)
        decimal celsius = 25m;

        // Act (When)
        decimal result = celsius.ConvertCelsiusToFahrenheit();

        // Assert (Then)
        Assert.AreEqual(
            77m,
            result,
            "25°C should equal 77°F.");
    }

    /// <summary>
    /// Verifies that ConvertCelsiusToFahrenheit returns 68 when provided with 20 degrees Celsius (room temperature).
    /// </summary>
    [TestMethod]
    public void ConvertCelsiusToFahrenheit_RoomTemperature_Returns68()
    {
        // Arrange (Given)
        decimal celsius = 20m;

        // Act (When)
        decimal result = celsius.ConvertCelsiusToFahrenheit();

        // Assert (Then)
        Assert.AreEqual(
            68m,
            result,
            "Room temperature (20°C) should equal 68°F.");
    }

    /// <summary>
    /// Verifies that ConvertFahrenheitToCelsius returns -273.15 when provided with -459.67 degrees Fahrenheit (absolute zero).
    /// </summary>
    [TestMethod]
    public void ConvertFahrenheitToCelsius_AbsoluteZero_ReturnsNegative273Point15()
    {
        // Arrange (Given)
        decimal fahrenheit = -459.67m;

        // Act (When)
        decimal result = fahrenheit.ConvertFahrenheitToCelsius();

        // Assert (Then)
        Assert.AreEqual(
            -273.15m,
            Math.Round(result, 2),
            "Absolute zero (-459.67°F) should equal -273.15°C.");
    }

    /// <summary>
    /// Verifies that ConvertFahrenheitToCelsius returns 37 when provided with 98.6 degrees Fahrenheit (body temperature).
    /// </summary>
    [TestMethod]
    public void ConvertFahrenheitToCelsius_BodyTemperature_Returns37()
    {
        // Arrange (Given)
        decimal fahrenheit = 98.6m;

        // Act (When)
        decimal result = fahrenheit.ConvertFahrenheitToCelsius();

        // Assert (Then)
        Assert.AreEqual(
            37m,
            Math.Round(result, 0),
            "Body temperature (98.6°F) should equal 37°C.");
    }

    /// <summary>
    /// Verifies that ConvertFahrenheitToCelsius returns 100 when provided with 212 degrees Fahrenheit (boiling point).
    /// </summary>
    [TestMethod]
    public void ConvertFahrenheitToCelsius_BoilingPoint_Returns100()
    {
        // Arrange (Given)
        decimal fahrenheit = 212m;

        // Act (When)
        decimal result = fahrenheit.ConvertFahrenheitToCelsius();

        // Assert (Then)
        Assert.AreEqual(
            100m,
            Math.Round(result, 0),
            "Boiling point (212°F) should equal 100°C.");
    }

    /// <summary>
    /// Verifies that ConvertFahrenheitToCelsius returns 0 when provided with 32 degrees Fahrenheit (freezing point).
    /// </summary>
    [TestMethod]
    public void ConvertFahrenheitToCelsius_FreezingPoint_ReturnsZero()
    {
        // Arrange (Given)
        decimal fahrenheit = 32m;

        // Act (When)
        decimal result = fahrenheit.ConvertFahrenheitToCelsius();

        // Assert (Then)
        Assert.AreEqual(
            0m,
            Math.Round(result, 0),
            "Freezing point (32°F) should equal 0°C.");
    }

    /// <summary>
    /// Verifies that ConvertFahrenheitToCelsius returns -40 when provided with -40 degrees Fahrenheit (equal point).
    /// </summary>
    [TestMethod]
    public void ConvertFahrenheitToCelsius_NegativeForty_ReturnsNegativeForty()
    {
        // Arrange (Given)
        decimal fahrenheit = -40m;

        // Act (When)
        decimal result = fahrenheit.ConvertFahrenheitToCelsius();

        // Assert (Then)
        Assert.AreEqual(
            -40m,
            Math.Round(result, 0),
            "-40°F should equal -40°C (the point where both scales meet).");
    }

    /// <summary>
    /// Verifies that ConvertFahrenheitToCelsius returns 20 when provided with 68 degrees Fahrenheit (room temperature).
    /// </summary>
    [TestMethod]
    public void ConvertFahrenheitToCelsius_RoomTemperature_Returns20()
    {
        // Arrange (Given)
        decimal fahrenheit = 68m;

        // Act (When)
        decimal result = fahrenheit.ConvertFahrenheitToCelsius();

        // Assert (Then)
        Assert.AreEqual(
            20m,
            Math.Round(result, 0),
            "Room temperature (68°F) should equal 20°C.");
    }

    /// <summary>
    /// Verifies that ConvertKilometersPerHourToMilesPerHour returns approximately 1 when provided with 1.609 kilometers per hour.
    /// </summary>
    [TestMethod]
    public void ConvertKilometersPerHourToMilesPerHour_OnePointSixZeroNine_ReturnsOne()
    {
        // Arrange (Given)
        decimal kilometers = 1.609m;

        // Act (When)
        decimal result = kilometers.ConvertKilometersPerHourToMilesPerHour();

        // Assert (Then)
        Assert.AreEqual(
            1m,
            Math.Round(result, 0),
            "1.609 km/h should equal approximately 1 mph.");
    }

    /// <summary>
    /// Verifies that ConvertKilometersPerHourToMilesPerHour returns 0 when provided with 0 kilometers per hour.
    /// </summary>
    [TestMethod]
    public void ConvertKilometersPerHourToMilesPerHour_Zero_ReturnsZero()
    {
        // Arrange (Given)
        decimal kilometers = 0m;

        // Act (When)
        decimal result = kilometers.ConvertKilometersPerHourToMilesPerHour();

        // Assert (Then)
        Assert.AreEqual(
            0m,
            result,
            "0 km/h should equal 0 mph.");
    }

    /// <summary>
    /// Verifies that ConvertMetersPerSecondToMilesPerHour correctly handles decimal precision with fractional values.
    /// </summary>
    [TestMethod]
    public void ConvertMetersPerSecondToMilesPerHour_DecimalValue_ReturnsAccurateResult()
    {
        // Arrange (Given)
        decimal meters = 5.5m;

        // Act (When)
        decimal result = meters.ConvertMetersPerSecondToMilesPerHour();

        // Assert (Then)
        Assert.AreEqual(
            12.30317m,
            result,
            "5.5 m/s should equal 12.30317 mph.");
    }

    /// <summary>
    /// Verifies that ConvertMetersPerSecondToMilesPerHour correctly handles large values representing hurricane-force winds.
    /// </summary>
    [TestMethod]
    public void ConvertMetersPerSecondToMilesPerHour_HurricaneForceWinds_ReturnsAccurateResult()
    {
        // Arrange (Given)
        decimal meters = 50m;

        // Act (When)
        decimal result = meters.ConvertMetersPerSecondToMilesPerHour();

        // Assert (Then)
        Assert.AreEqual(
            111.847m,
            result,
            "50 m/s should equal 111.847 mph (hurricane-force winds).");
    }

    /// <summary>
    /// Verifies that ConvertMetersPerSecondToMilesPerHour returns approximately 2.237 when provided with 1 meter per second.
    /// </summary>
    [TestMethod]
    public void ConvertMetersPerSecondToMilesPerHour_One_ReturnsApproximately2Point24()
    {
        // Arrange (Given)
        decimal meters = 1m;

        // Act (When)
        decimal result = meters.ConvertMetersPerSecondToMilesPerHour();

        // Assert (Then)
        Assert.AreEqual(
            2.23694m,
            result,
            "1 m/s should equal 2.23694 mph.");
    }

    /// <summary>
    /// Verifies that ConvertMetersPerSecondToMilesPerHour returns approximately 223.694 when provided with 100 meters per second.
    /// </summary>
    [TestMethod]
    public void ConvertMetersPerSecondToMilesPerHour_OneHundred_ReturnsApproximately224()
    {
        // Arrange (Given)
        decimal meters = 100m;

        // Act (When)
        decimal result = meters.ConvertMetersPerSecondToMilesPerHour();

        // Assert (Then)
        Assert.AreEqual(
            223.694m,
            result,
            "100 m/s should equal 223.694 mph.");
    }

    /// <summary>
    /// Verifies that ConvertMetersPerSecondToMilesPerHour correctly handles small decimal values.
    /// </summary>
    [TestMethod]
    public void ConvertMetersPerSecondToMilesPerHour_SmallDecimal_ReturnsAccurateResult()
    {
        // Arrange (Given)
        decimal meters = 0.5m;

        // Act (When)
        decimal result = meters.ConvertMetersPerSecondToMilesPerHour();

        // Assert (Then)
        Assert.AreEqual(
            1.11847m,
            result,
            "0.5 m/s should equal 1.11847 mph.");
    }

    /// <summary>
    /// Verifies that ConvertMetersPerSecondToMilesPerHour returns approximately 22.369 when provided with 10 meters per second.
    /// </summary>
    [TestMethod]
    public void ConvertMetersPerSecondToMilesPerHour_Ten_ReturnsApproximately22Point37()
    {
        // Arrange (Given)
        decimal meters = 10m;

        // Act (When)
        decimal result = meters.ConvertMetersPerSecondToMilesPerHour();

        // Assert (Then)
        Assert.AreEqual(
            22.3694m,
            result,
            "10 m/s should equal 22.3694 mph.");
    }

    /// <summary>
    /// Verifies that ConvertMetersPerSecondToMilesPerHour returns 0 when provided with 0 meters per second.
    /// </summary>
    [TestMethod]
    public void ConvertMetersPerSecondToMilesPerHour_Zero_ReturnsZero()
    {
        // Arrange (Given)
        decimal meters = 0m;

        // Act (When)
        decimal result = meters.ConvertMetersPerSecondToMilesPerHour();

        // Assert (Then)
        Assert.AreEqual(
            0m,
            result,
            "0 m/s should equal 0 mph.");
    }

    /// <summary>
    /// Verifies that ConvertMilesPerHourToKilometersPerHour returns approximately 100 when provided with 62.14 miles per hour.
    /// </summary>
    [TestMethod]
    public void ConvertMilesPerHourToKilometersPerHour_SixtyTwoPoint14_ReturnsApproximately100()
    {
        // Arrange (Given)
        decimal milesPerHour = 62.14m;

        // Act (When)
        decimal result = milesPerHour.ConvertMilesPerHourToKilometersPerHour();

        // Assert (Then)
        Assert.AreEqual(
            100m,
            Math.Round(result, 0),
            "62.14 mph should equal approximately 100 km/h.");
    }

    /// <summary>
    /// Verifies that ConvertMilesPerHourToKilometersPerHour returns 0 when provided with 0 miles per hour.
    /// </summary>
    [TestMethod]
    public void ConvertMilesPerHourToKilometersPerHour_Zero_ReturnsZero()
    {
        // Arrange (Given)
        decimal milesPerHour = 0m;

        // Act (When)
        decimal result = milesPerHour.ConvertMilesPerHourToKilometersPerHour();

        // Assert (Then)
        Assert.AreEqual(
            0m,
            result,
            "0 mph should equal 0 km/h.");
    }

    /// <summary>
    /// Verifies that ConvertMilesPerHourToMetersPerSecond returns approximately 26.82 when provided with 60 miles per hour.
    /// </summary>
    [TestMethod]
    public void ConvertMilesPerHourToMetersPerSecond_Sixty_ReturnsApproximately26Point82()
    {
        // Arrange (Given)
        decimal milesPerHour = 60m;

        // Act (When)
        decimal result = milesPerHour.ConvertMilesPerHourToMetersPerSecond();

        // Assert (Then)
        Assert.AreEqual(
            26.8224m,
            result,
            "60 mph should equal 26.8224 m/s.");
    }

    /// <summary>
    /// Verifies that ConvertMilesPerHourToMetersPerSecond returns 0 when provided with 0 miles per hour.
    /// </summary>
    [TestMethod]
    public void ConvertMilesPerHourToMetersPerSecond_Zero_ReturnsZero()
    {
        // Arrange (Given)
        decimal milesPerHour = 0m;

        // Act (When)
        decimal result = milesPerHour.ConvertMilesPerHourToMetersPerSecond();

        // Assert (Then)
        Assert.AreEqual(
            0m,
            result,
            "0 mph should equal 0 m/s.");
    }

    #endregion Public Methods
}