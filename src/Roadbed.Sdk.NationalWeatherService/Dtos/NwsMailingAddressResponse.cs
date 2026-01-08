namespace Roadbed.Sdk.NationalWeatherService.Dtos;

using Newtonsoft.Json;

/// <summary>
/// Postal Address from the National Weather Service.
/// </summary>
/// <remarks>
/// Represents a physical mailing address.
/// </remarks>
internal sealed record NwsMailingAddressResponse
{
    /// <summary>
    /// Gets or sets the address type (should be "PostalAddress").
    /// </summary>
    [JsonProperty("@type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the street address.
    /// </summary>
    [JsonProperty("streetAddress")]
    public string? StreetAddress { get; set; }

    /// <summary>
    /// Gets or sets the city or locality.
    /// </summary>
    [JsonProperty("addressLocality")]
    public string? AddressLocality { get; set; }

    /// <summary>
    /// Gets or sets the state or region (e.g., "CA").
    /// </summary>
    [JsonProperty("addressRegion")]
    public string? AddressRegion { get; set; }

    /// <summary>
    /// Gets or sets the postal code (ZIP code).
    /// </summary>
    [JsonProperty("postalCode")]
    public string? PostalCode { get; set; }
}