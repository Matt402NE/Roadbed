namespace Roadbed.Test.Integration;

using Roadbed.Sdk.NationalWeatherService;
using Roadbed.Test.Integration.Sdk.NationalWeatherService;

/// <summary>
/// Contains unit tests for verifying the behavior of the NwsForecastRequest class.
/// </summary>
[TestClass]
public class NwsForecastRequestTests : BaseNwsTests
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NwsForecastRequestTests"/> class.
    /// </summary>
    public NwsForecastRequestTests() : base()
    {
    }

    /// <summary>
    /// Unit test to verify that INwsGridCoordinateRepository retrieves data correctly.
    /// </summary>
    /// <returns>A unit of work representing when operation has been completed.</returns>
    [TestMethod]
    public async Task ForecastRequest_BusinessLogic_ValidOfficeRequest()
    {
        // Arrange (Given)

        // Act (When)
        NwsForecastRequest request = await NwsForecastRequest.FromLocation(
            41.265630,
            -95.922312,
            MessagingRequest,
            this.TestContext.CancellationToken);

        // Assert (Then)
        Assert.IsNotNull(
            request,
            "No data was returned.");
        Assert.IsNotNull(
            request,
            "No data was returned.");
    }
}