# Philiprehberger.DataFaker

[![CI](https://github.com/philiprehberger/dotnet-data-faker/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-data-faker/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.DataFaker.svg)](https://www.nuget.org/packages/Philiprehberger.DataFaker)
[![License](https://img.shields.io/github/license/philiprehberger/dotnet-data-faker)](LICENSE)
[![Sponsor](https://img.shields.io/badge/sponsor-GitHub%20Sponsors-ec6cb9)](https://github.com/sponsors/philiprehberger)

Lightweight test data generator for names, emails, addresses, phones, dates, and lorem ipsum with seeded reproducibility.

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

### Quick Generation

```csharp
using Philiprehberger.DataFaker;

var city = Faker.City();          // "Seattle"
var zip = Faker.ZipCode();        // "90210"
var company = Faker.Company();    // "Wilson Technologies"
var sentence = Faker.Sentence();  // "Lorem ipsum dolor sit amet consectetur."
var flag = Faker.Bool();          // true
var age = Faker.Between(18, 65); // 34
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

### Bulk Generation

```csharp
using Philiprehberger.DataFaker;

var faker = Faker.WithSeed(123);

var users = Enumerable.Range(0, 100).Select(_ => new
{
    Name = faker.Name(),
    Email = faker.Email(),
    Phone = faker.Phone(),
    City = faker.City(),
    Bio = faker.Paragraph()
}).ToList();
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
| `WithSeed(seed)` | Create a seeded `FakerInstance` |

### `FakerInstance`

Same methods as `Faker` (except `WithSeed`), but instance-based with a seeded `Random` for deterministic output.

## Development

```bash
dotnet build src/Philiprehberger.DataFaker.csproj --configuration Release
```

## License

[MIT](LICENSE)
