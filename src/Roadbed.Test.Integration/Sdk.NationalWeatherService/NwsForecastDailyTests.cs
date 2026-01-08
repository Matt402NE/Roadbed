namespace Roadbed.Test.Integration;

using Roadbed.Sdk.NationalWeatherService;
using Roadbed.Test.Integration.Sdk.NationalWeatherService;

/// <summary>
/// Contains unit tests for verifying the behavior of the NwsForecastDailyTests class.
/// </summary>
[TestClass]
public class NwsForecastDailyTests : BaseNwsTests
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NwsForecastRequestTests"/> class.
    /// </summary>
    public NwsForecastDailyTests() : base()
    {
    }

    /// <summary>
    /// Unit test to verify that INwsGridCoordinateRepository retrieves data correctly.
    /// </summary>
    /// <returns>A unit of work representing when operation has been completed.</returns>
    [TestMethod]
    public async Task NwsForecastDaily_BusinessLogic_ValidOfficeRequest()
    {
        // Arrange (Given)
        NwsForecastRequest request = await NwsForecastRequest.FromLocation(
            36.340177,
            -92.377362,
            MessagingRequest,
            this.TestContext.CancellationToken);

        // Act (When)
        Assert.IsNotNull(
            request,
            "No data was returned when looking up the grid coordinates.");

        NwsForecastDaily forecast = await NwsForecastDaily.FromForecastRequest(
            request,
            MessagingRequest,
            this.TestContext.CancellationToken);

        // Assert (Then)
        Assert.IsNotNull(
            forecast,
            "No data was returned for the forecast.");
    }
}