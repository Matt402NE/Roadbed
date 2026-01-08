namespace Roadbed.Sdk.NationalWeatherService.Repositories;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Repository contract for retrieving observation stations by administrative district.
/// </summary>
internal interface INwsAdminDistrictRepository
{
    #region Public Methods

    /// <summary>
    /// Gets observation stations for the specified administrative district.
    /// </summary>
    /// <param name="district">Administrative district to query.</param>
    /// <param name="cancellationToken">Token to notify when an operation should be canceled.</param>
    /// <returns>List of observation stations in the administrative district.</returns>
    Task<IList<NwsStation>> ListAsync(AdminDistrictTwoCharacterCode district, CancellationToken cancellationToken);

    #endregion Public Methods
}