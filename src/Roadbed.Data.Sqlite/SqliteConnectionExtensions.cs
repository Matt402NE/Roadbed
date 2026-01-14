namespace Roadbed.Data.Sqlite;

using System;
using Microsoft.Data.Sqlite;

/// <summary>
/// Extension methods for SqliteConnection to support in-memory database operations.
/// </summary>
public static class SqliteConnectionExtensions
{
    /// <summary>
    /// Keeps an in-memory SQLite connection alive to prevent the database from being destroyed.
    /// </summary>
    /// <param name="connection">The SQLite connection to keep alive.</param>
    /// <returns>A disposable object that maintains the connection. Dispose when done to release the connection.</returns>
    /// <remarks>
    /// In-memory SQLite databases are destroyed when the last connection is closed.
    /// This method keeps a connection open to maintain the database across multiple operations.
    /// This is particularly useful for testing scenarios with shared cache in-memory databases.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when connection is null.</exception>
    /// <example>
    /// <code>
    /// var factory = new SqliteConnectionFactory(connectionString);
    /// var connection = await factory.CreateOpenConnectionAsync();
    /// using (var keepAlive = connection.KeepAlive())
    /// {
    ///     // Database will remain accessible through other connections
    ///     // until keepAlive is disposed
    /// }
    /// </code>
    /// </example>
    public static IDisposable KeepAlive(this SqliteConnection connection)
    {
        ArgumentNullException.ThrowIfNull(connection);

        return new KeepAliveHandle(connection);
    }

    /// <summary>
    /// Handle that maintains a reference to a SQLite connection to keep it alive.
    /// </summary>
    private sealed class KeepAliveHandle : IDisposable
    {
        private readonly SqliteConnection _connection;
        private bool _disposed;

        public KeepAliveHandle(SqliteConnection connection)
        {
            this._connection = connection;

            // Ensure the connection is open so the in-memory DB stays alive
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            // Close instead of Dispose. The caller owns the connection.
            this._connection.Close();

            this._disposed = true;
        }
    }
}