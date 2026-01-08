
namespace Roadbed.Test.Integration.Sdk.NationalWeatherService;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roadbed.Common;
using Roadbed.Messaging;
using Roadbed.Net.Installers;

/// <summary>
/// Base class for National Weather Service (NWS) Tests
/// </summary>
[TestClass]
public abstract class BaseNwsTests
{
    #region Private Fields

    internal static readonly MessagingMessageRequest<CommonKeyValuePair<string, string>> MessagingRequest =
                new MessagingMessageRequest<CommonKeyValuePair<string, string>>(
                    new MessagingPublisher(CommonBusinessKey.FromString("Integration Test", true)),
                    "GITHUB.COM/MATT402NE/ROADBED");

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseNwsTests"/> class.
    /// </summary>
    public BaseNwsTests()
    {
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();
        var installer = new InstallNetHttpClient();

        // Install HTTP Client Factory
        installer.ConfigureServices(services, configuration);
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets object used to store information that is provided to unit tests.
    /// </summary>
    public TestContext TestContext { get; set; }

    #endregion Public Properties
}
