Imports System
Imports System.Globalization
Imports System.Net.Http
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Components.WebAssembly.Hosting
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.JSInterop
Imports BlazorClientApp.Services
Imports DevExpress.Blazor.Localization

Namespace BlazorClientApp
	Public Class Program
		Public Shared Async Function Main(ByVal args() As String) As Task
			Dim builder = WebAssemblyHostBuilder.CreateDefault(args)
			builder.Services.AddDevExpressBlazor()
			builder.Services.AddScoped(Of WeatherForecastService)()
			builder.Services.AddSingleton(New HttpClient With {.BaseAddress = New Uri(builder.HostEnvironment.BaseAddress)})
			builder.Services.AddLocalization(Sub(options) options.ResourcesPath = "Resources")
			builder.Services.AddSingleton(GetType(IDxLocalizationService), GetType(DemoLocalizationService))
			builder.RootComponents.Add(Of App)("app")
			Dim host = builder.Build()
			Dim jsInterop = host.Services.GetRequiredService(Of IJSRuntime)()
			Dim result = Await jsInterop.InvokeAsync(Of String)("blazorCulture.get")
			If result IsNot Nothing Then
				Dim culture = New CultureInfo(result)
				CultureInfo.DefaultThreadCurrentCulture = culture
				CultureInfo.DefaultThreadCurrentUICulture = culture
			End If
			Await host.RunAsync()
		End Function
	End Class
End Namespace
