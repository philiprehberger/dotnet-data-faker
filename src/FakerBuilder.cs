namespace Philiprehberger.DataFaker;

/// <summary>
/// Generates populated instances of a type using convention-based rules.
/// Properties are filled based on their name and type.
/// </summary>
public static class FakerBuilder
{
    /// <summary>
    /// Creates a populated instance of <typeparamref name="T"/> using convention-based data generation.
    /// Public writable properties are assigned values based on their name and type.
    /// </summary>
    /// <typeparam name="T">The type to populate. Must have a parameterless constructor.</typeparam>
    /// <returns>A new instance of <typeparamref name="T"/> with properties populated.</returns>
    public static T Build<T>() where T : new()
    {
        var instance = new T();
        var properties = typeof(T).GetProperties(
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

        foreach (var prop in properties)
        {
            if (!prop.CanWrite) continue;
            var value = GenerateValue(prop.Name, prop.PropertyType);
            if (value is not null) prop.SetValue(instance, value);
        }

        return instance;
    }

    private static object? GenerateValue(string name, Type type)
    {
        var lower = name.ToLowerInvariant();

        if (type == typeof(string))
        {
            if (lower.Contains("email")) return Faker.Email();
            if (lower.Contains("phone")) return Faker.Phone();
            if (lower.Contains("firstname") || lower == "first") return Faker.FirstName();
            if (lower.Contains("lastname") || lower == "last") return Faker.LastName();
            if (lower.Contains("name")) return Faker.Name();
            if (lower.Contains("address") || lower.Contains("street")) return Faker.Address();
            if (lower.Contains("city")) return Faker.City();
            if (lower.Contains("zip") || lower.Contains("postal")) return Faker.ZipCode();
            if (lower.Contains("company") || lower.Contains("organization")) return Faker.Company();
            if (lower.Contains("url") || lower.Contains("website")) return FakerInternet.Url();
            if (lower.Contains("ip")) return FakerInternet.IPv4();
            if (lower.Contains("description") || lower.Contains("bio") || lower.Contains("summary")) return Faker.Sentence();
            return Faker.Lorem(2);
        }

        if (type == typeof(int)) return Faker.Between(1, 1000);
        if (type == typeof(long)) return (long)Faker.Between(1, 100000);
        if (type == typeof(double)) return Faker.Between(1, 1000) + 0.5;
        if (type == typeof(decimal)) return (decimal)Faker.Between(1, 10000) / 100m;
        if (type == typeof(bool)) return Faker.Bool();
        if (type == typeof(DateTime)) return Faker.Between(DateTime.Now.AddYears(-5), DateTime.Now);
        if (type == typeof(Guid)) return Guid.NewGuid();

        return null;
    }
}
