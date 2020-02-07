### How to localize DevExpress Blazor components

This example demonstrates how to translate DevExpress Blazor components into different languages. The localization mechanism depends on your application’s [hosting model][0]: Blazor Server (ASP.NET Core) or Blazor WebAssembly. The example contains code samples both for Blazor Server and Blazor WebAssembly.
 
 
 **Blazor Server**
 
DevExpress components in Blazor Server applications use the standard localization mechanism from the .NET framework - [Satellite Resource Assemblies][1].
Our components ship with NuGet packages with predefined satellite assemblies for the following languages and cultures:
  
- German (de)
- Spanish (es)
-	Japanese (ja)
-	Russian (ru)

To obtain satellite assemblies for DevExpress .NET controls that correspond to other cultures, use the [DevExpress Localization Service](http://localization.devexpress.com/). This service allows you to modify the existing translations, compile and download the satellite assemblies.
 
 *Files to look at*:

- [Startup.cs](./CS/BlazorServerApp/Startup.cs)
- [CultureController.cs](./CS/BlazorServerApp/Controllers/CultureController.cs)
- [Index.razor](./CS/BlazorServerApp/Pages/Index.razor)


**Blazor WebAssembly**

Currently, there are no official nor recommended approaches on how to localize Blazor WebAssembly applications. DevExpress Components in Blazor WebAssembly applications are localized using the [IDxLocalizationService][2] interface implementation.

In this example, \*.resx files are converted to dictionaries using [T4 text templates][5]. The [IDxLocalizationService][2] interface returns the required string from the corresponding dictionary using the [IDxLocalizationService.GetString][4] method.

*Files to look at*:
  
-	[Startup.cs](./CS/BlazorClientApp/Startup.cs)
-	[DemoLocalizationService.cs](./CS/BlazorClientApp/Services/DemoLocalizationService.cs)
-	[Index.razor](./CS/BlazorClientApp/Pages/Index.razor)
-	[Resources folder](./CS/BlazorClientApp.Localization/Resources)

[0]: https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-3.0
[1]: https://docs.microsoft.com/en-us/dotnet/framework/resources/creating-satellite-assemblies-for-desktop-apps?view=netframework-4.8
[2]: http://docs.devexpress.com/Blazor/DevExpress.Blazor.Localization.IDxLocalizationService
[4]: http://docs.devexpress.com/Blazor/DevExpress.Blazor.Localization.IDxLocalizationService.GetString\(System.String\)
[5]: https://docs.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates?view=vs-2019
