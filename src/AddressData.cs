namespace Philiprehberger.DataFaker;

/// <summary>
/// Internal data pool for street names, cities, and US states.
/// </summary>
internal static class AddressData
{
    /// <summary>
    /// Pool of 30 common street names.
    /// </summary>
    internal static readonly string[] StreetNames =
    [
        "Main", "Oak", "Pine", "Maple", "Cedar",
        "Elm", "Washington", "Lake", "Hill", "Park",
        "Walnut", "Sunset", "Cherry", "Meadow", "Ridge",
        "Spring", "River", "Highland", "Forest", "Valley",
        "Willow", "Birch", "Laurel", "Chestnut", "Magnolia",
        "Poplar", "Spruce", "Hickory", "Cypress", "Dogwood"
    ];

    /// <summary>
    /// Pool of 30 US cities.
    /// </summary>
    internal static readonly string[] Cities =
    [
        "New York", "Los Angeles", "Chicago", "Houston", "Phoenix",
        "Philadelphia", "San Antonio", "San Diego", "Dallas", "Austin",
        "Jacksonville", "San Jose", "Fort Worth", "Columbus", "Charlotte",
        "Indianapolis", "San Francisco", "Seattle", "Denver", "Nashville",
        "Portland", "Oklahoma City", "Las Vegas", "Memphis", "Louisville",
        "Baltimore", "Milwaukee", "Albuquerque", "Tucson", "Sacramento"
    ];

    /// <summary>
    /// Two-letter US state abbreviations.
    /// </summary>
    internal static readonly string[] States =
    [
        "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
        "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
        "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
        "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
        "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
    ];
}
