namespace Philiprehberger.DataFaker.Locales;

/// <summary>
/// German (Germany) locale data.
/// </summary>
internal static class DeDe
{
    /// <summary>
    /// Gets the de-DE locale data.
    /// </summary>
    internal static LocaleData Data { get; } = new()
    {
        Code = "de-DE",
        FirstNames =
        [
            "Hans", "Anna", "Klaus", "Maria", "Wolfgang",
            "Ursula", "Dieter", "Helga", "Juergen", "Monika",
            "Stefan", "Petra", "Thomas", "Sabine", "Andreas",
            "Gabriele", "Michael", "Andrea", "Peter", "Brigitte",
            "Frank", "Claudia", "Bernd", "Susanne", "Werner",
            "Heike", "Matthias", "Martina", "Rainer", "Karin"
        ],
        LastNames =
        [
            "Mueller", "Schmidt", "Schneider", "Fischer", "Weber",
            "Meyer", "Wagner", "Becker", "Schulz", "Hoffmann",
            "Schaefer", "Koch", "Bauer", "Richter", "Klein",
            "Wolf", "Schroeder", "Neumann", "Schwarz", "Zimmermann",
            "Braun", "Krueger", "Hofmann", "Hartmann", "Lange",
            "Schmitt", "Werner", "Schmitz", "Krause", "Meier"
        ],
        Cities =
        [
            "Berlin", "Hamburg", "Muenchen", "Koeln", "Frankfurt",
            "Stuttgart", "Duesseldorf", "Leipzig", "Dortmund", "Essen",
            "Bremen", "Dresden", "Hannover", "Nuernberg", "Duisburg",
            "Bochum", "Wuppertal", "Bielefeld", "Bonn", "Mannheim"
        ],
        PhoneFormat = "+49 ### #######"
    };
}
