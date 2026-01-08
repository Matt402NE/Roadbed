namespace Roadbed.Sdk.NationalWeatherService.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Roadbed.Sdk.NationalWeatherService.Dtos;

/// <summary>
/// Repository contract for retrieving daily forecasts from the National Weather Service.
/// </summary>
internal interface INwsForecastDailyRepository
{
    #region Public Methods

    /// <summary>
    /// Gets the daily forecast for the specified location.
    /// </summary>
    /// <param name="request">Request containing location information for the forecast.</param>
    /// <param name="cancellationToken">Token to notify when an operation should be canceled.</param>
    /// <returns>Daily forecast response containing multiple forecast periods.</returns>
    Task<NwsForecastResponse> ReadAsync(NwsForecastRequest request, CancellationToken cancellationToken);

    #endregion Public Methods
}