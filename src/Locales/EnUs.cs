namespace Philiprehberger.DataFaker.Locales;

/// <summary>
/// English (United States) locale data.
/// </summary>
internal static class EnUs
{
    /// <summary>
    /// Gets the en-US locale data.
    /// </summary>
    internal static LocaleData Data { get; } = new()
    {
        Code = "en-US",
        FirstNames =
        [
            "James", "Mary", "Robert", "Patricia", "John",
            "Jennifer", "Michael", "Linda", "David", "Elizabeth",
            "William", "Barbara", "Richard", "Susan", "Joseph",
            "Jessica", "Thomas", "Sarah", "Charles", "Karen",
            "Christopher", "Lisa", "Daniel", "Nancy", "Matthew",
            "Betty", "Anthony", "Margaret", "Mark", "Sandra"
        ],
        LastNames =
        [
            "Smith", "Johnson", "Williams", "Brown", "Jones",
            "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
            "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson",
            "Thomas", "Taylor", "Moore", "Jackson", "Martin",
            "Lee", "Perez", "Thompson", "White", "Harris",
            "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson"
        ],
        Cities =
        [
            "New York", "Los Angeles", "Chicago", "Houston", "Phoenix",
            "Philadelphia", "San Antonio", "San Diego", "Dallas", "Austin",
            "Jacksonville", "San Jose", "Fort Worth", "Columbus", "Charlotte",
            "Indianapolis", "San Francisco", "Seattle", "Denver", "Nashville"
        ],
        PhoneFormat = "(###) ###-####"
    };
}
