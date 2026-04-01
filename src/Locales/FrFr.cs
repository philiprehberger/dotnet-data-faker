namespace Philiprehberger.DataFaker.Locales;

/// <summary>
/// French (France) locale data.
/// </summary>
internal static class FrFr
{
    /// <summary>
    /// Gets the fr-FR locale data.
    /// </summary>
    internal static LocaleData Data { get; } = new()
    {
        Code = "fr-FR",
        FirstNames =
        [
            "Jean", "Marie", "Pierre", "Isabelle", "Michel",
            "Nathalie", "Philippe", "Catherine", "Alain", "Sophie",
            "Jacques", "Monique", "Bernard", "Francoise", "Patrick",
            "Sylvie", "Nicolas", "Christine", "Christophe", "Valerie",
            "Laurent", "Sandrine", "Thierry", "Veronique", "Stephane",
            "Celine", "Olivier", "Aurelie", "Guillaume", "Emilie"
        ],
        LastNames =
        [
            "Martin", "Bernard", "Dubois", "Thomas", "Robert",
            "Richard", "Petit", "Durand", "Leroy", "Moreau",
            "Simon", "Laurent", "Lefebvre", "Michel", "Garcia",
            "David", "Bertrand", "Roux", "Vincent", "Fournier",
            "Morel", "Girard", "Andre", "Mercier", "Dupont",
            "Lambert", "Bonnet", "Francois", "Martinez", "Legrand"
        ],
        Cities =
        [
            "Paris", "Marseille", "Lyon", "Toulouse", "Nice",
            "Nantes", "Strasbourg", "Montpellier", "Bordeaux", "Lille",
            "Rennes", "Reims", "Saint-Etienne", "Toulon", "Le Havre",
            "Grenoble", "Dijon", "Angers", "Nimes", "Clermont-Ferrand"
        ],
        PhoneFormat = "+33 # ## ## ## ##"
    };
}
