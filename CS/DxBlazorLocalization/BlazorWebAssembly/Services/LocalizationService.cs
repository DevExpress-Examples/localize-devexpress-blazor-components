using System.Globalization;
using DevExpress.Blazor.Localization;

namespace BlazorWebAssembly.Services {
    public class LocalizationService : DxLocalizationService, IDxLocalizationService {
        string? IDxLocalizationService.GetString(string key) {
            return CultureInfo.CurrentUICulture.Name == "it-IT" ?
                Resources.LocalizationRes.ResourceManager.GetString(key) :
                base.GetString(key);
        }
    }
}
