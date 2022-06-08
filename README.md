<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/233067893/22.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T850867)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# DevExpress Blazor - How to localize components
 
DevExpress components in Blazor applications use the standard localization mechanism from the .NET framework - [Satellite Resource Assemblies](https://docs.microsoft.com/en-us/dotnet/framework/resources/creating-satellite-assemblies-for-desktop-apps?view=netframework-4.8).

![Blazor Components Localization](images/blazor-localization-overview.png)

Our components ship with NuGet packages with predefined satellite assemblies for the following languages and cultures:
  
- German (de)
- Spanish (es)
- Japanese (ja)

To obtain satellite assemblies for DevExpress .NET controls that correspond to other cultures, use the [DevExpress Localization Service](http://localization.devexpress.com/). This service allows you to modify the existing translations, compile and download the satellite assemblies.

<!-- default file list -->
## Files to Look At

Blazor Server:
- [Program.cs](./CS/DxBlazorLocalization/BlazorServer/Program.cs)
- [CultureController.cs](./CS/DxBlazorLocalization/BlazorServer/Controllers/CultureController.cs)
- [Index.razor](./CS/DxBlazorLocalization/BlazorServer/Pages/Index.razor)

Blazor WebAssembly:
- [Program.cs](./CS/DxBlazorLocalization/BlazorWebAssembly/Program.cs)
- [LocalizationService.cs](./CS/DxBlazorLocalization/BlazorWebAssembly/Services/LocalizationService.cs)
- [Index.razor](./CS/DxBlazorLocalization/BlazorWebAssembly/Pages/Index.razor)
<!-- default file list end -->

## Documentation

[Localization](https://docs.devexpress.com/Blazor/401564/common-concepts/localization)

## More Examples

[Theme Switcher](https://github.com/DevExpress-Examples/blazor-theme-switcher)
