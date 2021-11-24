Imports System.Globalization

Namespace BlazorServerApp.Services

    Public Class SupportedCultures

        Public Shared ReadOnly Property Cultures As CultureInfo() = New CultureInfo() {New CultureInfo("de-DE"), New CultureInfo("en-US"), New CultureInfo("ru-RU")}
    End Class
End Namespace
