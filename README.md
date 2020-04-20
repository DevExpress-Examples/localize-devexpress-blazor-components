### How to localize DevExpress Blazor components
 
DevExpress components in Blazor applications use the standard localization mechanism from the .NET framework - [Satellite Resource Assemblies][0].
Our components ship with NuGet packages with predefined satellite assemblies for the following languages and cultures:
  
- German (de)
- Spanish (es)
-	Japanese (ja)
-	Russian (ru)

To obtain satellite assemblies for DevExpress .NET controls that correspond to other cultures, use the [DevExpress Localization Service](http://localization.devexpress.com/). This service allows you to modify the existing translations, compile and download the satellite assemblies.
 
 *Files to look at*:

Blazor Server
- [Startup.cs](./CS/BlazorServerApp/Startup.cs)
- [CultureController.cs](./CS/BlazorServerApp/Controllers/CultureController.cs)
- [Index.razor](./CS/BlazorServerApp/Pages/Index.razor)

Blazor WebAssembly
-	[Program.cs](./CS/BlazorClientApp/Program.cs)
-	[Index.razor](./CS/BlazorClientApp/Pages/Index.razor)

[0]: https://docs.microsoft.com/en-us/dotnet/framework/resources/creating-satellite-assemblies-for-desktop-apps?view=netframework-4.8
