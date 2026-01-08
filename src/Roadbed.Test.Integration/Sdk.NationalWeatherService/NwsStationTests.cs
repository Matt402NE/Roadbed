namespace Roadbed.Test.Integration;

using Roadbed.Sdk.NationalWeatherService;
using Roadbed.Test.Integration.Sdk.NationalWeatherService;

/// <summary>
/// Contains unit tests for verifying the behavior of the NwsAdminDistrict class.
/// </summary>
[TestClass]
public class NwsStationTests : BaseNwsTests
{
    /// <summary>
    /// List of valid station IDs for testing.
    /// </summary>
    private static readonly string[] StationIds = new[]
    {
        "A3991",
        "A3993",
        "A4753",
    };

    /// <summary>
    /// Random number generator for selecting test data.
    /// </summary>
    private static readonly Random Random = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="NwsStationTests"/> class.
    /// </summary>
    public NwsStationTests() : base()
    {
    }

    /// <summary>
    /// Unit test to verify that IBaseForecastRepository retrieves data correctly.
    /// </summary>
    /// <returns>A unit of work representing when operation has been completed.</returns>
    [TestMethod]
    public async Task NwsStation_BusinessLogic_ValidSerializationAndObjectCreation()
    {
        // Arrange (Given)
        string randomStationId = StationIds[Random.Next(StationIds.Length)];

        // Act (When)
        NwsStation station = await NwsStation.FromId(
            randomStationId,
            MessagingRequest,
            this.TestContext.CancellationToken);

        // Assert (Then)
        Assert.IsNotNull(
            station,
            "No data was returned.");
        Assert.IsNotNull(
            station,
            "No data was returned.");
    }
}