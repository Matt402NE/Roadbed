namespace Roadbed.Sdk.NationalWeatherService.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Roadbed.Sdk.NationalWeatherService.Dtos;

/// <summary>
/// Repository contract for retrieving weather station information.
/// </summary>
internal interface INwsStationRepository
{
    #region Public Methods

    /// <summary>
    /// Gets detailed information about a National Weather Service observation station.
    /// </summary>
    /// <param name="id">Station identifier (e.g., "KLNK" for Lincoln, "KORD" for Chicago O'Hare).</param>
    /// <param name="cancellationToken">Token to notify when an operation should be canceled.</param>
    /// <returns>Station response containing coordinates, timezone, and associated forecast zones.</returns>
    Task<NwsStationResponse> ReadAsync(string id, CancellationToken cancellationToken);

    #endregion Public Methods
}