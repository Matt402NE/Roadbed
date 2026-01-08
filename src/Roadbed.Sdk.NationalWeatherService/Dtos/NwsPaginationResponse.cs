namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using Newtonsoft.Json;

/// <summary>
/// Pagination from the National Weather Service.
/// </summary>
/// <remarks>
/// Contains pagination information for paginated API responses.
/// </remarks>
internal sealed record NwsPaginationResponse
{
    /// <summary>
    /// Gets or sets the URL for the next page of results.
    /// </summary>
    [JsonProperty("next")]
    public string? Next { get; set; }
}