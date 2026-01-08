/*
 * The namespace Roadbed.Sdk.NationalWeatherService.Dtos was removed on purpose and replaced with Roadbed.Sdk.NationalWeatherService so that no additional using statements are required.
 */

namespace Roadbed.Sdk.NationalWeatherService;

using System;

/// <summary>
/// Physical address with geographic coordinates.
/// </summary>
public sealed record NwsPhysicalAddress
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="NwsPhysicalAddress"/> class.
    /// </summary>
    /// <param name="latitude">Latitude of the coordinate (range: -90 to 90).</param>
    /// <param name="longitude">Longitude of the coordinate (range: -180 to 180).</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when latitude or longitude is outside valid range.</exception>
    public NwsPhysicalAddress(double latitude, double longitude)
    {
        if (latitude < -90.0 || latitude > 90.0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(latitude),
                latitude,
                "Latitude must be between -90 and 90 degrees.");
        }

        if (longitude < -180.0 || longitude > 180.0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(longitude),
                longitude,
                "Longitude must be between -180 and 180 degrees.");
        }

        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets the latitude of the coordinate.
    /// </summary>
    /// <remarks>
    /// Valid range: -90 (South Pole) to 90 (North Pole).
    /// </remarks>
    public double Latitude { get; init; }

    /// <summary>
    /// Gets the longitude of the coordinate.
    /// </summary>
    /// <remarks>
    /// Valid range: -180 (antimeridian west) to 180 (antimeridian east).
    /// </remarks>
    public double Longitude { get; init; }

    #endregion Public Properties
}