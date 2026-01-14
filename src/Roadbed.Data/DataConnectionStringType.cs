namespace Roadbed.Data;

/// <summary>
/// Types of data connection strings.
/// </summary>
public enum DataConnectionStringType
{
    /// <summary>
    /// Unknown Type.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// SQLite Database Connection Type.
    /// </summary>
    Sqlite = 1,

    /// <summary>
    /// SQLite In-Memory Database Connection Type.
    /// </summary>
    SqliteInMemory = 2,
}