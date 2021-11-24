Imports DevExpress.Blazor.Localization
Imports System.Globalization
Imports System.Resources

Namespace BlazorClientApp.Services

    Public Class DemoLocalizationService
        Inherits DxLocalizationService
        Implements IDxLocalizationService

        Private _resourceManager As ResourceManager

        Private ReadOnly Property ResourceManager As ResourceManager
            Get
                If _resourceManager Is Nothing Then _resourceManager = New ResourceManager("BlazorClientApp.Resources.LocalizationRes", GetType(DemoLocalizationService).Assembly)
                Return _resourceManager
            End Get
        End Property

        Private Overloads Function IDxLocalizationService_GetString(ByVal key As String) As String Implements IDxLocalizationService.GetString
            Dim culture = CultureInfo.CurrentUICulture.Name
            Dim value As String = Nothing
            Select Case culture
                Case "it-IT"
                    value = ResourceManager.GetString(key)
            End Select

            Return If(value, GetString(key))
        End Function
    End Class
End Namespace
