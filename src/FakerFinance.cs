namespace Philiprehberger.DataFaker;

/// <summary>
/// Static generator for finance-related fake data such as credit cards, IBANs, and currency codes.
/// </summary>
public static class FakerFinance
{
    private static readonly string[] CurrencyCodes =
    [
        "USD", "EUR", "GBP", "JPY", "AUD", "CAD", "CHF", "CNY", "SEK", "NZD",
        "MXN", "SGD", "HKD", "NOK", "KRW", "TRY", "INR", "RUB", "BRL", "ZAR",
        "DKK", "PLN", "TWD", "THB", "IDR"
    ];

    private static readonly string[] BicBanks =
    [
        "DEUT", "COBA", "COMM", "HSBC", "BNPA", "CITI", "BARCG", "UBSW",
        "NWBK", "RABO", "INGB", "ABNA", "SCBL", "LOYD", "BBVA"
    ];

    private static readonly string[] BicCountries =
    [
        "DE", "GB", "FR", "US", "CH", "NL", "AT", "ES", "IT", "BE"
    ];

    /// <summary>
    /// Generates a random credit card number that passes the Luhn check.
    /// Uses Visa (4) or Mastercard (51-55) prefixes.
    /// </summary>
    /// <returns>A 16-digit credit card number string.</returns>
    public static string CreditCardNumber()
    {
        var prefix = Faker.Bool()
            ? "4" + Faker.Between(100, 999).ToString()
            : "5" + Faker.Between(1, 5).ToString() + Faker.Between(10, 99).ToString();

        var partial = prefix;
        while (partial.Length < 15)
        {
            partial += Faker.Between(0, 9).ToString();
        }

        var checkDigit = CalculateLuhnCheckDigit(partial);
        return partial + checkDigit.ToString();
    }

    /// <summary>
    /// Generates a realistic IBAN for the specified country code.
    /// </summary>
    /// <param name="countryCode">ISO 3166-1 alpha-2 country code (default "DE").</param>
    /// <returns>An IBAN string.</returns>
    public static string Iban(string countryCode = "DE")
    {
        var bban = countryCode.ToUpperInvariant() switch
        {
            "DE" => GenerateDigits(8) + GenerateDigits(10), // BLZ + account
            "GB" => GenerateUpperLetters(4) + GenerateDigits(6) + GenerateDigits(8), // sort code + account
            "FR" => GenerateDigits(5) + GenerateDigits(5) + GenerateDigits(11) + GenerateDigits(2), // bank + branch + account + key
            _ => GenerateDigits(8) + GenerateDigits(10) // fallback to DE format
        };

        var checkDigits = Faker.Between(10, 98).ToString("D2");
        return countryCode.ToUpperInvariant() + checkDigits + bban;
    }

    /// <summary>
    /// Generates a random BIC/SWIFT code.
    /// </summary>
    /// <returns>An 8 or 11 character BIC/SWIFT code.</returns>
    public static string BicSwift()
    {
        var bank = Faker.Pick(BicBanks);
        if (bank.Length > 4) bank = bank[..4];
        var country = Faker.Pick(BicCountries);
        var location = GenerateUpperLetters(2);

        return Faker.Bool()
            ? $"{bank}{country}{location}"
            : $"{bank}{country}{location}{GenerateUpperLetters(3)}";
    }

    /// <summary>
    /// Returns a random ISO 4217 currency code.
    /// </summary>
    /// <returns>A three-letter currency code.</returns>
    public static string CurrencyCode() => Faker.Pick(CurrencyCodes);

    /// <summary>
    /// Generates a random monetary amount within the specified range.
    /// </summary>
    /// <param name="min">The inclusive minimum amount.</param>
    /// <param name="max">The inclusive maximum amount.</param>
    /// <param name="decimals">The number of decimal places (default 2).</param>
    /// <returns>A decimal amount rounded to the specified number of decimal places.</returns>
    public static decimal Amount(decimal min, decimal max, int decimals = 2)
    {
        var range = max - min;
        var randomFraction = (decimal)new Random(Faker.Between(0, int.MaxValue - 1)).NextDouble();
        var value = min + range * randomFraction;
        return Math.Round(value, decimals);
    }

    private static int CalculateLuhnCheckDigit(string number)
    {
        var sum = 0;
        var alternate = true;
        for (var i = number.Length - 1; i >= 0; i--)
        {
            var digit = number[i] - '0';
            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }
            sum += digit;
            alternate = !alternate;
        }
        return (10 - sum % 10) % 10;
    }

    private static string GenerateDigits(int count)
    {
        var chars = new char[count];
        for (var i = 0; i < count; i++)
        {
            chars[i] = (char)('0' + Faker.Between(0, 9));
        }
        return new string(chars);
    }

    private static string GenerateUpperLetters(int count)
    {
        var chars = new char[count];
        for (var i = 0; i < count; i++)
        {
            chars[i] = (char)('A' + Faker.Between(0, 25));
        }
        return new string(chars);
    }
}
