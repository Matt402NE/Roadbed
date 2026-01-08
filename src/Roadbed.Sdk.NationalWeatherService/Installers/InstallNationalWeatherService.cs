namespace Roadbed.Sdk.NationalWeatherService.Installers;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roadbed.Sdk.NationalWeatherService.Repositories;

/// <summary>
/// Installer for National Weather Service SDK.
/// </summary>
public sealed class InstallNationalWeatherService
    : IServiceCollectionInstaller
{
    #region Public Methods

    /// <inheritdoc/>
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Add Internal Repositories
        services.AddScoped<INwsAdminDistrictRepository, NwsAdminDistrictRepository>();
        services.AddScoped<INwsStationRepository, NwsStationRepository>();
        services.AddScoped<INwsOfficeRepository, NwsOfficeRepository>();
        services.AddScoped<INwsGridCoordinateRepository, NwsGridCoordinateRepository>();
        services.AddScoped<INwsForecastDailyRepository, NwsForecastDailyRepository>();
        services.AddScoped<INwsForecastHourlyRepository, NwsForecastHourlyRepository>();

        // Capture point-in-time snapshot in ServiceLocator. This allows the class library
        // to be self-contained (as a NuGet package) without depending on the consuming application
        // to do anything extra besides registering the middleware using one of the methods in
        // the Roadbed.Common.ServiceCollectionExtensions class.
        ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());
    }

    #endregion Public Methods
}