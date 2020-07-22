using DevExpress.Blazor.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace BlazorClientApp.Services
{
    public class DemoLocalizationService : DxLocalizationService, IDxLocalizationService {
        ResourceManager _resourceManager;
        ResourceManager ResourceManager {
            get {
                if(_resourceManager == null)
                    _resourceManager = new ResourceManager("BlazorClientApp.Resources.LocalizationRes", typeof(DemoLocalizationService).Assembly);
                return _resourceManager;
            }
        }
        string IDxLocalizationService.GetString(string key) {
            var culture = CultureInfo.CurrentUICulture.Name;
            string value = null;
            switch(culture) {
                case "it-IT":
                    value = ResourceManager.GetString(key);
                    break;
            }
            return value ?? base.GetString(key);
        }
    }
}
