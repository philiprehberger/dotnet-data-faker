namespace Philiprehberger.DataFaker;

/// <summary>
/// Generates fake data using locale-specific names, cities, and phone formats.
/// Create via <see cref="Faker.WithLocale(string)"/>.
/// </summary>
public sealed class LocaleFaker
{
    private readonly Locales.LocaleData _data;

    /// <summary>
    /// Initializes a new <see cref="LocaleFaker"/> for the specified locale code.
    /// </summary>
    /// <param name="locale">The locale code (e.g. "de-DE", "fr-FR").</param>
    internal LocaleFaker(string locale)
    {
        _data = Locales.LocaleRegistry.Get(locale);
    }

    /// <summary>
    /// Generates a random first name for the configured locale.
    /// </summary>
    /// <returns>A first name string.</returns>
    public string FirstName() => Faker.Pick(_data.FirstNames);

    /// <summary>
    /// Generates a random last name for the configured locale.
    /// </summary>
    /// <returns>A last name string.</returns>
    public string LastName() => Faker.Pick(_data.LastNames);

    /// <summary>
    /// Generates a random full name (first + last) for the configured locale.
    /// </summary>
    /// <returns>A full name string.</returns>
    public string Name() => $"{FirstName()} {LastName()}";

    /// <summary>
    /// Generates a random city name for the configured locale.
    /// </summary>
    /// <returns>A city name string.</returns>
    public string City() => Faker.Pick(_data.Cities);

    /// <summary>
    /// Generates a random phone number using the locale-specific format.
    /// </summary>
    /// <returns>A formatted phone number string.</returns>
    public string Phone()
    {
        var chars = _data.PhoneFormat.ToCharArray();
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '#')
            {
                chars[i] = (char)('0' + Faker.Between(0, 9));
            }
        }
        return new string(chars);
    }

    /// <summary>
    /// Generates a random email address using locale-specific names.
    /// </summary>
    /// <returns>An email address string.</returns>
    public string Email() => $"{FirstName().ToLowerInvariant()}.{LastName().ToLowerInvariant()}@example.com";
}
