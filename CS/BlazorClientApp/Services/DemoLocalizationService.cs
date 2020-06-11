using DevExpress.Blazor.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace BlazorClientApp.Services
{
    public class DemoLocalizationService : DxLocalizationService, IDxLocalizationService
    {
        readonly Dictionary<string, ResourceManager> resources = new Dictionary<string, ResourceManager>();
        string IDxLocalizationService.GetString(string key) {
            var culture = CultureInfo.CurrentUICulture.Name;
            switch(culture) {
                case "it-IT":
                    if(!resources.TryGetValue(culture, out var resourceManager)) {
                        resources[culture] = resourceManager = new ResourceManager("BlazorClientApp.Resources.LocalizationRes", typeof(DemoLocalizationService).Assembly);
                    }
                    return resourceManager.GetString(key);
                default:
                    return base.GetString(key);
            }            
        }
    }
}
