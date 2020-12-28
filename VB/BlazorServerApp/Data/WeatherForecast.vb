Imports System

Namespace BlazorServerApp.Data
	Public Class WeatherForecast
		Public Property [Date]() As DateTime

		Public Property TemperatureC() As Integer

		Public Property Precipitates() As Boolean

		Public Property Summary() As String

		Public ReadOnly Property TemperatureF() As Double
			Get
				Return Math.Round((TemperatureC * 1.8 + 32), 2)
			End Get
		End Property
		Public Property WeatherType() As String
	End Class
End Namespace
