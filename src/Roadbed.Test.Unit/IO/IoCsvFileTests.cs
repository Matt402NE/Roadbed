namespace Roadbed.Test.Unit.IO;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadbed.IO;

/// <summary>
/// Contains unit tests for verifying the behavior of the IoCsvFile class.
/// </summary>
[TestClass]
public class IoCsvFileTests
{
    #region Public Methods

    #region Constructor Tests

    /// <summary>
    /// Unit test to verify that the constructor with DataMapper initializes properties correctly.
    /// </summary>
    [TestMethod]
    public void Constructor_WithDataMapper_InitializesProperties()
    {
        // Arrange (Given)
        var dataMapper = new TestCsvEntityMapper();

        // Act (When)
        var instance = new TestIoCsvFile(dataMapper);

        // Assert (Then)
        Assert.IsNotNull(
            instance,
            "Instance should be created successfully.");
        Assert.IsNotNull(
            instance.DataRows,
            "DataRows should be initialized to empty list.");
        Assert.HasCount(
            0,
            instance.DataRows,
            "DataRows should be empty after construction.");
        Assert.AreSame(
            dataMapper,
            instance.DataMapper,
            "DataMapper should reference the same object that was passed to constructor.");
    }

    /// <summary>
    /// Unit test to verify that the constructor with null DataMapper throws ArgumentNullException.
    /// </summary>
    [TestMethod]
    public void Constructor_WithNullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        ICsvEntityMapper<TestDto>? nullDataMapper = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var instance = new TestIoCsvFile(nullDataMapper!);
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Constructor should throw ArgumentNullException when DataMapper is null.");
    }

    /// <summary>
    /// Unit test to verify that the constructor with FileInfo and DataMapper initializes properties correctly.
    /// </summary>
    [TestMethod]
    public void Constructor_WithFileInfoAndDataMapper_InitializesProperties()
    {
        // Arrange (Given)
        var fileInfo = new IoFileInfo(@"C:\TestFolder\TestFile.csv");
        var dataMapper = new TestCsvEntityMapper();

        // Act (When)
        var instance = new TestIoCsvFile(fileInfo, dataMapper);

        // Assert (Then)
        Assert.IsNotNull(
            instance,
            "Instance should be created successfully.");
        Assert.AreSame(
            fileInfo,
            instance.FileInfo,
            "FileInfo should reference the same object that was passed to constructor.");
        Assert.IsNotNull(
            instance.DataRows,
            "DataRows should be initialized to empty list.");
        Assert.HasCount(
            0,
            instance.DataRows,
            "DataRows should be empty after construction.");
        Assert.AreSame(
            dataMapper,
            instance.DataMapper,
            "DataMapper should reference the same object that was passed to constructor.");
    }

    /// <summary>
    /// Unit test to verify that the constructor with null DataMapper throws ArgumentNullException.
    /// </summary>
    [TestMethod]
    public void Constructor_WithFileInfoAndNullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        var fileInfo = new IoFileInfo(@"C:\TestFolder\TestFile.csv");
        ICsvEntityMapper<TestDto>? nullDataMapper = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var instance = new TestIoCsvFile(fileInfo, nullDataMapper!);
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "Constructor should throw ArgumentNullException when DataMapper is null.");
    }

    /// <summary>
    /// Unit test to verify that the constructor accepts mixed case CSV extension.
    /// </summary>
    [TestMethod]
    public void Constructor_WithMixedCaseCsvExtension_AcceptsExtension()
    {
        // Arrange (Given)
        var fileInfo = new IoFileInfo(@"C:\TestFolder\TestFile.CsV");
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var instance = new TestIoCsvFile(fileInfo, dataMapper);
        }
        catch (Exception)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsFalse(
            exceptionThrown,
            "Constructor should accept mixed case CSV extension.");
    }

    /// <summary>
    /// Unit test to verify that the constructor throws ArgumentException when extension is not CSV.
    /// </summary>
    [TestMethod]
    public void Constructor_WithNonCsvExtension_ThrowsArgumentException()
    {
        // Arrange (Given)
        var fileInfo = new IoFileInfo(@"C:\TestFolder\TestFile.txt");
        var dataMapper = new TestCsvEntityMapper();
        ArgumentException? caughtException = null;

        // Act (When)
        try
        {
            var instance = new TestIoCsvFile(fileInfo, dataMapper);
        }
        catch (ArgumentException ex)
        {
            caughtException = ex;
        }

        // Assert (Then)
        Assert.IsNotNull(
            caughtException,
            "Constructor should throw ArgumentException when extension is not CSV.");
        Assert.AreEqual(
            "fileInfo",
            caughtException.ParamName,
            "Exception should indicate fileInfo parameter name.");
        StringAssert.Contains(
            caughtException.Message,
            "File extension isn't 'CSV'",
            "Exception message should indicate incorrect file extension.");
    }

    /// <summary>
    /// Unit test to verify that the constructor throws ArgumentNullException when Extension is null.
    /// </summary>
    [TestMethod]
    public void Constructor_WithNullExtension_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        var fileInfo = new IoFileInfo();
        var dataMapper = new TestCsvEntityMapper();
        ArgumentNullException? caughtException = null;

        // Act (When)
        try
        {
            var instance = new TestIoCsvFile(fileInfo, dataMapper);
        }
        catch (ArgumentNullException ex)
        {
            caughtException = ex;
        }

        // Assert (Then)
        Assert.IsNotNull(
            caughtException,
            "Constructor should throw ArgumentNullException when Extension is null.");
        Assert.AreEqual(
            "fileInfo",
            caughtException.ParamName,
            "Exception should indicate fileInfo parameter name.");
    }

    /// <summary>
    /// Unit test to verify that the constructor throws ArgumentNullException when FileInfo is null.
    /// </summary>
    [TestMethod]
    public void Constructor_WithNullFileInfo_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        IoFileInfo? nullFileInfo = null;
        var dataMapper = new TestCsvEntityMapper();
        ArgumentNullException? caughtException = null;

        // Act (When)
        try
        {
            var instance = new TestIoCsvFile(nullFileInfo!, dataMapper);
        }
        catch (ArgumentNullException ex)
        {
            caughtException = ex;
        }

        // Assert (Then)
        Assert.IsNotNull(
            caughtException,
            "Constructor should throw ArgumentNullException when FileInfo is null.");
        Assert.AreEqual(
            "fileInfo",
            caughtException.ParamName,
            "Exception should indicate fileInfo parameter name.");
    }

    /// <summary>
    /// Unit test to verify that the constructor accepts uppercase CSV extension.
    /// </summary>
    [TestMethod]
    public void Constructor_WithUppercaseCsvExtension_AcceptsExtension()
    {
        // Arrange (Given)
        var fileInfo = new IoFileInfo(@"C:\TestFolder\TestFile.CSV");
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var instance = new TestIoCsvFile(fileInfo, dataMapper);
        }
        catch (Exception)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsFalse(
            exceptionThrown,
            "Constructor should accept uppercase CSV extension.");
    }

    #endregion Constructor Tests

    #region Property Tests

    /// <summary>
    /// Unit test to verify that DataMapper property can be set to null.
    /// </summary>
    [TestMethod]
    public void DataMapper_SetNull_AcceptsNullValue()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());

        // Act (When)
        instance.DataMapper = null;

        // Assert (Then)
        Assert.IsNull(
            instance.DataMapper,
            "DataMapper should be null when set to null.");
    }

    /// <summary>
    /// Unit test to verify that DataMapper property can be set and retrieved.
    /// </summary>
    [TestMethod]
    public void DataMapper_SetValidValue_ReturnsSetValue()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        var newMapper = new TestCsvEntityMapper();

        // Act (When)
        instance.DataMapper = newMapper;

        // Assert (Then)
        Assert.AreSame(
            newMapper,
            instance.DataMapper,
            "DataMapper should return the same object that was set.");
    }

    /// <summary>
    /// Unit test to verify that DataRows property can be set and retrieved.
    /// </summary>
    [TestMethod]
    public void DataRows_SetValidValue_ReturnsSetValue()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        var newDataRows = new List<TestDto>
        {
            new TestDto { Id = 1, Name = "Test1" },
            new TestDto { Id = 2, Name = "Test2" },
        };

        // Act (When)
        instance.DataRows = newDataRows;

        // Assert (Then)
        Assert.AreSame(
            newDataRows,
            instance.DataRows,
            "DataRows should return the same collection that was set.");
        Assert.HasCount(
            2,
            instance.DataRows,
            "DataRows should contain the expected number of items.");
    }

    #endregion Property Tests

    #region ExportDataRowsAsContentString Tests

    /// <summary>
    /// Unit test to verify that ExportDataRowsAsContentString returns header when DataRows is empty.
    /// </summary>
    [TestMethod]
    public void ExportDataRowsAsContentString_EmptyDataRows_ReturnsHeaderOnly()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.DataRows = new List<TestDto>();

        // Act (When)
        string result = instance.ExportDataRowsAsContentString();

        // Assert (Then)
        Assert.IsFalse(
            string.IsNullOrEmpty(result),
            "ExportDataRowsAsContentString should return header even with empty DataRows.");
        StringAssert.Contains(
            result,
            "Id",
            "Export should contain header for Id.");
        StringAssert.Contains(
            result,
            "Name",
            "Export should contain header for Name.");
    }

    /// <summary>
    /// Unit test to verify that ExportDataRowsAsContentString returns empty string when configuration is null.
    /// </summary>
    [TestMethod]
    public void ExportDataRowsAsContentString_NullConfiguration_ReturnsEmptyString()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.DataRows = new List<TestDto>
        {
            new TestDto { Id = 1, Name = "Test1" },
        };

        // Act (When)
        string result = instance.ExportDataRowsAsContentString(null!);

        // Assert (Then)
        Assert.AreEqual(
            string.Empty,
            result,
            "ExportDataRowsAsContentString should return empty string when configuration is null.");
    }

    /// <summary>
    /// Unit test to verify that ExportDataRowsAsContentString returns empty string when DataRows is null.
    /// </summary>
    [TestMethod]
    public void ExportDataRowsAsContentString_NullDataRows_ReturnsEmptyString()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.DataRows = null!;

        // Act (When)
        string result = instance.ExportDataRowsAsContentString();

        // Assert (Then)
        Assert.AreEqual(
            string.Empty,
            result,
            "ExportDataRowsAsContentString should return empty string when DataRows is null.");
    }

    /// <summary>
    /// Unit test to verify that ExportDataRowsAsContentString exports data correctly with default configuration.
    /// </summary>
    [TestMethod]
    public void ExportDataRowsAsContentString_WithDefaultConfiguration_ExportsDataCorrectly()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.DataRows = new List<TestDto>
        {
            new TestDto { Id = 1, Name = "Test1" },
            new TestDto { Id = 2, Name = "Test2" },
        };

        // Act (When)
        string result = instance.ExportDataRowsAsContentString();

        // Assert (Then)
        Assert.IsFalse(
            string.IsNullOrEmpty(result),
            "ExportDataRowsAsContentString should return non-empty string.");
        StringAssert.Contains(
            result,
            "Id",
            "Export should contain header for Id.");
        StringAssert.Contains(
            result,
            "Name",
            "Export should contain header for Name.");
        StringAssert.Contains(
            result,
            "Test1",
            "Export should contain data from first row.");
        StringAssert.Contains(
            result,
            "Test2",
            "Export should contain data from second row.");
    }

    #endregion ExportDataRowsAsContentString Tests

    #region FromFile Tests (Synchronous)

    /// <summary>
    /// Unit test to verify that FromFile throws exception when path is null.
    /// </summary>
    [TestMethod]
    public void FromFile_NullPath_ThrowsArgumentException()
    {
        // Arrange (Given)
        string? nullPath = null;
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = TestIoCsvFile.FromFile(nullPath!, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFile should throw ArgumentException when path is null.");
    }

    /// <summary>
    /// Unit test to verify that FromFile throws exception when path is empty.
    /// </summary>
    [TestMethod]
    public void FromFile_EmptyPath_ThrowsArgumentException()
    {
        // Arrange (Given)
        string emptyPath = string.Empty;
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = TestIoCsvFile.FromFile(emptyPath, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFile should throw ArgumentException when path is empty.");
    }

    /// <summary>
    /// Unit test to verify that FromFile throws exception when path is whitespace.
    /// </summary>
    [TestMethod]
    public void FromFile_WhitespacePath_ThrowsArgumentException()
    {
        // Arrange (Given)
        string whitespacePath = "   ";
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = TestIoCsvFile.FromFile(whitespacePath, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFile should throw ArgumentException when path is whitespace.");
    }

    /// <summary>
    /// Unit test to verify that FromFile throws exception when dataMapper is null.
    /// </summary>
    [TestMethod]
    public void FromFile_NullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        ICsvEntityMapper<TestDto>? nullDataMapper = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = TestIoCsvFile.FromFile(testPath, nullDataMapper!);
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFile should throw ArgumentNullException when dataMapper is null.");
    }

    /// <summary>
    /// Unit test to verify that FromFile throws exception when file does not exist.
    /// </summary>
    [TestMethod]
    public void FromFile_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        // Arrange (Given)
        string nonExistentPath = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.csv");
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = TestIoCsvFile.FromFile(nonExistentPath, dataMapper);
        }
        catch (FileNotFoundException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFile should throw FileNotFoundException when file does not exist.");
    }

    /// <summary>
    /// Unit test to verify that FromFile reads valid CSV file correctly.
    /// </summary>
    [TestMethod]
    public void FromFile_ValidCsvFile_ReadsDataCorrectly()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,Test1\n2,Test2\n3,Test3";
        var dataMapper = new TestCsvEntityMapper();

        try
        {
            File.WriteAllText(testPath, csvContent);

            // Act (When)
            var result = TestIoCsvFile.FromFile(testPath, dataMapper);

            // Assert (Then)
            Assert.IsNotNull(
                result,
                "FromFile should return a valid instance.");
            Assert.IsNotNull(
                result.DataRows,
                "DataRows should be populated.");
            Assert.HasCount(
                3,
                result.DataRows,
                "DataRows should contain all rows from CSV file.");
            Assert.AreEqual(
                "Test1",
                result.DataRows[0].Name,
                "First row should be read correctly.");
            Assert.AreEqual(
                2,
                result.DataRows[1].Id,
                "Second row should be read correctly.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    /// <summary>
    /// Unit test to verify that FromFile sets FileInfo property correctly.
    /// </summary>
    [TestMethod]
    public void FromFile_ValidCsvFile_SetsFileInfoCorrectly()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,Test1";
        var dataMapper = new TestCsvEntityMapper();

        try
        {
            File.WriteAllText(testPath, csvContent);

            // Act (When)
            var result = TestIoCsvFile.FromFile(testPath, dataMapper);

            // Assert (Then)
            Assert.IsNotNull(
                result.FileInfo,
                "FileInfo should be set.");
            Assert.AreEqual(
                testPath,
                result.FileInfo.FullPath,
                "FileInfo should have the correct path.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    #endregion FromFile Tests (Synchronous)

    #region FromFileAsync Tests (Asynchronous)

    /// <summary>
    /// Unit test to verify that FromFileAsync throws exception when path is null.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromFileAsync_NullPath_ThrowsArgumentException()
    {
        // Arrange (Given)
        string? nullPath = null;
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = await TestIoCsvFile.FromFileAsync(nullPath!, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFileAsync should throw ArgumentException when path is null.");
    }

    /// <summary>
    /// Unit test to verify that FromFileAsync throws exception when path is empty.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromFileAsync_EmptyPath_ThrowsArgumentException()
    {
        // Arrange (Given)
        string emptyPath = string.Empty;
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = await TestIoCsvFile.FromFileAsync(emptyPath, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFileAsync should throw ArgumentException when path is empty.");
    }

    /// <summary>
    /// Unit test to verify that FromFileAsync throws exception when path is whitespace.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromFileAsync_WhitespacePath_ThrowsArgumentException()
    {
        // Arrange (Given)
        string whitespacePath = "   ";
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = await TestIoCsvFile.FromFileAsync(whitespacePath, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFileAsync should throw ArgumentException when path is whitespace.");
    }

    /// <summary>
    /// Unit test to verify that FromFileAsync throws exception when dataMapper is null.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromFileAsync_NullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        ICsvEntityMapper<TestDto>? nullDataMapper = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = await TestIoCsvFile.FromFileAsync(testPath, nullDataMapper!);
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFileAsync should throw ArgumentNullException when dataMapper is null.");
    }

    /// <summary>
    /// Unit test to verify that FromFileAsync throws exception when file does not exist.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromFileAsync_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        // Arrange (Given)
        string nonExistentPath = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.csv");
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = await TestIoCsvFile.FromFileAsync(nonExistentPath, dataMapper);
        }
        catch (FileNotFoundException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromFileAsync should throw FileNotFoundException when file does not exist.");
    }

    /// <summary>
    /// Unit test to verify that FromFileAsync reads valid CSV file correctly.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromFileAsync_ValidCsvFile_ReadsDataCorrectly()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,Test1\n2,Test2\n3,Test3";
        var dataMapper = new TestCsvEntityMapper();

        try
        {
            await File.WriteAllTextAsync(testPath, csvContent);

            // Act (When)
            var result = await TestIoCsvFile.FromFileAsync(testPath, dataMapper);

            // Assert (Then)
            Assert.IsNotNull(
                result,
                "FromFileAsync should return a valid instance.");
            Assert.IsNotNull(
                result.DataRows,
                "DataRows should be populated.");
            Assert.HasCount(
                3,
                result.DataRows,
                "DataRows should contain all rows from CSV file.");
            Assert.AreEqual(
                "Test1",
                result.DataRows[0].Name,
                "First row should be read correctly.");
            Assert.AreEqual(
                2,
                result.DataRows[1].Id,
                "Second row should be read correctly.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    /// <summary>
    /// Unit test to verify that FromFileAsync sets FileInfo property correctly.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromFileAsync_ValidCsvFile_SetsFileInfoCorrectly()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,Test1";
        var dataMapper = new TestCsvEntityMapper();

        try
        {
            await File.WriteAllTextAsync(testPath, csvContent);

            // Act (When)
            var result = await TestIoCsvFile.FromFileAsync(testPath, dataMapper);

            // Assert (Then)
            Assert.IsNotNull(
                result.FileInfo,
                "FileInfo should be set.");
            Assert.AreEqual(
                testPath,
                result.FileInfo.FullPath,
                "FileInfo should have the correct path.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    #endregion FromFileAsync Tests (Asynchronous)

    #region FromString Tests (Synchronous)

    /// <summary>
    /// Unit test to verify that FromString throws exception when content is null.
    /// </summary>
    [TestMethod]
    public void FromString_NullContent_ThrowsArgumentException()
    {
        // Arrange (Given)
        string? nullContent = null;
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = TestIoCsvFile.FromString(nullContent!, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString should throw ArgumentException when content is null.");
    }

    /// <summary>
    /// Unit test to verify that FromString throws exception when content is empty.
    /// </summary>
    [TestMethod]
    public void FromString_EmptyContent_ThrowsArgumentException()
    {
        // Arrange (Given)
        string emptyContent = string.Empty;
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = TestIoCsvFile.FromString(emptyContent, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString should throw ArgumentException when content is empty.");
    }

    /// <summary>
    /// Unit test to verify that FromString throws exception when content is whitespace.
    /// </summary>
    [TestMethod]
    public void FromString_WhitespaceContent_ThrowsArgumentException()
    {
        // Arrange (Given)
        string whitespaceContent = "   ";
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = TestIoCsvFile.FromString(whitespaceContent, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString should throw ArgumentException when content is whitespace.");
    }

    /// <summary>
    /// Unit test to verify that FromString throws exception when dataMapper is null.
    /// </summary>
    [TestMethod]
    public void FromString_NullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        string csvContent = "Id,Name\n1,Test1";
        ICsvEntityMapper<TestDto>? nullDataMapper = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = TestIoCsvFile.FromString(csvContent, nullDataMapper!);
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromString should throw ArgumentNullException when dataMapper is null.");
    }

    /// <summary>
    /// Unit test to verify that FromString handles content with only headers.
    /// </summary>
    [TestMethod]
    public void FromString_HeaderOnlyContent_ReturnsEmptyDataRows()
    {
        // Arrange (Given)
        string csvContent = "Id,Name";
        var dataMapper = new TestCsvEntityMapper();

        // Act (When)
        var result = TestIoCsvFile.FromString(csvContent, dataMapper);

        // Assert (Then)
        Assert.IsNotNull(
            result,
            "FromString should return a valid instance.");
        Assert.HasCount(
            0,
            result.DataRows,
            "DataRows should be empty when CSV has only headers.");
    }

    /// <summary>
    /// Unit test to verify that FromString does not set FileInfo property.
    /// </summary>
    [TestMethod]
    public void FromString_ValidCsvContent_DoesNotSetFileInfo()
    {
        // Arrange (Given)
        string csvContent = "Id,Name\n1,Test1";
        var dataMapper = new TestCsvEntityMapper();

        // Act (When)
        var result = TestIoCsvFile.FromString(csvContent, dataMapper);

        // Assert (Then)
        Assert.IsNull(
            result.FileInfo,
            "FileInfo should be null when created from string.");
    }

    /// <summary>
    /// Unit test to verify that FromString reads valid CSV content correctly.
    /// </summary>
    [TestMethod]
    public void FromString_ValidCsvContent_ReadsDataCorrectly()
    {
        // Arrange (Given)
        string csvContent = "Id,Name\n1,Test1\n2,Test2\n3,Test3";
        var dataMapper = new TestCsvEntityMapper();

        // Act (When)
        var result = TestIoCsvFile.FromString(csvContent, dataMapper);

        // Assert (Then)
        Assert.IsNotNull(
            result,
            "FromString should return a valid instance.");
        Assert.IsNotNull(
            result.DataRows,
            "DataRows should be populated.");
        Assert.HasCount(
            3,
            result.DataRows,
            "DataRows should contain all rows from CSV content.");
        Assert.AreEqual(
            "Test1",
            result.DataRows[0].Name,
            "First row should be read correctly.");
        Assert.AreEqual(
            2,
            result.DataRows[1].Id,
            "Second row should be read correctly.");
    }

    #endregion FromString Tests (Synchronous)

    #region FromStringAsync Tests (Asynchronous)

    /// <summary>
    /// Unit test to verify that FromStringAsync throws exception when content is null.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromStringAsync_NullContent_ThrowsArgumentException()
    {
        // Arrange (Given)
        string? nullContent = null;
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = await TestIoCsvFile.FromStringAsync(nullContent!, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromStringAsync should throw ArgumentException when content is null.");
    }

    /// <summary>
    /// Unit test to verify that FromStringAsync throws exception when content is empty.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromStringAsync_EmptyContent_ThrowsArgumentException()
    {
        // Arrange (Given)
        string emptyContent = string.Empty;
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = await TestIoCsvFile.FromStringAsync(emptyContent, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromStringAsync should throw ArgumentException when content is empty.");
    }

    /// <summary>
    /// Unit test to verify that FromStringAsync throws exception when content is whitespace.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromStringAsync_WhitespaceContent_ThrowsArgumentException()
    {
        // Arrange (Given)
        string whitespaceContent = "   ";
        var dataMapper = new TestCsvEntityMapper();
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = await TestIoCsvFile.FromStringAsync(whitespaceContent, dataMapper);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromStringAsync should throw ArgumentException when content is whitespace.");
    }

    /// <summary>
    /// Unit test to verify that FromStringAsync throws exception when dataMapper is null.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromStringAsync_NullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        string csvContent = "Id,Name\n1,Test1";
        ICsvEntityMapper<TestDto>? nullDataMapper = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            var result = await TestIoCsvFile.FromStringAsync(csvContent, nullDataMapper!);
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "FromStringAsync should throw ArgumentNullException when dataMapper is null.");
    }

    /// <summary>
    /// Unit test to verify that FromStringAsync handles content with only headers.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromStringAsync_HeaderOnlyContent_ReturnsEmptyDataRows()
    {
        // Arrange (Given)
        string csvContent = "Id,Name";
        var dataMapper = new TestCsvEntityMapper();

        // Act (When)
        var result = await TestIoCsvFile.FromStringAsync(csvContent, dataMapper);

        // Assert (Then)
        Assert.IsNotNull(
            result,
            "FromStringAsync should return a valid instance.");
        Assert.HasCount(
            0,
            result.DataRows,
            "DataRows should be empty when CSV has only headers.");
    }

    /// <summary>
    /// Unit test to verify that FromStringAsync does not set FileInfo property.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromStringAsync_ValidCsvContent_DoesNotSetFileInfo()
    {
        // Arrange (Given)
        string csvContent = "Id,Name\n1,Test1";
        var dataMapper = new TestCsvEntityMapper();

        // Act (When)
        var result = await TestIoCsvFile.FromStringAsync(csvContent, dataMapper);

        // Assert (Then)
        Assert.IsNull(
            result.FileInfo,
            "FileInfo should be null when created from string.");
    }

    /// <summary>
    /// Unit test to verify that FromStringAsync reads valid CSV content correctly.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task FromStringAsync_ValidCsvContent_ReadsDataCorrectly()
    {
        // Arrange (Given)
        string csvContent = "Id,Name\n1,Test1\n2,Test2\n3,Test3";
        var dataMapper = new TestCsvEntityMapper();

        // Act (When)
        var result = await TestIoCsvFile.FromStringAsync(csvContent, dataMapper);

        // Assert (Then)
        Assert.IsNotNull(
            result,
            "FromStringAsync should return a valid instance.");
        Assert.IsNotNull(
            result.DataRows,
            "DataRows should be populated.");
        Assert.HasCount(
            3,
            result.DataRows,
            "DataRows should contain all rows from CSV content.");
        Assert.AreEqual(
            "Test1",
            result.DataRows[0].Name,
            "First row should be read correctly.");
        Assert.AreEqual(
            2,
            result.DataRows[1].Id,
            "Second row should be read correctly.");
    }

    #endregion FromStringAsync Tests (Asynchronous)

    #region LoadDataRowsFromFile Tests (Synchronous)

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromFile resets existing DataRows.
    /// </summary>
    [TestMethod]
    public void LoadDataRowsFromFile_ExistingDataRows_ResetsDataRows()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,NewTest";

        try
        {
            File.WriteAllText(testPath, csvContent);

            var instance = new TestIoCsvFile(new TestCsvEntityMapper());
            instance.FileInfo = new IoFileInfo(testPath);
            instance.DataRows = new List<TestDto>
            {
                new TestDto { Id = 99, Name = "OldTest" },
            };

            // Act (When)
            instance.LoadDataRowsFromFile();

            // Assert (Then)
            Assert.HasCount(
                1,
                instance.DataRows,
                "DataRows should contain only new data from file.");
            Assert.AreEqual(
                "NewTest",
                instance.DataRows[0].Name,
                "DataRows should contain new data, not old data.");
            Assert.AreEqual(
                1,
                instance.DataRows[0].Id,
                "DataRows should contain new data, not old data.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromFile throws ArgumentNullException when DataMapper is null.
    /// </summary>
    [TestMethod]
    public void LoadDataRowsFromFile_NullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,Test1";

        try
        {
            File.WriteAllText(testPath, csvContent);

            var instance = new TestIoCsvFile(new TestCsvEntityMapper());
            instance.FileInfo = new IoFileInfo(testPath);
            instance.DataMapper = null;
            ArgumentNullException? caughtException = null;

            // Act (When)
            try
            {
                instance.LoadDataRowsFromFile();
            }
            catch (ArgumentNullException ex)
            {
                caughtException = ex;
            }

            // Assert (Then)
            Assert.IsNotNull(
                caughtException,
                "LoadDataRowsFromFile should throw ArgumentNullException when DataMapper is null.");
            Assert.AreEqual(
                "dataMapper",
                caughtException.ParamName,
                "Exception should indicate dataMapper parameter name.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromFile throws ArgumentNullException when FileInfo is null.
    /// </summary>
    [TestMethod]
    public void LoadDataRowsFromFile_NullFileInfo_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.FileInfo = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            instance.LoadDataRowsFromFile();
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "LoadDataRowsFromFile should throw ArgumentNullException when FileInfo is null.");
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromFile reads file correctly.
    /// </summary>
    [TestMethod]
    public void LoadDataRowsFromFile_ValidFile_PopulatesDataRows()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,Test1\n2,Test2";

        try
        {
            File.WriteAllText(testPath, csvContent);

            var instance = new TestIoCsvFile(new TestCsvEntityMapper());
            instance.FileInfo = new IoFileInfo(testPath);

            // Act (When)
            instance.LoadDataRowsFromFile();

            // Assert (Then)
            Assert.IsNotNull(
                instance.DataRows,
                "DataRows should be populated.");
            Assert.HasCount(
                2,
                instance.DataRows,
                "DataRows should contain all rows from file.");
            Assert.AreEqual(
                "Test1",
                instance.DataRows[0].Name,
                "First row should be read correctly.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    #endregion LoadDataRowsFromFile Tests (Synchronous)

    #region LoadDataRowsFromFileAsync Tests (Asynchronous)

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromFileAsync resets existing DataRows.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task LoadDataRowsFromFileAsync_ExistingDataRows_ResetsDataRows()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,NewTest";

        try
        {
            await File.WriteAllTextAsync(testPath, csvContent);

            var instance = new TestIoCsvFile(new TestCsvEntityMapper());
            instance.FileInfo = new IoFileInfo(testPath);
            instance.DataRows = new List<TestDto>
            {
                new TestDto { Id = 99, Name = "OldTest" },
            };

            // Act (When)
            await instance.LoadDataRowsFromFileAsync();

            // Assert (Then)
            Assert.HasCount(
                1,
                instance.DataRows,
                "DataRows should contain only new data from file.");
            Assert.AreEqual(
                "NewTest",
                instance.DataRows[0].Name,
                "DataRows should contain new data, not old data.");
            Assert.AreEqual(
                1,
                instance.DataRows[0].Id,
                "DataRows should contain new data, not old data.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromFileAsync throws ArgumentNullException when DataMapper is null.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task LoadDataRowsFromFileAsync_NullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,Test1";

        try
        {
            await File.WriteAllTextAsync(testPath, csvContent);

            var instance = new TestIoCsvFile(new TestCsvEntityMapper());
            instance.FileInfo = new IoFileInfo(testPath);
            instance.DataMapper = null;
            ArgumentNullException? caughtException = null;

            // Act (When)
            try
            {
                await instance.LoadDataRowsFromFileAsync();
            }
            catch (ArgumentNullException ex)
            {
                caughtException = ex;
            }

            // Assert (Then)
            Assert.IsNotNull(
                caughtException,
                "LoadDataRowsFromFileAsync should throw ArgumentNullException when DataMapper is null.");
            Assert.AreEqual(
                "dataMapper",
                caughtException.ParamName,
                "Exception should indicate dataMapper parameter name.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromFileAsync throws ArgumentNullException when FileInfo is null.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task LoadDataRowsFromFileAsync_NullFileInfo_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.FileInfo = null;
        bool exceptionThrown = false;

        // Act (When)
        try
        {
            await instance.LoadDataRowsFromFileAsync();
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        // Assert (Then)
        Assert.IsTrue(
            exceptionThrown,
            "LoadDataRowsFromFileAsync should throw ArgumentNullException when FileInfo is null.");
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromFileAsync reads file correctly.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task LoadDataRowsFromFileAsync_ValidFile_PopulatesDataRows()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        string csvContent = "Id,Name\n1,Test1\n2,Test2";

        try
        {
            await File.WriteAllTextAsync(testPath, csvContent);

            var instance = new TestIoCsvFile(new TestCsvEntityMapper());
            instance.FileInfo = new IoFileInfo(testPath);

            // Act (When)
            await instance.LoadDataRowsFromFileAsync();

            // Assert (Then)
            Assert.IsNotNull(
                instance.DataRows,
                "DataRows should be populated.");
            Assert.HasCount(
                2,
                instance.DataRows,
                "DataRows should contain all rows from file.");
            Assert.AreEqual(
                "Test1",
                instance.DataRows[0].Name,
                "First row should be read correctly.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    #endregion LoadDataRowsFromFileAsync Tests (Asynchronous)

    #region LoadDataRowsFromString Tests (Synchronous)

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromString resets existing DataRows.
    /// </summary>
    [TestMethod]
    public void LoadDataRowsFromString_ExistingDataRows_ResetsDataRows()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        string csvContent = "Id,Name\n1,NewTest";
        instance.DataRows = new List<TestDto>
        {
            new TestDto { Id = 99, Name = "OldTest" },
        };

        // Act (When)
        instance.LoadDataRowsFromString(csvContent);

        // Assert (Then)
        Assert.HasCount(
            1,
            instance.DataRows,
            "DataRows should contain only new data from content.");
        Assert.AreEqual(
            "NewTest",
            instance.DataRows[0].Name,
            "DataRows should contain new data, not old data.");
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromString throws ArgumentNullException when DataMapper is null.
    /// </summary>
    [TestMethod]
    public void LoadDataRowsFromString_NullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.DataMapper = null;
        string csvContent = "Id,Name\n1,Test1";
        ArgumentNullException? caughtException = null;

        // Act (When)
        try
        {
            instance.LoadDataRowsFromString(csvContent);
        }
        catch (ArgumentNullException ex)
        {
            caughtException = ex;
        }

        // Assert (Then)
        Assert.IsNotNull(
            caughtException,
            "LoadDataRowsFromString should throw ArgumentNullException when DataMapper is null.");
        Assert.AreEqual(
            "dataMapper",
            caughtException.ParamName,
            "Exception should indicate dataMapper parameter name.");
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromString reads content correctly.
    /// </summary>
    [TestMethod]
    public void LoadDataRowsFromString_ValidContent_PopulatesDataRows()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        string csvContent = "Id,Name\n1,Test1\n2,Test2";

        // Act (When)
        instance.LoadDataRowsFromString(csvContent);

        // Assert (Then)
        Assert.IsNotNull(
            instance.DataRows,
            "DataRows should be populated.");
        Assert.HasCount(
            2,
            instance.DataRows,
            "DataRows should contain all rows from content.");
        Assert.AreEqual(
            "Test1",
            instance.DataRows[0].Name,
            "First row should be read correctly.");
    }

    #endregion LoadDataRowsFromString Tests (Synchronous)

    #region LoadDataRowsFromStringAsync Tests (Asynchronous)

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromStringAsync resets existing DataRows.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task LoadDataRowsFromStringAsync_ExistingDataRows_ResetsDataRows()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        string csvContent = "Id,Name\n1,NewTest";
        instance.DataRows = new List<TestDto>
        {
            new TestDto { Id = 99, Name = "OldTest" },
        };

        // Act (When)
        await instance.LoadDataRowsFromStringAsync(csvContent);

        // Assert (Then)
        Assert.HasCount(
            1,
            instance.DataRows,
            "DataRows should contain only new data from content.");
        Assert.AreEqual(
            "NewTest",
            instance.DataRows[0].Name,
            "DataRows should contain new data, not old data.");
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromStringAsync throws ArgumentNullException when DataMapper is null.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task LoadDataRowsFromStringAsync_NullDataMapper_ThrowsArgumentNullException()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.DataMapper = null;
        string csvContent = "Id,Name\n1,Test1";
        ArgumentNullException? caughtException = null;

        // Act (When)
        try
        {
            await instance.LoadDataRowsFromStringAsync(csvContent);
        }
        catch (ArgumentNullException ex)
        {
            caughtException = ex;
        }

        // Assert (Then)
        Assert.IsNotNull(
            caughtException,
            "LoadDataRowsFromStringAsync should throw ArgumentNullException when DataMapper is null.");
        Assert.AreEqual(
            "dataMapper",
            caughtException.ParamName,
            "Exception should indicate dataMapper parameter name.");
    }

    /// <summary>
    /// Unit test to verify that LoadDataRowsFromStringAsync reads content correctly.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task LoadDataRowsFromStringAsync_ValidContent_PopulatesDataRows()
    {
        // Arrange (Given)
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        string csvContent = "Id,Name\n1,Test1\n2,Test2";

        // Act (When)
        await instance.LoadDataRowsFromStringAsync(csvContent);

        // Assert (Then)
        Assert.IsNotNull(
            instance.DataRows,
            "DataRows should be populated.");
        Assert.HasCount(
            2,
            instance.DataRows,
            "DataRows should contain all rows from content.");
        Assert.AreEqual(
            "Test1",
            instance.DataRows[0].Name,
            "First row should be read correctly.");
    }

    #endregion LoadDataRowsFromStringAsync Tests (Asynchronous)

    #region Save Method Tests (Synchronous)

    /// <summary>
    /// Unit test to verify that Save method returns file path.
    /// </summary>
    [TestMethod]
    public void Save_ValidData_ReturnsFilePath()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.FileInfo = new IoFileInfo(testPath);
        instance.DataRows = new List<TestDto>
        {
            new TestDto { Id = 1, Name = "Test1" },
        };

        try
        {
            // Act (When)
            string result = instance.Save();

            // Assert (Then)
            Assert.AreEqual(
                testPath,
                result,
                "Save should return the file path that was saved.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    #endregion Save Method Tests (Synchronous)

    #region SaveAsync Method Tests (Asynchronous)

    /// <summary>
    /// Unit test to verify that SaveAsync method returns file path.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task SaveAsync_ValidData_ReturnsFilePath()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.FileInfo = new IoFileInfo(testPath);
        instance.DataRows = new List<TestDto>
        {
            new TestDto { Id = 1, Name = "Test1" },
        };

        try
        {
            // Act (When)
            string result = await instance.SaveAsync();

            // Assert (Then)
            Assert.AreEqual(
                testPath,
                result,
                "SaveAsync should return the file path that was saved.");
            Assert.IsTrue(
                File.Exists(testPath),
                "File should exist after SaveAsync is called.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    /// <summary>
    /// Unit test to verify that SaveAsync method writes file correctly.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task SaveAsync_ValidData_WritesFileCorrectly()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        var instance = new TestIoCsvFile(new TestCsvEntityMapper());
        instance.FileInfo = new IoFileInfo(testPath);
        instance.DataRows = new List<TestDto>
        {
            new TestDto { Id = 1, Name = "Test1" },
            new TestDto { Id = 2, Name = "Test2" },
        };

        try
        {
            // Act (When)
            await instance.SaveAsync();
            string fileContent = await File.ReadAllTextAsync(testPath);

            // Assert (Then)
            StringAssert.Contains(
                fileContent,
                "Test1",
                "File should contain data from first row.");
            StringAssert.Contains(
                fileContent,
                "Test2",
                "File should contain data from second row.");
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    #endregion SaveAsync Method Tests (Asynchronous)

    #region Integration Tests (Synchronous)

    /// <summary>
    /// Unit test to verify that data can be round-tripped through string operations.
    /// </summary>
    [TestMethod]
    public void Integration_ExportAndLoadString_PreservesData()
    {
        // Arrange (Given)
        var originalData = new List<TestDto>
        {
            new TestDto { Id = 1, Name = "Test1" },
            new TestDto { Id = 2, Name = "Test2" },
        };

        var exportInstance = new TestIoCsvFile(new TestCsvEntityMapper());
        exportInstance.DataRows = originalData;

        // Export data
        string csvContent = exportInstance.ExportDataRowsAsContentString();

        // Act (When) - Load from string
        var loadInstance = TestIoCsvFile.FromString(csvContent, new TestCsvEntityMapper());

        // Assert (Then)
        Assert.HasCount(
            originalData.Count,
            loadInstance.DataRows,
            "Loaded data should have same count as exported data.");

        for (int i = 0; i < originalData.Count; i++)
        {
            Assert.AreEqual(
                originalData[i].Id,
                loadInstance.DataRows[i].Id,
                $"Id of row {i} should match.");
            Assert.AreEqual(
                originalData[i].Name,
                loadInstance.DataRows[i].Name,
                $"Name of row {i} should match.");
        }
    }

    #endregion Integration Tests (Synchronous)

    #region Integration Tests (Asynchronous)

    /// <summary>
    /// Unit test to verify that data can be round-tripped through async string operations.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task Integration_ExportAndLoadStringAsync_PreservesData()
    {
        // Arrange (Given)
        var originalData = new List<TestDto>
        {
            new TestDto { Id = 1, Name = "Test1" },
            new TestDto { Id = 2, Name = "Test2" },
        };

        var exportInstance = new TestIoCsvFile(new TestCsvEntityMapper());
        exportInstance.DataRows = originalData;

        // Export data
        string csvContent = exportInstance.ExportDataRowsAsContentString();

        // Act (When) - Load from string asynchronously
        var loadInstance = await TestIoCsvFile.FromStringAsync(csvContent, new TestCsvEntityMapper());

        // Assert (Then)
        Assert.HasCount(
            originalData.Count,
            loadInstance.DataRows,
            "Loaded data should have same count as exported data.");

        for (int i = 0; i < originalData.Count; i++)
        {
            Assert.AreEqual(
                originalData[i].Id,
                loadInstance.DataRows[i].Id,
                $"Id of row {i} should match.");
            Assert.AreEqual(
                originalData[i].Name,
                loadInstance.DataRows[i].Name,
                $"Name of row {i} should match.");
        }
    }

    /// <summary>
    /// Unit test to verify that data can be round-tripped through async file operations.
    /// </summary>
    /// <returns>Task that represents the asynchronous test operation.</returns>
    [TestMethod]
    public async Task Integration_SaveAndLoadAsync_PreservesData()
    {
        // Arrange (Given)
        string testPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.csv");
        var originalData = new List<TestDto>
        {
            new TestDto { Id = 1, Name = "Test1" },
            new TestDto { Id = 2, Name = "Test2" },
            new TestDto { Id = 3, Name = "Test3" },
        };

        try
        {
            // Save data asynchronously
            var saveInstance = new TestIoCsvFile(new TestCsvEntityMapper());
            saveInstance.FileInfo = new IoFileInfo(testPath);
            saveInstance.DataRows = originalData;
            await saveInstance.SaveAsync();

            // Act (When) - Load data asynchronously
            var loadInstance = await TestIoCsvFile.FromFileAsync(testPath, new TestCsvEntityMapper());

            // Assert (Then)
            Assert.HasCount(
                originalData.Count,
                loadInstance.DataRows,
                "Loaded data should have same count as saved data.");

            for (int i = 0; i < originalData.Count; i++)
            {
                Assert.AreEqual(
                    originalData[i].Id,
                    loadInstance.DataRows[i].Id,
                    $"Id of row {i} should match.");
                Assert.AreEqual(
                    originalData[i].Name,
                    loadInstance.DataRows[i].Name,
                    $"Name of row {i} should match.");
            }
        }
        finally
        {
            // Cleanup
            if (File.Exists(testPath))
            {
                File.Delete(testPath);
            }
        }
    }

    #endregion Integration Tests (Asynchronous)

    #endregion Public Methods

    #region Private Classes

    /// <summary>
    /// Test implementation of ICsvEntityMapper for testing purposes.
    /// </summary>
    private class TestCsvEntityMapper : ICsvEntityMapper<TestDto>
    {
        #region Public Methods

        public TestDto MapEntity(CsvReader csvReader)
        {
            return new TestDto
            {
                Id = csvReader.GetField<int>("Id"),
                Name = csvReader.GetField<string>("Name") ?? string.Empty,
            };
        }

        #endregion Public Methods
    }

    /// <summary>
    /// Test DTO for CSV file testing.
    /// </summary>
    private class TestDto
    {
        #region Public Properties

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        #endregion Public Properties
    }

    /// <summary>
    /// Test implementation of IoCsvFile for testing purposes.
    /// </summary>
    private class TestIoCsvFile : IoCsvFile<TestDto>
    {
        #region Public Constructors

        public TestIoCsvFile(ICsvEntityMapper<TestDto> dataMapper)
            : base(dataMapper)
        {
        }

        public TestIoCsvFile(IoFileInfo fileInfo, ICsvEntityMapper<TestDto> dataMapper)
            : base(fileInfo, dataMapper)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public static new TestIoCsvFile FromFile(string path, ICsvEntityMapper<TestDto> dataMapper)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(path);
            ArgumentNullException.ThrowIfNull(dataMapper);

            TestIoCsvFile file = new TestIoCsvFile(
                new IoFileInfo(path),
                dataMapper);

            file.LoadDataRowsFromFile();

            return file;
        }

        public static new async Task<TestIoCsvFile> FromFileAsync(string path, ICsvEntityMapper<TestDto> dataMapper)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(path);
            ArgumentNullException.ThrowIfNull(dataMapper);

            TestIoCsvFile file = new TestIoCsvFile(
                new IoFileInfo(path),
                dataMapper);

            await file.LoadDataRowsFromFileAsync();

            return file;
        }

        public static new TestIoCsvFile FromString(string content, ICsvEntityMapper<TestDto> dataMapper)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(content);
            ArgumentNullException.ThrowIfNull(dataMapper);

            TestIoCsvFile file = new TestIoCsvFile(dataMapper);

            file.LoadDataRowsFromString(content);

            return file;
        }

        public static new async Task<TestIoCsvFile> FromStringAsync(string content, ICsvEntityMapper<TestDto> dataMapper)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(content);
            ArgumentNullException.ThrowIfNull(dataMapper);

            TestIoCsvFile file = new TestIoCsvFile(dataMapper);

            await file.LoadDataRowsFromStringAsync(content);

            return file;
        }

        #endregion Public Methods
    }

    #endregion Private Classes
}