namespace Roadbed.Test.Unit.Common;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadbed.Common;
using System;

/// <summary>
/// Contains unit tests for verifying the behavior of the CommonBusinessKey class.
/// </summary>
[TestClass]
public class CommonBusinessKeyTests
{
    #region Public Methods

    #region Property Tests

    /// <summary>
    /// Unit test to verify that Key property can be set with valid uppercase value.
    /// </summary>
    [TestMethod]
    public void Key_ValidUppercaseValue_SetsSuccessfully()
    {
        // Arrange (Given)
        string expectedKey = "VALIDCODE123";

        // Act (When)
        var result = new CommonBusinessKey { Key = expectedKey };

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should be set to the valid uppercase value.");
    }

    /// <summary>
    /// Unit test to verify that Key property accepts digits.
    /// </summary>
    [TestMethod]
    public void Key_WithDigits_SetsSuccessfully()
    {
        // Arrange (Given)
        string expectedKey = "CODE123456";

        // Act (When)
        var result = new CommonBusinessKey { Key = expectedKey };

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should accept digits 0-9.");
    }

    /// <summary>
    /// Unit test to verify that Key property accepts period character.
    /// </summary>
    [TestMethod]
    public void Key_WithPeriod_SetsSuccessfully()
    {
        // Arrange (Given)
        string expectedKey = "CODE.NAME";

        // Act (When)
        var result = new CommonBusinessKey { Key = expectedKey };

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should accept period character.");
    }

    /// <summary>
    /// Unit test to verify that Key property accepts forward slash character.
    /// </summary>
    [TestMethod]
    public void Key_WithForwardSlash_SetsSuccessfully()
    {
        // Arrange (Given)
        string expectedKey = "CODE/NAME";

        // Act (When)
        var result = new CommonBusinessKey { Key = expectedKey };

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should accept forward slash character.");
    }

    /// <summary>
    /// Unit test to verify that Key property accepts underscore character.
    /// </summary>
    [TestMethod]
    public void Key_WithUnderscore_SetsSuccessfully()
    {
        // Arrange (Given)
        string expectedKey = "CODE_NAME";

        // Act (When)
        var result = new CommonBusinessKey { Key = expectedKey };

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should accept underscore character.");
    }

    /// <summary>
    /// Unit test to verify that Key property accepts hyphen character.
    /// </summary>
    [TestMethod]
    public void Key_WithHyphen_SetsSuccessfully()
    {
        // Arrange (Given)
        string expectedKey = "CODE-NAME";

        // Act (When)
        var result = new CommonBusinessKey { Key = expectedKey };

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should accept hyphen character.");
    }

    /// <summary>
    /// Unit test to verify that Key property accepts combination of valid characters.
    /// </summary>
    [TestMethod]
    public void Key_WithAllValidCharacters_SetsSuccessfully()
    {
        // Arrange (Given)
        string expectedKey = "ABC123./_-XYZ";

        // Act (When)
        var result = new CommonBusinessKey { Key = expectedKey };

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should accept combination of all valid characters.");
    }

    #endregion Property Tests

    #region Null/Empty Tests

