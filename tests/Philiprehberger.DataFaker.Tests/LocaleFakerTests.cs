using Xunit;
using Philiprehberger.DataFaker;

namespace Philiprehberger.DataFaker.Tests;

public class LocaleFakerTests
{
    [Fact]
    public void WithLocale_DeDe_ReturnsNonEmptyName()
    {
        var faker = Faker.WithLocale("de-DE");
        var name = faker.Name();
        Assert.False(string.IsNullOrWhiteSpace(name));
        Assert.Contains(" ", name);
    }

    [Fact]
    public void WithLocale_FrFr_ReturnsNonEmptyCity()
    {
        var faker = Faker.WithLocale("fr-FR");
        var city = faker.City();
        Assert.False(string.IsNullOrWhiteSpace(city));
    }

    [Fact]
    public void WithLocale_EsEs_ReturnsNonEmptyPhone()
    {
        var faker = Faker.WithLocale("es-ES");
        var phone = faker.Phone();
        Assert.False(string.IsNullOrWhiteSpace(phone));
        Assert.StartsWith("+34", phone);
    }

    [Fact]
    public void WithLocale_UnknownLocale_FallsBackToEnUs()
    {
        var faker = Faker.WithLocale("xx-XX");
        var name = faker.Name();
        Assert.False(string.IsNullOrWhiteSpace(name));
    }

    [Fact]
    public void WithLocale_Email_ContainsAtSign()
    {
        var faker = Faker.WithLocale("de-DE");
        var email = faker.Email();
        Assert.Contains("@", email);
        Assert.EndsWith("@example.com", email);
    }

    [Fact]
    public void WithLocale_DeDe_PhoneStartsWithCountryCode()
    {
        var faker = Faker.WithLocale("de-DE");
        var phone = faker.Phone();
        Assert.StartsWith("+49", phone);
    }

    [Fact]
    public void Uuid_ReturnsValidFormat()
    {
        var uuid = Faker.Uuid();
        Assert.Equal(36, uuid.Length);
        Assert.Contains("-", uuid);
        Assert.True(Guid.TryParse(uuid, out _));
    }

    [Fact]
    public void UuidSequential_ReturnsValidFormat()
    {
        var uuid = Faker.UuidSequential();
        Assert.Equal(36, uuid.Length);
        Assert.Contains("-", uuid);
        Assert.True(Guid.TryParse(uuid, out _));
    }

    [Fact]
    public void UuidSequential_IsTimeSortable()
    {
        var uuid1 = Faker.UuidSequential();
        var uuid2 = Faker.UuidSequential();
        Assert.True(string.Compare(uuid1, uuid2, StringComparison.Ordinal) <= 0,
            $"Expected {uuid1} <= {uuid2} for time-sortable UUIDs.");
    }

    [Fact]
    public void FakerInstance_Uuid_ReturnsValidFormat()
    {
        var faker = Faker.WithSeed(42);
        var uuid = faker.Uuid();
        Assert.Equal(36, uuid.Length);
        Assert.True(Guid.TryParse(uuid, out _));
    }

    [Fact]
    public void FakerInstance_UuidSequential_ReturnsValidFormat()
    {
        var faker = Faker.WithSeed(42);
        var uuid = faker.UuidSequential();
        Assert.Equal(36, uuid.Length);
        Assert.True(Guid.TryParse(uuid, out _));
    }
}
