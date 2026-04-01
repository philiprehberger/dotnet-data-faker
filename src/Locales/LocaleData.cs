namespace Philiprehberger.DataFaker.Locales;

/// <summary>
/// Defines locale-specific data for name and address generation.
/// </summary>
internal sealed class LocaleData
{
    /// <summary>
    /// Gets the locale code (e.g. "en-US", "de-DE").
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// Gets the pool of locale-specific first names.
    /// </summary>
    public required string[] FirstNames { get; init; }

    /// <summary>
    /// Gets the pool of locale-specific last names.
    /// </summary>
    public required string[] LastNames { get; init; }

    /// <summary>
    /// Gets the pool of locale-specific city names.
    /// </summary>
    public required string[] Cities { get; init; }

    /// <summary>
    /// Gets the phone number format where '#' is replaced with a digit.
    /// </summary>
    public required string PhoneFormat { get; init; }
}
