Imports Microsoft.AspNetCore.Localization
Imports Microsoft.AspNetCore.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks

Namespace BlazorServerApp.Controllers
	<Route("[controller]/[action]")>
	Public Class CultureController
		Inherits Controller

		Public Function SetCulture(ByVal culture As String, ByVal redirectUri As String) As IActionResult
			If culture IsNot Nothing Then
				HttpContext.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(New RequestCulture(culture)))
			End If

			Return LocalRedirect(redirectUri)
		End Function
	End Class
End Namespace
