namespace Philiprehberger.DataFaker;

/// <summary>
/// Seeded test data generator for reproducible fake data.
/// Create via <see cref="Faker.WithSeed(int)"/>.
/// </summary>
public sealed class FakerInstance
{
    private readonly Random _random;

    /// <summary>
    /// Initializes a new <see cref="FakerInstance"/> with the specified seed.
    /// </summary>
    /// <param name="seed">The seed value for deterministic output.</param>
    internal FakerInstance(int seed)
    {
        _random = new Random(seed);
    }

    /// <summary>
    /// Generates a random full name (first + last).
    /// </summary>
    /// <returns>A full name string.</returns>
    public string Name() => $"{FirstName()} {LastName()}";

    /// <summary>
    /// Generates a random first name.
    /// </summary>
    /// <returns>A first name string.</returns>
    public string FirstName() => Pick(NameData.FirstNames);

    /// <summary>
    /// Generates a random last name.
    /// </summary>
    /// <returns>A last name string.</returns>
    public string LastName() => Pick(NameData.LastNames);

    /// <summary>
    /// Generates a random email address.
    /// </summary>
    /// <returns>An email address string.</returns>
    public string Email()
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
    public string Phone()
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
    public string Address()
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
    public string City() => Pick(AddressData.Cities);

    /// <summary>
    /// Generates a random 5-digit US zip code.
    /// </summary>
    /// <returns>A zip code string.</returns>
    public string ZipCode() => Between(10000, 99999).ToString();

    /// <summary>
    /// Generates a random company name.
    /// </summary>
    /// <returns>A company name string.</returns>
    public string Company()
    {
        var suffixes = new[] { "Inc", "LLC", "Corp", "Group", "Solutions", "Technologies", "Systems", "Labs" };
        return $"{LastName()} {Pick(suffixes)}";
    }

    /// <summary>
    /// Generates random lorem ipsum words.
    /// </summary>
    /// <param name="wordCount">Number of words to generate.</param>
    /// <returns>A string of lorem ipsum words.</returns>
    public string Lorem(int wordCount = 5)
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
    public string Sentence()
    {
        var wordCount = Between(5, 12);
        var text = Lorem(wordCount);
        return char.ToUpperInvariant(text[0]) + text[1..] + ".";
    }

    /// <summary>
    /// Generates a random lorem ipsum paragraph (3-6 sentences).
    /// </summary>
    /// <returns>A paragraph string.</returns>
    public string Paragraph()
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
    public int Between(int min, int max) => _random.Next(min, max + 1);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="min">The inclusive lower bound.</param>
    /// <param name="max">The inclusive upper bound.</param>
    /// <returns>A random <see cref="DateTime"/> in the specified range.</returns>
    public DateTime Between(DateTime min, DateTime max)
    {
        var range = max.Ticks - min.Ticks;
        var randomTicks = (long)(_random.NextDouble() * range);
        return new DateTime(min.Ticks + randomTicks);
    }

    /// <summary>
    /// Generates a random boolean value.
    /// </summary>
    /// <returns><c>true</c> or <c>false</c> with equal probability.</returns>
    public bool Bool() => _random.Next(2) == 1;

    /// <summary>
    /// Picks a random element from the given list.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="items">The list to pick from.</param>
    /// <returns>A randomly selected element.</returns>
    public T Pick<T>(IList<T> items) => items[_random.Next(items.Count)];

    /// <summary>
    /// Generates a random UUID v4.
    /// </summary>
    /// <returns>A UUID v4 string.</returns>
    public string Uuid() => Guid.NewGuid().ToString();

    /// <summary>
    /// Generates a time-sortable sequential UUID using the current timestamp.
    /// </summary>
    /// <returns>A UUID v7-style string with timestamp prefix for sortability.</returns>
    public string UuidSequential()
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var bytes = new byte[16];
        var timeBytes = BitConverter.GetBytes(timestamp);
        if (BitConverter.IsLittleEndian) Array.Reverse(timeBytes);
        // First 6 bytes = timestamp (for sortability)
        Buffer.BlockCopy(timeBytes, 2, bytes, 0, 6);
        // Remaining 10 bytes = random
        _random.NextBytes(bytes.AsSpan(6));
        // Set version 7 bits
        bytes[6] = (byte)((bytes[6] & 0x0F) | 0x70);
        bytes[8] = (byte)((bytes[8] & 0x3F) | 0x80);
        return new Guid(bytes).ToString();
    }

    private T Pick<T>(T[] items) => items[_random.Next(items.Length)];
}
