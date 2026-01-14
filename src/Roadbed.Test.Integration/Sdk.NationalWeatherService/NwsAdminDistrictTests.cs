namespace Roadbed.Test.Integration;

using Roadbed.Sdk.NationalWeatherService;
using Roadbed.Test.Integration.Sdk.NationalWeatherService;

/// <summary>
/// Contains unit tests for verifying the behavior of the NwsAdminDistrict class.
/// </summary>
[TestClass]
public class NwsAdminDistrictTests : BaseNwsTests
{
    /// <summary>
    /// List of valid station IDs for testing.
    /// </summary>
    private static readonly AdminDistrictTwoCharacterCode[] DistrictCodes = new[]
    {
        AdminDistrictTwoCharacterCode.IA,
        AdminDistrictTwoCharacterCode.KS,
        AdminDistrictTwoCharacterCode.MO,
        AdminDistrictTwoCharacterCode.NE,
    };

    /// <summary>
    /// Random number generator for selecting test data.
    /// </summary>
    private static readonly Random Random = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="NwsAdminDistrictTests"/> class.
    /// </summary>
    public NwsAdminDistrictTests() : base()
    {
    }

    /* Disable.  API fails to respond half the time.
     * 
    /// <summary>
    /// Unit test to verify that IBaseForecastRepository retrieves data correctly.
    /// </summary>
    /// <returns>A unit of work representing when operation has been completed.</returns>
    [TestMethod]
    public async Task NwsAdminDistrict_BusinessLogic_ValidSerializationAndObjectCreation()
    {
        // Arrange (Given)
        AdminDistrictTwoCharacterCode randomDistrictCode = DistrictCodes[Random.Next(DistrictCodes.Length)];

        // Act (When)
        NwsAdminDistrict district = await NwsAdminDistrict.FromAdminDistrict(
            randomDistrictCode,
            MessagingRequest,
            this.TestContext.CancellationToken);

        // Assert (Then)
        Assert.IsNotNull(
            district,
            "No data was returned.");
        Assert.IsNotNull(
            district,
            "No data was returned.");
    }
    */
}