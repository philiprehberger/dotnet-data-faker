# Philiprehberger.DataFaker

[![CI](https://github.com/philiprehberger/dotnet-data-faker/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-data-faker/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.DataFaker.svg)](https://www.nuget.org/packages/Philiprehberger.DataFaker)
[![Last updated](https://img.shields.io/github/last-commit/philiprehberger/dotnet-data-faker)](https://github.com/philiprehberger/dotnet-data-faker/commits/main)

Lightweight test data generator with locale support, structured builders, and UUID generation.

## Installation

```bash
dotnet add package Philiprehberger.DataFaker
```

## Usage

```csharp
using Philiprehberger.DataFaker;

var name = Faker.Name();        // "Mary Johnson"
var email = Faker.Email();      // "james.smith@example.com"
var phone = Faker.Phone();      // "(555) 867-5309"
var address = Faker.Address();  // "742 Oak Ave"
```

### Internet Data

```csharp
using Philiprehberger.DataFaker;

var url = FakerInternet.Url();           // "https://alpha-tech.io/data/flux"
var domain = FakerInternet.DomainName(); // "cyber-wave.dev"
var ip4 = FakerInternet.IPv4();          // "192.168.45.12"
var ip6 = FakerInternet.IPv6();          // "2a01:0db8:85a3:0000:0000:8a2e:0370:7334"
var mac = FakerInternet.MacAddress();    // "a4:5e:60:b3:21:ff"
var ua = FakerInternet.UserAgent();      // "Mozilla/5.0 (Windows NT 10.0; ...)"
var slug = FakerInternet.Slug();         // "meta-sync-nova"
```

### Finance Data

```csharp
using Philiprehberger.DataFaker;

var cc = FakerFinance.CreditCardNumber();  // "4532015112830366" (valid Luhn)
var iban = FakerFinance.Iban();            // "DE89370400440532013000"
var bic = FakerFinance.BicSwift();         // "DEUTDEFF"
var currency = FakerFinance.CurrencyCode(); // "EUR"
var amount = FakerFinance.Amount(10m, 500m); // 247.83m
```

### Weighted Selection

```csharp
using Philiprehberger.DataFaker;

var items = new List<(string item, double weight)>
{
    ("common", 10.0),
    ("uncommon", 3.0),
    ("rare", 0.5)
};

var picked = Faker.PickWeighted(items); // "common" (most likely)
```

### Collection Helpers

```csharp
using Philiprehberger.DataFaker;

var names = Faker.List(5, () => Faker.Name());
// ["Mary Johnson", "Robert Garcia", "Jennifer Wilson", ...]

var scores = Faker.List(3, 8, () => Faker.Between(1, 100));
// [42, 87, 15, 63, 91] (random count between 3 and 8)
```

### Locale Support

```csharp
using Philiprehberger.DataFaker;

var de = Faker.WithLocale("de-DE");
var name = de.Name();     // "Hans Mueller"
var city = de.City();     // "Berlin"
var phone = de.Phone();   // "+49 172 9384756"
var email = de.Email();   // "hans.mueller@example.com"

var fr = Faker.WithLocale("fr-FR");
var frName = fr.Name();   // "Jean Martin"

var es = Faker.WithLocale("es-ES");
var esCity = es.City();   // "Madrid"
```

### UUID Generation

```csharp
using Philiprehberger.DataFaker;

var uuid = Faker.Uuid();            // "a3b8f042-1c7e-4d9a-b5e6-8f2c3a7d1e09"
var seqId = Faker.UuidSequential();  // time-sortable UUID v7-style
```

### Object Builder

```csharp
using Philiprehberger.DataFaker;

public class User
{
    public string FirstName { get; set; } = "";
    public string Email { get; set; } = "";
    public int Age { get; set; }
    public bool IsActive { get; set; }
}

var user = FakerBuilder.Build<User>();
// user.FirstName = "Mary"
// user.Email = "james.smith@example.com"
// user.Age = 427
// user.IsActive = true
```

### Seeded Reproducibility

```csharp
using Philiprehberger.DataFaker;

var faker = Faker.WithSeed(42);

// Same seed always produces the same sequence
var name1 = faker.Name();   // deterministic
var name2 = faker.Name();   // deterministic
var email = faker.Email();  // deterministic
```

## API

### `Faker` (static)

| Method | Description |
|--------|-------------|
| `Name()` | Random full name (first + last) |
| `FirstName()` | Random first name |
| `LastName()` | Random last name |
| `Email()` | Random email address |
| `Phone()` | Random US phone number |
| `Address()` | Random US street address |
| `City()` | Random US city name |
| `ZipCode()` | Random 5-digit US zip code |
| `Company()` | Random company name |
| `Lorem(wordCount)` | Random lorem ipsum words (default 5) |
| `Sentence()` | Random lorem ipsum sentence |
| `Paragraph()` | Random lorem ipsum paragraph |
| `Between(min, max)` | Random int in range (inclusive) |
| `Between(min, max)` | Random DateTime in range |
| `Bool()` | Random boolean |
| `Pick<T>(items)` | Random element from a list |
| `PickWeighted<T>(items)` | Weighted random selection |
| `List<T>(count, generator)` | Generate a list of fake items |
| `List<T>(min, max, generator)` | Generate a list with random count |
| `Uuid()` | Random UUID v4 |
| `UuidSequential()` | Time-sortable sequential UUID |
| `WithLocale(locale)` | Create a locale-specific `LocaleFaker` |
| `WithSeed(seed)` | Create a seeded `FakerInstance` |

### `LocaleFaker`

| Method | Description |
|--------|-------------|
| `Name()` | Locale-specific full name |
| `FirstName()` | Locale-specific first name |
| `LastName()` | Locale-specific last name |
| `City()` | Locale-specific city name |
| `Phone()` | Locale-specific formatted phone number |
| `Email()` | Email using locale-specific names |

### `FakerBuilder` (static)

| Method | Description |
|--------|-------------|
| `Build<T>()` | Populate an object using convention-based rules |

### `FakerInternet` (static)

| Method | Description |
|--------|-------------|
| `Url()` | Random HTTP/HTTPS URL |
| `DomainName()` | Random domain name |
| `IPv4()` | Random valid IPv4 address |
| `IPv6()` | Random IPv6 address |
| `MacAddress()` | Random MAC address |
| `UserAgent()` | Random realistic browser user agent |
| `Slug()` | Random URL-friendly slug |

### `FakerFinance` (static)

| Method | Description |
|--------|-------------|
| `CreditCardNumber()` | Valid Luhn credit card (Visa/MC) |
| `Iban(countryCode)` | Realistic IBAN (default "DE") |
| `BicSwift()` | Random BIC/SWIFT code |
| `CurrencyCode()` | Random ISO 4217 currency code |
| `Amount(min, max, decimals)` | Random monetary amount |

### `FakerInstance`

Same methods as `Faker` (except `WithSeed`, `WithLocale`, `PickWeighted`, `List`), plus `Uuid()` and `UuidSequential()`, but instance-based with a seeded `Random` for deterministic output.

## Development

```bash
dotnet build src/Philiprehberger.DataFaker.csproj --configuration Release
```

## Support

If you find this project useful:

⭐ [Star the repo](https://github.com/philiprehberger/dotnet-data-faker)

🐛 [Report issues](https://github.com/philiprehberger/dotnet-data-faker/issues?q=is%3Aissue+is%3Aopen+label%3Abug)

💡 [Suggest features](https://github.com/philiprehberger/dotnet-data-faker/issues?q=is%3Aissue+is%3Aopen+label%3Aenhancement)

❤️ [Sponsor development](https://github.com/sponsors/philiprehberger)

🌐 [All Open Source Projects](https://philiprehberger.com/open-source-packages)

💻 [GitHub Profile](https://github.com/philiprehberger)

🔗 [LinkedIn Profile](https://www.linkedin.com/in/philiprehberger)

## License

[MIT](LICENSE)
