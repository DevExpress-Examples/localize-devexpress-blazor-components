using System;
using System.Collections.Generic;
using System.Globalization;
using DevExpress.Blazor.Localization;

namespace BlazorClientApp.Services {
	public class DemoLocalizationService : DxLocalizationService, IDxLocalizationService {
		readonly Dictionary<string, Dictionary<string, string>> customLocalizations = new Dictionary<string, Dictionary<string, string>>{
			{"de", new Dictionary<string, string> {
				{"Summary", "Zusammenfassung"},
				{"Temperature", "Temp."},
				{"Date", "Datum"},
				{ "Precipitates", "Niederschläge"},
				{ "Cloudiness", "Trübung"},
				{"SelectYourLanguage", "Wählen Sie Ihre Sprache"},
			}},
			{"en-US", new Dictionary<string, string> {
				{"Summary", "Summary"},
				{"Temperature", "Temp."},
				{"Date", "Date"},
				{"Precipitates", "Precipitates"},
				{ "Cloudiness", "Cloudiness"},
				{"SelectYourLanguage", "Select your language"},
			}},
			{"ru", new Dictionary<string, string> {
				{"Summary", "Сводка."},
				{"Temperature", "Темп."},
				{"Date", "Дата"},
				{"Precipitates", "Осадки"},
				{ "Cloudiness", "Облачность"},
				{"SelectYourLanguage", "Выберите язык"},
			}},
		};

		string IDxLocalizationService.GetString(string key) {
			var culture = CultureInfo.CurrentUICulture.Name;
			if(customLocalizations.TryGetValue(culture, out var localization)) {
				if(localization.TryGetValue(key, out var value)) 
					return value;
			}
			return LocalizationProvider.GetString(culture, key) ?? base.GetString(key);
		}
	}
}
