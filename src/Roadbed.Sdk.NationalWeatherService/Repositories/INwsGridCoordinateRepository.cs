namespace Roadbed.Sdk.NationalWeatherService.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Roadbed.Sdk.NationalWeatherService.Dtos;

/// <summary>
/// Repository contract for converting geographic coordinates to NWS grid coordinates.
/// </summary>
/// <remarks>
/// The National Weather Service uses a grid-based system. This repository converts
/// standard latitude/longitude coordinates into NWS grid coordinates (office, gridX, gridY).
/// </remarks>
internal interface INwsGridCoordinateRepository
{
    #region Public Methods

    /// <summary>
    /// Converts geographic coordinates to NWS grid coordinates.
    /// </summary>
    /// <param name="coordinates">Physical address containing latitude and longitude.</param>
    /// <param name="cancellationToken">Token to notify when an operation should be canceled.</param>
    /// <returns>Grid coordinate response containing NWS office and grid X/Y coordinates.</returns>
    Task<NwsGridCoordinateResponse> ReadAsync(NwsPhysicalAddress coordinates, CancellationToken cancellationToken);

    #endregion Public Methods
}