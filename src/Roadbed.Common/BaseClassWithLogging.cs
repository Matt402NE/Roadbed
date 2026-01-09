/*
 * The namespace Roadbed.Common was removed on purpose and replaced with Roadbed so that no additional using statements are required.
 */

namespace Roadbed;

using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

/// <summary>
/// Base class with logging implemented.
/// </summary>
/// <typeparam name="TCategoryName">Type inheriting from the Base.</typeparam>
public abstract class BaseClassWithLogging<TCategoryName>
{
    #region Private Fields

    /// <summary>
    /// Container for the public property Logger.
    /// </summary>
    private readonly ILogger<TCategoryName> _logger;

    /// <summary>
    /// Container for the public property LoggerFactory.
    /// </summary>
    private readonly ILoggerFactory _loggerFactory;

    #endregion Private Fields

    #region Protected Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseClassWithLogging{TCategoryName}"/> class.
    /// </summary>
    protected BaseClassWithLogging()
    {
        this._loggerFactory = NullLoggerFactory.Instance;
        this._logger = NullLogger<TCategoryName>.Instance;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseClassWithLogging{TCategoryName}"/> class.
    /// </summary>
    /// <param name="logger">Represents a type used to perform logging.</param>
    protected BaseClassWithLogging(ILogger logger)
    {
        this._loggerFactory = NullLoggerFactory.Instance;
        this._logger = logger as ILogger<TCategoryName> ?? NullLogger<TCategoryName>.Instance;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseClassWithLogging{TCategoryName}"/> class.
    /// </summary>
    /// <param name="loggerFactory">Represents a type used to configure the logging system and create instances of ILogger from the registered ILoggerProviders.</param>
    protected BaseClassWithLogging(ILoggerFactory loggerFactory)
    {
        this._loggerFactory = loggerFactory ?? NullLoggerFactory.Instance;
        this._logger = this._loggerFactory.CreateLogger<TCategoryName>();
    }

    #endregion Protected Constructors

    #region Public Properties

    /// <summary>
    /// Gets the type used to perform logging.
    /// </summary>
    public ILogger<TCategoryName> Logger => this._logger;

    /// <summary>
    /// Gets the type used to configure the logging system and create instances of ILogger from the registered ILoggerProviders.
    /// </summary>
    public ILoggerFactory LoggerFactory => this._loggerFactory;

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Appends a single key/value pair to the logging scope.
    /// </summary>
    /// <param name="key">Key for the dictionary entry.</param>
    /// <param name="value">Value for the dictionary entry.</param>
    /// <returns>Logger with the scope attached.</returns>
    /// <remarks>
    /// For more context, see https://andrewlock.net/creating-an-extension-method-for-attaching-key-value-pairs-to-scope-state-using-asp-net-core/.
    /// <code>
    /// using (this.BeginScope("transactionId", transaction.Id))
    /// {
    ///     this.LogInformation("Successful transaction");
    /// }
    /// </code>
    /// </remarks>
    public IDisposable? BeginScope(string key, object value)
    {
        return this.Logger.BeginScope(key, value);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="LogLevel.Debug"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    public void LogDebug(string message)
    {
        this.Logger.LogWithCheck(LogLevel.Debug, message);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="Debug"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    /// <param name="param">Message parameters.</param>
    public void LogDebug(string message, params object[] param)
    {
        this.Logger.LogWithCheck(LogLevel.Debug, message, param);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="LogLevel.Error"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    public void LogError(string message)
    {
        this.Logger.LogWithCheck(LogLevel.Error, message);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="LogLevel.Error"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    /// <param name="param">Message parameters.</param>
    public void LogError(string message, params object[] param)
    {
        this.Logger.LogWithCheck(LogLevel.Error, message, param);
    }

    /// <summary>
    /// Logs an exception with a severity level of <see cref="LogLevel.Error"/>.
    /// </summary>
    /// <param name="exception">Exception to log.</param>
    /// <param name="message">Message to log.</param>
    public void LogError(Exception exception, string message)
    {
        this.Logger.LogError(exception, message);
    }

    /// <summary>
    /// Logs an exception with a severity level of <see cref="LogLevel.Error"/>.
    /// </summary>
    /// <param name="exception">Exception to log.</param>
    /// <param name="message">Message to log.</param>
    /// <param name="param">Message parameters.</param>
    public void LogError(Exception exception, string message, params object[] param)
    {
        this.Logger.LogError(exception, message, param);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="LogLevel.Information"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    public void LogInformation(string message)
    {
        this.Logger.LogWithCheck(LogLevel.Information, message);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="LogLevel.Information"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    /// <param name="param">Message parameters.</param>
    public void LogInformation(string message, params object[] param)
    {
        this.Logger.LogWithCheck(LogLevel.Information, message, param);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="LogLevel.Trace"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    public void LogTrace(string message)
    {
        this.Logger.LogWithCheck(LogLevel.Trace, message);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="LogLevel.Trace"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    /// <param name="param">Message parameters.</param>
    public void LogTrace(string message, params object[] param)
    {
        this.Logger.LogWithCheck(LogLevel.Trace, message, param);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="LogLevel.Warning"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    public void LogWarning(string message)
    {
        this.Logger.LogWithCheck(LogLevel.Warning, message);
    }

    /// <summary>
    /// Logs a message with a severity level of <see cref="LogLevel.Warning"/>.
    /// </summary>
    /// <param name="message">Message to log.</param>
    /// <param name="param">Message parameters.</param>
    public void LogWarning(string message, params object[] param)
    {
        this.Logger.LogWithCheck(LogLevel.Warning, message, param);
    }

    #endregion Public Methods
}