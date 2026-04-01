namespace Philiprehberger.DataFaker.Locales;

/// <summary>
/// Registry of available locale data sets.
/// </summary>
internal static class LocaleRegistry
{
    private static readonly Dictionary<string, LocaleData> Locales = new(StringComparer.OrdinalIgnoreCase);

    static LocaleRegistry()
    {
        Register(EnUs.Data);
        Register(DeDe.Data);
        Register(FrFr.Data);
        Register(EsEs.Data);
    }

    /// <summary>
    /// Returns locale data for the given code, falling back to en-US if not found.
    /// </summary>
    internal static LocaleData Get(string code) =>
        Locales.TryGetValue(code, out var data) ? data : Locales["en-US"];

    private static void Register(LocaleData data) => Locales[data.Code] = data;
}
