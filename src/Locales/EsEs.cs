namespace Philiprehberger.DataFaker.Locales;

/// <summary>
/// Spanish (Spain) locale data.
/// </summary>
internal static class EsEs
{
    /// <summary>
    /// Gets the es-ES locale data.
    /// </summary>
    internal static LocaleData Data { get; } = new()
    {
        Code = "es-ES",
        FirstNames =
        [
            "Antonio", "Maria", "Jose", "Carmen", "Manuel",
            "Ana", "Francisco", "Laura", "David", "Marta",
            "Juan", "Cristina", "Carlos", "Sara", "Miguel",
            "Paula", "Rafael", "Elena", "Pedro", "Lucia",
            "Fernando", "Isabel", "Luis", "Raquel", "Pablo",
            "Alba", "Alejandro", "Silvia", "Alberto", "Andrea"
        ],
        LastNames =
        [
            "Garcia", "Rodriguez", "Martinez", "Lopez", "Gonzalez",
            "Hernandez", "Perez", "Sanchez", "Ramirez", "Torres",
            "Flores", "Rivera", "Gomez", "Diaz", "Reyes",
            "Moreno", "Jimenez", "Alvarez", "Romero", "Ruiz",
            "Navarro", "Molina", "Ortega", "Delgado", "Castro",
            "Ortiz", "Marin", "Rubio", "Nunez", "Medina"
        ],
        Cities =
        [
            "Madrid", "Barcelona", "Valencia", "Sevilla", "Zaragoza",
            "Malaga", "Murcia", "Palma", "Las Palmas", "Bilbao",
            "Alicante", "Cordoba", "Valladolid", "Vigo", "Gijon",
            "Granada", "Vitoria", "La Coruna", "Elche", "Oviedo"
        ],
        PhoneFormat = "+34 ### ### ###"
    };
}
