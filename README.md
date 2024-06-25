<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/233067893/20.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T850867)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
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
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=localize-devexpress-blazor-components&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=localize-devexpress-blazor-components&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
