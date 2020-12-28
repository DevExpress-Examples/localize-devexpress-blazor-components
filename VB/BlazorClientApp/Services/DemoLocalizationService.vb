Imports DevExpress.Blazor.Localization
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Resources
Imports System.Threading.Tasks

Namespace BlazorClientApp.Services
	Public Class DemoLocalizationService
		Inherits DxLocalizationService
		Implements IDxLocalizationService

		Private _resourceManager As ResourceManager
		Private ReadOnly Property ResourceManager() As ResourceManager
			Get
				If _resourceManager Is Nothing Then
					_resourceManager = New ResourceManager("LocalizationRes", GetType(DemoLocalizationService).Assembly)
				End If
				Return _resourceManager
			End Get
		End Property
		Private Function IDxLocalizationService_GetString(ByVal key As String) As String Implements IDxLocalizationService.GetString
			Dim culture = CultureInfo.CurrentUICulture.Name
			Dim value As String = Nothing
			Select Case culture
				Case "it-IT"
					value = ResourceManager.GetString(key)
			End Select
			Return If(value, MyBase.GetString(key))
		End Function
	End Class
End Namespace
