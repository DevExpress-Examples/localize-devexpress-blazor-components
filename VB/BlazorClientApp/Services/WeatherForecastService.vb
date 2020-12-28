Imports BlazorClientApp.Data
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading
Imports System.Threading.Tasks

Namespace BlazorClientApp.Services
	Public Class WeatherForecastService
		Private temperatureStatistic() As Tuple(Of Integer, Integer) = { Tuple.Create(-15, -1), Tuple.Create(-12, -2), Tuple.Create(-6, 8), Tuple.Create(4, 14), Tuple.Create(11, 21), Tuple.Create(13, 23), Tuple.Create(18, 32), Tuple.Create(16, 26), Tuple.Create(10, 18), Tuple.Create(1, 11), Tuple.Create(-4, 6), Tuple.Create(-13, 1) }

		Private ConditionsForSummary() As Tuple(Of Integer, String) = { Tuple.Create(28, "Hot"), Tuple.Create(14, "Warm"), Tuple.Create(-9, "Cold"), Tuple.Create(-80, "Freezing") }

		Private Shared WeatherTypes() As String = { "Sunny", "Partly cloudy", "Cloudy", "Storm" }

		Private Function CreateForecast() As List(Of WeatherForecast)
			Dim rng = New Random()
			Dim startDate As DateTime = DateTime.Now

			Dim min As Integer = 0
			Dim max As Integer = 0
			Dim temperatureC? As Integer = Nothing

			Return Enumerable.Range(1, 15).Select(Function(index)
				Dim day = startDate.AddDays(index)
				If day.Month - startDate.AddDays(index - 1).Month <> 0 OrElse temperatureC Is Nothing Then
					min = temperatureStatistic(day.Month - 1).Item1
					max = temperatureStatistic(day.Month - 1).Item2
					temperatureC = rng.Next(min, max)
				Else
					temperatureC = temperatureC + rng.Next(-3, 3)
					temperatureC = Math.Max(temperatureC.Value, min)
					temperatureC = Math.Min(temperatureC.Value, max)
				End If
				Dim weatherTypes_Conflict As Integer = If(rng.NextDouble() < 0.5, 0, (If(rng.NextDouble() < 0.5, 1, If(rng.NextDouble() < 0.5, 2, 3))))
				Dim feelTemper As Double = temperatureC.Value - (weatherTypes_Conflict - 1) * 3
				Return New WeatherForecast With {
					.Date = day,
					.TemperatureC = temperatureC.Value,
					.Precipitates = rng.NextDouble() < weatherTypes_Conflict * 0.3,
					.WeatherType = WeatherTypes(weatherTypes_Conflict),
					.Summary = ConditionsForSummary.First(Function(c) c.Item1 <= feelTemper).Item2
				}
			End Function).ToList()
		End Function
		Private Function CreateDetailedForecast() As List(Of WeatherForecast)
			Dim rng = New Random()
			Dim startDate As DateTime = DateTime.Now.Date
			Return Enumerable.Range(1, 15).SelectMany(Function(day)
				Dim dayDate = startDate.AddDays(day)
				Dim avgTemp As Integer = rng.Next(-20, 55)
				Dim minTemp As Integer = Math.Max(-20, avgTemp - 10)
				Dim maxTemp As Integer = Math.Min(55, avgTemp + 10)
				Return Enumerable.Range(0, 24).Select(Function(hour) New WeatherForecast With {
					.Date = dayDate.AddHours(hour),
					.TemperatureC = rng.Next(minTemp, maxTemp),
					.Summary = ConditionsForSummary(rng.Next(ConditionsForSummary.Length)).Item2,
					.WeatherType = WeatherTypes(rng.Next(WeatherTypes.Length)),
					.Precipitates = rng.Next(100) < 30
				})
			End Function).ToList()
		End Function

		Private Property Forecasts() As List(Of WeatherForecast)
		Private Property DetailedForecast() As List(Of WeatherForecast)
		Public Sub New()
			Forecasts = CreateForecast()
			DetailedForecast = CreateDetailedForecast()
		End Sub
		Public Function GetForecastAsync(Optional ByVal ct As CancellationToken = Nothing) As Task(Of IEnumerable(Of WeatherForecast))
			Return Task.FromResult(Forecasts.AsEnumerable())
		End Function
		Public Function GetDetailedForecastAsync(Optional ByVal ct As CancellationToken = Nothing) As Task(Of WeatherForecast())
			Return Task.FromResult(DetailedForecast.ToArray())
		End Function
		Public Function GetSummariesAsync(Optional ByVal ct As CancellationToken = Nothing) As Task(Of String())
			Return Task.FromResult(ConditionsForSummary.Select(Function(v) v.Item2).ToArray())
		End Function
		Public Function GetCloudinessAsync(Optional ByVal ct As CancellationToken = Nothing) As Task(Of IEnumerable(Of String))
			Return Task.FromResult(WeatherTypes.AsEnumerable())
		End Function
		Private Function InsertInternal(ByVal newValue As IDictionary(Of String, Object)) As WeatherForecast()
			Dim dataItem = New WeatherForecast()
			Update(dataItem, newValue)
			Forecasts.Insert(0, dataItem)
			Return Forecasts.ToArray()
		End Function
		Public Function Insert(ByVal newValue As IDictionary(Of String, Object)) As Task(Of WeatherForecast())
			Return Task.FromResult(InsertInternal(newValue))
		End Function
		Private Function RemoveInternal(ByVal dataItem As WeatherForecast) As WeatherForecast()
			Forecasts.Remove(dataItem)
			Return Forecasts.ToArray()
		End Function
		Public Function Remove(ByVal dataItem As WeatherForecast) As Task(Of WeatherForecast())
			Return Task.FromResult(RemoveInternal(dataItem))
		End Function
		Private Function UpdateInternal(ByVal dataItem As WeatherForecast, ByVal newValue As IDictionary(Of String, Object)) As WeatherForecast()
			For Each field In newValue.Keys
				Select Case field
					Case NameOf(dataItem.Date)
						dataItem.Date = DirectCast(newValue(field), DateTime)
					Case NameOf(dataItem.Summary)
						dataItem.Summary = DirectCast(newValue(field), String)
					Case NameOf(dataItem.TemperatureC)
						dataItem.TemperatureC = DirectCast(newValue(field), Integer)
					Case NameOf(dataItem.Precipitates)
						dataItem.Precipitates = DirectCast(newValue(field), Boolean)
					Case NameOf(dataItem.WeatherType)
						dataItem.WeatherType = DirectCast(newValue(field), String)
				End Select
			Next field
			Return Forecasts.ToArray()
		End Function
		Public Function Update(ByVal dataItem As WeatherForecast, ByVal newValue As IDictionary(Of String, Object)) As Task(Of WeatherForecast())
			Return Task.FromResult(UpdateInternal(dataItem, newValue))
		End Function
	End Class

End Namespace