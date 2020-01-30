using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.Blazor.Localization;
using BlazorClientApp.Services;

namespace BlazorClientApp {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddDevExpressBlazor();
            builder.Services.AddScoped<WeatherForecastService>();
            builder.Services.AddSingleton(typeof(IDxLocalizationService), typeof(DemoLocalizationService));
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
