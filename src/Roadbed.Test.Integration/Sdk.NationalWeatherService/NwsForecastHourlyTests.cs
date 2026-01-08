namespace Roadbed.Test.Integration;

using Roadbed.Sdk.NationalWeatherService;
using Roadbed.Test.Integration.Sdk.NationalWeatherService;

/// <summary>
/// Contains unit tests for verifying the behavior of the NwsForecastHourlyTests class.
/// </summary>
[TestClass]
public class NwsForecastHourlyTests : BaseNwsTests
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NwsForecastRequestTests"/> class.
    /// </summary>
    public NwsForecastHourlyTests() : base()
    {
    }

    /// <summary>
    /// Unit test to verify that INwsGridCoordinateRepository retrieves data correctly.
    /// </summary>
    /// <returns>A unit of work representing when operation has been completed.</returns>
    [TestMethod]
    public async Task NwsForecastHourly_BusinessLogic_ValidOfficeRequest()
    {
        // Arrange (Given)
        NwsForecastRequest request = await NwsForecastRequest.FromLocation(
            35.676860,
            -105.946167,
            MessagingRequest,
            this.TestContext.CancellationToken);

        // Act (When)
        Assert.IsNotNull(
            request,
            "No data was returned when looking up the grid coordinates.");

        NwsForecastHourly forecast = await NwsForecastHourly.FromForecastRequest(
            request,
            MessagingRequest,
            this.TestContext.CancellationToken);

        // Assert (Then)
        Assert.IsNotNull(
            forecast,
            "No data was returned for the forecast.");
    }
}