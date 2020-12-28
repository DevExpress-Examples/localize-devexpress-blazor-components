Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports DevExpress.Blazor.Localization

Namespace BlazorClientApp.Services
	Public Class DemoLocalizationService
		Inherits DxLocalizationService
		Implements IDxLocalizationService

		Private ReadOnly customLocalizations As New Dictionary(Of String, Dictionary(Of String, String)) _
			From {
				{
					"de", New Dictionary(Of String, String) From {
						{"Summary", "Zusammenfassung"},
						{"Temperature", "Temp."},
						{"Date", "Datum"},
						{"Precipitates", "Niederschläge"},
						{"Cloudiness", "Trübung"},
						{"SelectYourLanguage", "Wählen Sie Ihre Sprache"}
					}
				},
				{
					"en-US", New Dictionary(Of String, String) From {
						{"Summary", "Summary"},
						{"Temperature", "Temp."},
						{"Date", "Date"},
						{"Precipitates", "Precipitates"},
						{"Cloudiness", "Cloudiness"},
						{"SelectYourLanguage", "Select your language"}
					}
				},
				{
					"ru", New Dictionary(Of String, String) From {
						{"Summary", "Сводка."},
						{"Temperature", "Темп."},
						{"Date", "Дата"},
						{"Precipitates", "Осадки"},
						{"Cloudiness", "Облачность"},
						{"SelectYourLanguage", "Выберите язык"}
					}
				}
			}

		Private Function IDxLocalizationService_GetString(ByVal key As String) As String Implements IDxLocalizationService.GetString
			Dim culture = CultureInfo.CurrentUICulture.Name
			Dim localization As Dictionary(Of String, String)
			If customLocalizations.TryGetValue(culture, localization) Then
				Dim value As Object
				If localization.TryGetValue(key, value) Then
					Return value
				End If
			End If
			Return If(LocalizationProvider.GetString(culture, key), MyBase.GetString(key))
		End Function
	End Class
End Namespace
