using System.Globalization;

namespace BlazorWebAssembly.Services {
    public class SupportedCultures {
        public static CultureInfo[] Cultures { get; } = new CultureInfo[] {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("es-ES"),
            new CultureInfo("ja-JA"),
            new CultureInfo("it-IT"),
        };
    }
}
