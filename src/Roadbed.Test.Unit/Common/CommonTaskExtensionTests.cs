namespace Roadbed.Test.Unit;

using Roadbed.Common;

/// <summary>
/// Contains unit tests for verifying the behavior of the CommonTaskExtensions class.
/// </summary>
[TestClass]
public class CommonTaskExtensionTests
{
    /// <summary>
    /// Unit test to verify XXXXXXXXX.
    /// </summary>
    [TestMethod]
    public async void CommonTaskExtensions_TimeoutAfter_ActualEmbeddedResource()
    {
        // Arrange (Given)
        var taskToTest = MethodTimeoutInOneMinuteAsync;
        var task = Task.Delay(0).TimeoutAfter(30);


        // Act (When)
        var response = await Task.Delay(60000).TimeoutAfter(30);

        CommonEmbeddedResourceResponse actualContent = this.GetType().Assembly.ReadTextResource(
            "Roadbed.Test.Unit.Mocks.EmbeddedTextDocument.txt");

        // Assert (Then)
        Assert.IsTrue(
            actualContent.IsReadSuccessful,
            "The embedded file should have been succesfully read.");
        Assert.Contains(
            expectedSnippet,
            actualContent.Data,
            "Expected content missing from embedded file.");
    }


    /// <summary>
    /// Asynchronously waits for one minute before completing.
    /// </summary>
    /// <returns>A task that represents the asynchronous wait operation.</returns>
    private static async Task MethodTimeoutInOneMinuteAsync(CancellationToken cancellationToken)
    {
        await MethodTimeoutAsync(cancellationToken, 60000);
    }

    /// <summary>
    /// Asynchronously waits for 10 seconds before completing.
    /// </summary>
    /// <returns>A task that represents the asynchronous wait operation.</returns>
    private static async Task MethodTimeoutInTenSecondsAsync(CancellationToken cancellationToken)
    {
        await MethodTimeoutAsync(cancellationToken, 10000);
    }

    /// <summary>
    /// Asynchronously waits for 10 seconds before completing.
    /// </summary>
    /// <returns>A task that represents the asynchronous wait operation.</returns>
    private static async Task MethodTimeoutAsync(CancellationToken cancellationToken, int milliseconds)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            cancellationToken.ThrowIfCancellationRequested();
        }

        await Task.Delay(milliseconds);
    }
}
