namespace Roadbed.Test.Integration;

using Roadbed.Sdk.NationalWeatherService;
using Roadbed.Test.Integration.Sdk.NationalWeatherService;

/// <summary>
/// Contains unit tests for verifying the behavior of the NwsOffice class.
/// </summary>
[TestClass]
public class NwsOfficeTests : BaseNwsTests
{
    /// <summary>
    /// List of valid office IDs for testing.
    /// </summary>
    private static readonly string[] OfficeIds = new[]
    {
        "BGM",
        "HNX",
        "HUN",
    };

    /// <summary>
    /// Random number generator for selecting test data.
    /// </summary>
    private static readonly Random Random = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="NwsOfficeTests"/> class.
    /// </summary>
    public NwsOfficeTests() : base()
    {
    }

    /// <summary>
    /// Unit test to verify that IBaseForecastRepository retrieves data correctly.
    /// </summary>
    /// <returns>A unit of work representing when operation has been completed.</returns>
    [TestMethod]
    public async Task NwsOffice_BusinessLogic_ValidOfficeRequest()
    {
        // Arrange (Given)
        string randomOfficeId = OfficeIds[Random.Next(OfficeIds.Length)];

        // Act (When)
        NwsOffice office = await NwsOffice.FromId(
            randomOfficeId,
            MessagingRequest,
            this.TestContext.CancellationToken);

        // Assert (Then)
        Assert.IsNotNull(
            office,
            "No data was returned.");
        Assert.IsNotNull(
            office,
            "No data was returned.");
    }
}