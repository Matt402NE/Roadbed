namespace Roadbed.Test.Unit;

/// <summary>
/// Contains unit tests for verifying the behavior of the CommonStringExtensions class.
/// </summary>
[TestClass]
public class CommonStringExtensionTests
{
    #region Public Methods

    /// <summary>
    /// Unit test to verify that the CommonEnvironment can be determined by "LOCAL".
    /// </summary>
    [TestMethod]
    public void CommonStringExtension_CommonEnvironment_VerifyLocalResult()
    {
        // Arrange (Given)
        CommonEnvironment expectedEnum = CommonEnvironment.Local;
        string actualString = "LOCAL";

        // Act (When)
        CommonEnvironment actualEnum = actualString.GetCommonEnvironment();

        // Assert (Then)
        Assert.AreEqual(
            expectedEnum,
            actualEnum,
            "CommonEnvironment could be determined by \"LOCAL\".");
    }

    #endregion Public Methods
}