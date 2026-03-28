namespace Philiprehberger.DataFaker;

/// <summary>
/// Static generator for internet-related fake data such as URLs, domains, IPs, and user agents.
/// </summary>
public static class FakerInternet
{
    private static readonly string[] Tlds = ["com", "org", "net", "io", "dev", "co", "app"];

    private static readonly string[] Words =
    [
        "alpha", "beta", "cyber", "data", "edge", "flux", "grid", "hub",
        "info", "jade", "kite", "link", "meta", "nova", "open", "peak",
        "quad", "root", "sync", "tech", "uber", "volt", "wave", "xeno"
    ];

    private static readonly string[] UserAgents =
    [
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 14_4) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.4 Safari/605.1.15",
        "Mozilla/5.0 (X11; Linux x86_64; rv:125.0) Gecko/20100101 Firefox/125.0",
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36 Edg/124.0.0.0",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 17_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.4 Mobile/15E148 Safari/604.1",
        "Mozilla/5.0 (Linux; Android 14; Pixel 8) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Mobile Safari/537.36"
    ];

    /// <summary>
    /// Generates a random URL with http or https scheme.
    /// </summary>
    /// <returns>A random URL string.</returns>
    public static string Url()
    {
        var scheme = Faker.Bool() ? "https" : "http";
        return $"{scheme}://{DomainName()}/{Faker.Pick(Words)}/{Faker.Pick(Words)}";
    }

    /// <summary>
    /// Generates a random domain name.
    /// </summary>
    /// <returns>A domain name string.</returns>
    public static string DomainName()
    {
        return $"{Faker.Pick(Words)}-{Faker.Pick(Words)}.{Faker.Pick(Tlds)}";
    }

    /// <summary>
    /// Generates a random valid IPv4 address.
    /// </summary>
    /// <returns>An IPv4 address string in dotted-decimal notation.</returns>
    public static string IPv4()
    {
        return $"{Faker.Between(1, 254)}.{Faker.Between(0, 255)}.{Faker.Between(0, 255)}.{Faker.Between(1, 254)}";
    }

    /// <summary>
    /// Generates a random IPv6 address.
    /// </summary>
    /// <returns>An IPv6 address string in colon-separated hexadecimal notation.</returns>
    public static string IPv6()
    {
        var groups = new string[8];
        for (var i = 0; i < 8; i++)
        {
            groups[i] = Faker.Between(0, 65535).ToString("x4");
        }
        return string.Join(":", groups);
    }

    /// <summary>
    /// Generates a random MAC address.
    /// </summary>
    /// <returns>A MAC address string in colon-separated hexadecimal notation.</returns>
    public static string MacAddress()
    {
        var octets = new string[6];
        for (var i = 0; i < 6; i++)
        {
            octets[i] = Faker.Between(0, 255).ToString("x2");
        }
        return string.Join(":", octets);
    }

    /// <summary>
    /// Returns a random realistic browser user agent string.
    /// </summary>
    /// <returns>A user agent string.</returns>
    public static string UserAgent() => Faker.Pick(UserAgents);

    /// <summary>
    /// Generates a random URL-friendly slug.
    /// </summary>
    /// <returns>A slug string with words separated by hyphens.</returns>
    public static string Slug()
    {
        var count = Faker.Between(2, 4);
        var parts = new string[count];
        for (var i = 0; i < count; i++)
        {
            parts[i] = Faker.Pick(Words);
        }
        return string.Join("-", parts);
    }
}
