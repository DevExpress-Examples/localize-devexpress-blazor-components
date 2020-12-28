Imports System
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Blazor.Hosting
Imports Microsoft.Extensions.DependencyInjection
Imports DevExpress.Blazor.Localization
Imports BlazorClientApp.Services

Namespace BlazorClientApp
	Public Class Program
		Public Shared Async Function Main(ByVal args() As String) As Task
			Dim builder = WebAssemblyHostBuilder.CreateDefault(args)
			builder.Services.AddDevExpressBlazor()
			builder.Services.AddScoped(Of WeatherForecastService)()
			builder.Services.AddSingleton(GetType(IDxLocalizationService), GetType(DemoLocalizationService))
			builder.RootComponents.Add(Of App)("app")

			Await builder.Build().RunAsync()
		End Function
	End Class
End Namespace
