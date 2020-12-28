Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Threading.Tasks

Namespace BlazorServerApp.Services
	Public Class SupportedCultures
		Public Shared ReadOnly Property Cultures() As CultureInfo() = {
			New CultureInfo("de-DE"),
			New CultureInfo("en-US"),
			New CultureInfo("ru-RU")
		}
	End Class
End Namespace
