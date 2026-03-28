namespace Philiprehberger.DataFaker;

/// <summary>
/// Static test data generator for producing fake names, emails, addresses,
/// phone numbers, dates, and lorem ipsum text.
/// </summary>
public static class Faker
{
    [ThreadStatic]
    private static Random? _random;

    private static Random RandomInstance => _random ??= new Random();

    /// <summary>
    /// Generates a random full name (first + last).
    /// </summary>
    /// <returns>A full name string.</returns>
    public static string Name() => $"{FirstName()} {LastName()}";

    /// <summary>
    /// Generates a random first name.
    /// </summary>
    /// <returns>A first name string.</returns>
    public static string FirstName() => Pick(NameData.FirstNames);

    /// <summary>
    /// Generates a random last name.
    /// </summary>
    /// <returns>A last name string.</returns>
    public static string LastName() => Pick(NameData.LastNames);

    /// <summary>
    /// Generates a random email address.
    /// </summary>
    /// <returns>An email address string.</returns>
    public static string Email()
    {
        var first = FirstName().ToLowerInvariant();
        var last = LastName().ToLowerInvariant();
        var domains = new[] { "example.com", "test.org", "demo.net", "sample.io" };
        return $"{first}.{last}@{Pick(domains)}";
    }

    /// <summary>
    /// Generates a random US phone number in (XXX) XXX-XXXX format.
    /// </summary>
    /// <returns>A formatted phone number string.</returns>
    public static string Phone()
    {
        var area = Between(200, 999);
        var prefix = Between(200, 999);
        var line = Between(1000, 9999);
        return $"({area}) {prefix}-{line}";
    }

    /// <summary>
    /// Generates a random US street address.
    /// </summary>
    /// <returns>A street address string.</returns>
    public static string Address()
    {
        var number = Between(100, 9999);
        var street = Pick(AddressData.StreetNames);
        var suffixes = new[] { "St", "Ave", "Blvd", "Dr", "Ln", "Rd", "Way", "Ct" };
        return $"{number} {street} {Pick(suffixes)}";
    }

    /// <summary>
    /// Generates a random US city name.
    /// </summary>
    /// <returns>A city name string.</returns>
    public static string City() => Pick(AddressData.Cities);

    /// <summary>
    /// Generates a random 5-digit US zip code.
    /// </summary>
    /// <returns>A zip code string.</returns>
    public static string ZipCode() => Between(10000, 99999).ToString();

    /// <summary>
    /// Generates a random company name.
    /// </summary>
    /// <returns>A company name string.</returns>
    public static string Company()
    {
        var suffixes = new[] { "Inc", "LLC", "Corp", "Group", "Solutions", "Technologies", "Systems", "Labs" };
        return $"{LastName()} {Pick(suffixes)}";
    }

    /// <summary>
    /// Generates random lorem ipsum words.
    /// </summary>
    /// <param name="wordCount">Number of words to generate.</param>
    /// <returns>A string of lorem ipsum words.</returns>
    public static string Lorem(int wordCount = 5)
    {
        var words = new string[wordCount];
        for (var i = 0; i < wordCount; i++)
        {
            words[i] = Pick(LoremData.Words);
        }
        return string.Join(" ", words);
    }

    /// <summary>
    /// Generates a random lorem ipsum sentence (5-12 words, capitalized, with period).
    /// </summary>
    /// <returns>A sentence string.</returns>
    public static string Sentence()
    {
        var wordCount = Between(5, 12);
        var text = Lorem(wordCount);
        return char.ToUpperInvariant(text[0]) + text[1..] + ".";
    }

    /// <summary>
    /// Generates a random lorem ipsum paragraph (3-6 sentences).
    /// </summary>
    /// <returns>A paragraph string.</returns>
    public static string Paragraph()
    {
        var sentenceCount = Between(3, 6);
        var sentences = new string[sentenceCount];
        for (var i = 0; i < sentenceCount; i++)
        {
            sentences[i] = Sentence();
        }
        return string.Join(" ", sentences);
    }

    /// <summary>
    /// Generates a random integer between <paramref name="min"/> and <paramref name="max"/> (inclusive).
    /// </summary>
    /// <param name="min">The inclusive lower bound.</param>
    /// <param name="max">The inclusive upper bound.</param>
    /// <returns>A random integer in the specified range.</returns>
    public static int Between(int min, int max) => RandomInstance.Next(min, max + 1);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="min">The inclusive lower bound.</param>
    /// <param name="max">The inclusive upper bound.</param>
    /// <returns>A random <see cref="DateTime"/> in the specified range.</returns>
    public static DateTime Between(DateTime min, DateTime max)
    {
        var range = max.Ticks - min.Ticks;
        var randomTicks = (long)(RandomInstance.NextDouble() * range);
        return new DateTime(min.Ticks + randomTicks);
    }

    /// <summary>
    /// Generates a random boolean value.
    /// </summary>
    /// <returns><c>true</c> or <c>false</c> with equal probability.</returns>
    public static bool Bool() => RandomInstance.Next(2) == 1;

    /// <summary>
    /// Picks a random element from the given list.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="items">The list to pick from.</param>
    /// <returns>A randomly selected element.</returns>
    public static T Pick<T>(IList<T> items) => items[RandomInstance.Next(items.Count)];

    /// <summary>
    /// Picks a random element from the given list using weighted probabilities.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="items">A list of items paired with their relative weights.</param>
    /// <returns>A randomly selected element based on the weights.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="items"/> is empty or total weight is zero.</exception>
    public static T PickWeighted<T>(IReadOnlyList<(T item, double weight)> items)
    {
        if (items.Count == 0)
        {
            throw new ArgumentException("Items list must not be empty.", nameof(items));
        }

        var totalWeight = 0.0;
        for (var i = 0; i < items.Count; i++)
        {
            totalWeight += items[i].weight;
        }

        if (totalWeight <= 0)
        {
            throw new ArgumentException("Total weight must be greater than zero.", nameof(items));
        }

        var threshold = RandomInstance.NextDouble() * totalWeight;
        var cumulative = 0.0;
        for (var i = 0; i < items.Count; i++)
        {
            cumulative += items[i].weight;
            if (threshold <= cumulative)
            {
                return items[i].item;
            }
        }

        return items[^1].item;
    }

    /// <summary>
    /// Generates a list of fake items using the provided generator function.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="count">The exact number of items to generate.</param>
    /// <param name="generator">A function that produces a single fake item.</param>
    /// <returns>A list of generated items.</returns>
    public static List<T> List<T>(int count, Func<T> generator)
    {
        var result = new List<T>(count);
        for (var i = 0; i < count; i++)
        {
            result.Add(generator());
        }
        return result;
    }

    /// <summary>
    /// Generates a list of fake items with a random count between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="min">The inclusive minimum number of items.</param>
    /// <param name="max">The inclusive maximum number of items.</param>
    /// <param name="generator">A function that produces a single fake item.</param>
    /// <returns>A list of generated items.</returns>
    public static List<T> List<T>(int min, int max, Func<T> generator)
    {
        var count = Between(min, max);
        return List(count, generator);
    }

    /// <summary>
    /// Creates a seeded <see cref="FakerInstance"/> for reproducible data generation.
    /// </summary>
    /// <param name="seed">The seed value for deterministic output.</param>
    /// <returns>A new <see cref="FakerInstance"/> initialized with the given seed.</returns>
    public static FakerInstance WithSeed(int seed) => new(seed);

    internal static T Pick<T>(T[] items) => items[RandomInstance.Next(items.Length)];
}