    /// <summary>
    /// Unit test to verify that Key property throws exception when set to null.
    /// </summary>
    [TestMethod]
    public void Key_NullValue_ThrowsArgumentException()
    {
        // Arrange (Given)
        string? nullKey = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = nullKey! };
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Key should throw ArgumentException when value is null.");
    }

    /// <summary>
    /// Unit test to verify that Key property throws exception when set to empty string.
    /// </summary>
    [TestMethod]
    public void Key_EmptyString_ThrowsArgumentException()
    {
        // Arrange (Given)
        string emptyKey = string.Empty;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = emptyKey };
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Key should throw ArgumentException when value is empty string.");
    }

    /// <summary>
    /// Unit test to verify that Key property throws exception when set to whitespace.
    /// </summary>
    [TestMethod]
    public void Key_WhitespaceString_ThrowsArgumentException()
    {
        // Arrange (Given)
        string whitespaceKey = "   ";
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = whitespaceKey };
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Key should throw ArgumentException when value is whitespace.");
    }

    #endregion Null/Empty Tests

    #region Case Sensitivity Tests

    /// <summary>
    /// Unit test to verify that Key property throws specific exception for lowercase characters.
    /// </summary>
    [TestMethod]
    public void Key_LowercaseValue_ThrowsArgumentExceptionWithUppercaseMessage()
    {
        // Arrange (Given)
        string lowercaseKey = "lowercase";
        ArgumentException? caughtException = null;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = lowercaseKey };
        }
        catch (ArgumentException ex)
        {
            caughtException = ex;
        }

        // Assert (Then)
        Assert.IsNotNull(
            caughtException,
            "Key should throw ArgumentException for lowercase value.");
        Assert.Contains(
            "uppercase",
            caughtException.Message,
            "Exception message should mention uppercase requirement.");
    }

    /// <summary>
    /// Unit test to verify that Key property throws specific exception for mixed case characters.
    /// </summary>
    [TestMethod]
    public void Key_MixedCaseValue_ThrowsArgumentExceptionWithUppercaseMessage()
    {
        // Arrange (Given)
        string mixedCaseKey = "MixedCase";
        ArgumentException? caughtException = null;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = mixedCaseKey };
        }
        catch (ArgumentException ex)
        {
            caughtException = ex;
        }

        // Assert (Then)
        Assert.IsNotNull(
            caughtException,
            "Key should throw ArgumentException for mixed case value.");
        Assert.Contains(
            "uppercase",
            caughtException.Message,
            "Exception message should mention uppercase requirement.");
    }

    #endregion Case Sensitivity Tests

    #region Invalid Character Tests

    /// <summary>
    /// Unit test to verify that Key property throws exception for space character.
    /// </summary>
    [TestMethod]
    public void Key_WithSpace_ThrowsArgumentException()
    {
        // Arrange (Given)
        string keyWithSpace = "CODE NAME";
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = keyWithSpace };
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Key should throw ArgumentException when value contains space.");
    }

    /// <summary>
    /// Unit test to verify that Key property throws exception for special characters.
    /// </summary>
    [TestMethod]
    public void Key_WithSpecialCharacters_ThrowsArgumentException()
    {
        // Arrange (Given)
        string keyWithSpecialChars = "CODE@NAME";
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = keyWithSpecialChars };
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Key should throw ArgumentException when value contains invalid special characters.");
    }

    /// <summary>
    /// Unit test to verify that Key property throws exception for ampersand character.
    /// </summary>
    [TestMethod]
    public void Key_WithAmpersand_ThrowsArgumentException()
    {
        // Arrange (Given)
        string keyWithAmpersand = "CODE&NAME";
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = keyWithAmpersand };
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Key should throw ArgumentException when value contains ampersand.");
    }

    /// <summary>
    /// Unit test to verify that Key property throws exception for asterisk character.
    /// </summary>
    [TestMethod]
    public void Key_WithAsterisk_ThrowsArgumentException()
    {
        // Arrange (Given)
        string keyWithAsterisk = "CODE*NAME";
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = keyWithAsterisk };
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Key should throw ArgumentException when value contains asterisk.");
    }

    /// <summary>
    /// Unit test to verify that Key property throws exception for parentheses.
    /// </summary>
    [TestMethod]
    public void Key_WithParentheses_ThrowsArgumentException()
    {
        // Arrange (Given)
        string keyWithParentheses = "CODE(NAME)";
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = new CommonBusinessKey { Key = keyWithParentheses };
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Key should throw ArgumentException when value contains parentheses.");
    }

    #endregion Invalid Character Tests

    #region Edge Case Tests

    /// <summary>
    /// Unit test to verify that Key property accepts single character.
    /// </summary>
    [TestMethod]
    public void Key_SingleCharacter_SetsSuccessfully()
    {
        // Arrange (Given)
        string singleCharKey = "A";

        // Act (When)
        var result = new CommonBusinessKey { Key = singleCharKey };

        // Assert (Then)
        Assert.AreEqual(
            singleCharKey,
            result.Key,
            "Key should accept single valid character.");
    }

    /// <summary>
    /// Unit test to verify that Key property accepts single digit.
    /// </summary>
    [TestMethod]
    public void Key_SingleDigit_SetsSuccessfully()
    {
        // Arrange (Given)
        string singleDigitKey = "5";

        // Act (When)
        var result = new CommonBusinessKey { Key = singleDigitKey };

        // Assert (Then)
        Assert.AreEqual(
            singleDigitKey,
            result.Key,
            "Key should accept single digit.");
    }

    /// <summary>
    /// Unit test to verify that Key property accepts very long valid value.
    /// </summary>
    [TestMethod]
    public void Key_VeryLongValue_SetsSuccessfully()
    {
        // Arrange (Given)
        string longKey = new string('A', 1000);

        // Act (When)
        var result = new CommonBusinessKey { Key = longKey };

        // Assert (Then)
        Assert.AreEqual(
            longKey,
            result.Key,
            "Key should accept very long valid value.");
    }

    #endregion Edge Case Tests

    #region Property Setter Tests

    /// <summary>
    /// Unit test to verify that Key property can be changed after initialization.
    /// </summary>
    [TestMethod]
    public void Key_ChangedAfterInitialization_UpdatesSuccessfully()
    {
        // Arrange (Given)
        var businessKey = new CommonBusinessKey { Key = "ORIGINAL" };
        string newKey = "UPDATED";

        // Act (When)
        businessKey.Key = newKey;

        // Assert (Then)
        Assert.AreEqual(
            newKey,
            businessKey.Key,
            "Key should be updated to new valid value.");
    }

    /// <summary>
    /// Unit test to verify that Key property throws exception when changed to invalid value.
    /// </summary>
    [TestMethod]
    public void Key_ChangedToInvalidValue_ThrowsArgumentException()
    {
        // Arrange (Given)
        var businessKey = new CommonBusinessKey { Key = "ORIGINAL" };
        string invalidKey = "invalid";
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            businessKey.Key = invalidKey;
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Key should throw ArgumentException when changed to invalid value.");
        Assert.AreEqual(
            "ORIGINAL",
            businessKey.Key,
            "Key should retain original value after failed update.");
    }

    #endregion Property Setter Tests

    #region Regex Pattern Tests

    /// <summary>
    /// Unit test to verify that RegularExpressionPattern constant is accessible.
    /// </summary>
    [TestMethod]
    public void RegularExpressionPattern_Constant_IsAccessible()
    {
        // Arrange (Given)
        string expectedPattern = @"^[A-Z0-9./_-]+$";

        // Act (When)
        string actualPattern = CommonBusinessKey.RegularExpressionPattern;

        // Assert (Then)
        Assert.AreEqual(
            expectedPattern,
            actualPattern,
            "RegularExpressionPattern constant should match expected pattern.");
    }

    #endregion Regex Pattern Tests

    #region FromString Tests

    /// <summary>
    /// Unit test to verify that FromString creates instance with valid Business Key.
    /// </summary>
    [TestMethod]
    public void FromString_ValidKey_CreatesInstance()
    {
        // Arrange (Given)
        string validKey = "VALIDCODE123";

        // Act (When)
        var result = CommonBusinessKey.FromString(validKey);

        // Assert (Then)
        Assert.IsNotNull(
            result,
            "FromString should create an instance.");
        Assert.AreEqual(
            validKey,
            result.Key,
            "Key should match the provided value.");
    }

    /// <summary>
    /// Unit test to verify that FromString throws exception for null value.
    /// </summary>
    [TestMethod]
    public void FromString_NullValue_ThrowsArgumentException()
    {
        // Arrange (Given)
        string? nullKey = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = CommonBusinessKey.FromString(nullKey!);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString should throw ArgumentException when value is null.");
    }

    /// <summary>
    /// Unit test to verify that FromString throws exception for empty string.
    /// </summary>
    [TestMethod]
    public void FromString_EmptyString_ThrowsArgumentException()
    {
        // Arrange (Given)
        string emptyKey = string.Empty;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = CommonBusinessKey.FromString(emptyKey);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString should throw ArgumentException when value is empty string.");
    }

    /// <summary>
    /// Unit test to verify that FromString throws exception for invalid characters.
    /// </summary>
    [TestMethod]
    public void FromString_InvalidCharacters_ThrowsArgumentException()
    {
        // Arrange (Given)
        string invalidKey = "CODE@NAME";
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = CommonBusinessKey.FromString(invalidKey);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString should throw ArgumentException for invalid characters.");
    }

    /// <summary>
    /// Unit test to verify that FromString throws exception for lowercase value.
    /// </summary>
    [TestMethod]
    public void FromString_LowercaseValue_ThrowsArgumentExceptionWithUppercaseMessage()
    {
        // Arrange (Given)
        string lowercaseKey = "lowercase";
        ArgumentException? caughtException = null;

        // Act (When)
        try
        {
            var result = CommonBusinessKey.FromString(lowercaseKey);
        }
        catch (ArgumentException ex)
        {
            caughtException = ex;
        }

        // Assert (Then)
        Assert.IsNotNull(
            caughtException,
            "FromString should throw ArgumentException for lowercase value.");
        Assert.Contains(
            "uppercase",
            caughtException.Message,
            "Exception message should mention uppercase requirement.");
    }

    #endregion FromString Tests

    #region FromString with CleanAndFormat Tests

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat false behaves same as without cleanAndFormat parameter.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatFalse_BehavesLikeFromString()
    {
        // Arrange (Given)
        string validKey = "VALIDCODE123";

        // Act (When)
        var result = CommonBusinessKey.FromString(validKey, cleanAndFormat: false);

        // Assert (Then)
        Assert.IsNotNull(
            result,
            "FromString with cleanAndFormat=false should create an instance.");
        Assert.AreEqual(
            validKey,
            result.Key,
            "Key should match the provided value when cleanAndFormat is false.");
    }

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat true converts to uppercase.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatTrue_ConvertsToUppercase()
    {
        // Arrange (Given)
        string lowercaseKey = "lowercase";
        string expectedKey = "LOWERCASE";

        // Act (When)
        var result = CommonBusinessKey.FromString(lowercaseKey, cleanAndFormat: true);

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should be converted to uppercase when cleanAndFormat is true.");
    }

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat true trims whitespace.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatTrue_TrimsWhitespace()
    {
        // Arrange (Given)
        string keyWithWhitespace = "  BUSINESSKEY  ";
        string expectedKey = "BUSINESSKEY";

        // Act (When)
        var result = CommonBusinessKey.FromString(keyWithWhitespace, cleanAndFormat: true);

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should have leading and trailing whitespace removed when cleanAndFormat is true.");
    }

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat true replaces spaces with underscores.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatTrue_ReplacesSpacesWithUnderscores()
    {
        // Arrange (Given)
        string keyWithSpaces = "CODE NAME TEST";
        string expectedKey = "CODE_NAME_TEST";

        // Act (When)
        var result = CommonBusinessKey.FromString(keyWithSpaces, cleanAndFormat: true);

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should have spaces replaced with underscores when cleanAndFormat is true.");
    }

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat true performs all transformations.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatTrue_PerformsAllTransformations()
    {
        // Arrange (Given)
        string messyKey = "  code name test  ";
        string expectedKey = "CODE_NAME_TEST";

        // Act (When)
        var result = CommonBusinessKey.FromString(messyKey, cleanAndFormat: true);

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should be trimmed, uppercased, and have spaces replaced when cleanAndFormat is true.");
    }

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat true still validates invalid characters.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatTrueWithInvalidCharacters_ThrowsArgumentException()
    {
        // Arrange (Given)
        string invalidKey = "code@name";
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = CommonBusinessKey.FromString(invalidKey, cleanAndFormat: true);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString with cleanAndFormat=true should still throw ArgumentException for invalid characters.");
    }

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat true throws exception for null value.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatTrueNullValue_ThrowsArgumentException()
    {
        // Arrange (Given)
        string? nullKey = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = CommonBusinessKey.FromString(nullKey!, cleanAndFormat: true);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString with cleanAndFormat=true should throw ArgumentException when value is null.");
    }

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat true throws exception for empty string.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatTrueEmptyString_ThrowsArgumentException()
    {
        // Arrange (Given)
        string emptyKey = string.Empty;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = CommonBusinessKey.FromString(emptyKey, cleanAndFormat: true);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString with cleanAndFormat=true should throw ArgumentException when value is empty string.");
    }

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat true handles mixed case with spaces.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatTrueMixedCaseWithSpaces_ConvertsCorrectly()
    {
        // Arrange (Given)
        string mixedCaseWithSpaces = "Code Name 123";
        string expectedKey = "CODE_NAME_123";

        // Act (When)
        var result = CommonBusinessKey.FromString(mixedCaseWithSpaces, cleanAndFormat: true);

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should be uppercased with spaces replaced by underscores.");
    }

    /// <summary>
    /// Unit test to verify that FromString with cleanAndFormat true preserves valid special characters.
    /// </summary>
    [TestMethod]
    public void FromString_CleanAndFormatTrueWithValidSpecialCharacters_PreservesCharacters()
    {
        // Arrange (Given)
        string keyWithSpecialChars = "code-name.test/path";
        string expectedKey = "CODE-NAME.TEST/PATH";

        // Act (When)
        var result = CommonBusinessKey.FromString(keyWithSpecialChars, cleanAndFormat: true);

        // Assert (Then)
        Assert.AreEqual(
            expectedKey,
            result.Key,
            "Key should preserve valid special characters (hyphen, period, slash) when cleanAndFormat is true.");
    }

    #endregion FromString with CleanAndFormat Tests

    #endregion Public Methods
}