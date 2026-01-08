namespace Roadbed.Sdk.NationalWeatherService.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Roadbed.Sdk.NationalWeatherService.Dtos;

/// <summary>
/// Entity contract for the <see cref="NwsStation"/> CRUD operations.
/// </summary>
internal interface INwsOfficeRepository
{
    #region Public Methods

    /// <summary>
    /// Get Operation for the entity.
    /// </summary>
    /// <param name="id">ID of the entity.</param>
    /// <param name="cancellationToken">Token to notify when an operation should be canceled.</param>
    /// <returns>Data Transfer Object (DTO) object.</returns>
    Task<NwsOfficeResponse> ReadAsync(string id, CancellationToken cancellationToken);

    #endregion Public Methods
}