Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Threading.Tasks

Namespace BlazorServerApp.Services
	Public Class SupportedCultures
		Public Shared ReadOnly Property Cultures() As CultureInfo() = {
			New CultureInfo("de"),
			New CultureInfo("en"),
			New CultureInfo("es"),
			New CultureInfo("ja"),
			New CultureInfo("ru")
		}
	End Class
End Namespace
