/*
 * The namespace Roadbed.Common.Dtos was removed on purpose and replaced with Roadbed.Common so that no additional using statements are required.
 */

namespace Roadbed.Common;

using System;
using System.Text.RegularExpressions;

/// <summary>
/// Business Key value object.
/// </summary>
public partial record CommonBusinessKey
{
    #region Public Fields

    /// <summary>
    /// A valid Business Key contains any single English character that is an UPPERCASE letter.
    /// Valid characters also include any digit (0-9), a period (.), a forward slash (/), an underscore (_), or a hyphen (-).
    /// </summary>
    public const string RegularExpressionPattern = @"^[A-Z0-9./_-]+$";

    #endregion Public Fields

    #region Private Fields

    private string _key = string.Empty;

    #endregion Private Fields

    #region Public Properties

    /// <summary>
    /// Gets or sets the Key that represents the Business Key.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when Business Key is null, empty, or invalid.</exception>
    public string Key
    {
        get
        {
            return this._key;
        }

        set
        {
            this.SetBusinessKey(value);
        }
    }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Creates a Business Key from a string value.
    /// </summary>
    /// <param name="key">String value to validate and convert into a Business Key.</param>
    /// <returns>Business Key value object.</returns>
    /// <exception cref="ArgumentException">Thrown when key is null, empty, or invalid.</exception>
    public static CommonBusinessKey FromString(string key)
    {
        return new CommonBusinessKey()
        {
            Key = key,
        };
    }

    /// <summary>
    /// Creates a Business Key from a string value with optional cleaning and formatting.
    /// </summary>
    /// <param name="key">String value to validate and convert into a Business Key.</param>
    /// <param name="cleanAndFormat">
    /// Flag indicating whether the key value should be cleaned and converted into a valid Business Key. When true,
    /// the 'key' parameter will be cleaned and converted:
    /// <code>
    /// key.Trim().ToUpperInvariant().Replace(" ", "_");
    /// </code>
    /// </param>
    /// <returns>Business Key value object.</returns>
    /// <exception cref="ArgumentException">Thrown when key is null, empty, or invalid.</exception>
    public static CommonBusinessKey FromString(string key, bool cleanAndFormat)
    {
        string cleanedBusinessKey = key;

        if (cleanAndFormat &&
            !string.IsNullOrEmpty(key))
        {
            // Remove leading and trailing spaces, convert other spaces to underscores,
            // and uppercase the alphabetic characters.
            cleanedBusinessKey = key.Trim().ToUpperInvariant().Replace(" ", "_");
        }

        return CommonBusinessKey.FromString(cleanedBusinessKey);
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Gets the compiled regex for validating Business Keys.
    /// </summary>
    /// <returns>A compiled regex for Business Key validation.</returns>
    [GeneratedRegex(RegularExpressionPattern)]
    private static partial Regex BusinessKeyRegex();

    /// <summary>
    /// Sets the <see cref="Key"/> property after validating the value.
    /// </summary>
    /// <param name="key">String value to validate.</param>
    /// <exception cref="ArgumentException">Thrown when Business Key is null, empty, or invalid.</exception>
    private void SetBusinessKey(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        bool valid = BusinessKeyRegex().IsMatch(key);

        if (!valid)
        {
            string uppercaseKey = key.ToUpperInvariant();

            if (uppercaseKey != key)
            {
                throw new ArgumentException("Business Keys must be uppercase.", nameof(key));
            }

            throw new ArgumentException(
                "Business Key value not valid. Only uppercase English A-Z characters as well as any digit (0-9), a period (.), a forward slash (/), an underscore (_), or a hyphen (-) are allowed in Business Keys.",
                nameof(key));
        }

        this._key = key;
    }

    #endregion Private Methods
}