using BlazorClientApp.Services;
using DevExpress.Blazor;
using DevExpress.Blazor.Localization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorClientApp {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddDevExpressBlazor();
            services.AddScoped<WeatherForecastService>();
            services.AddSingleton(typeof(IDxLocalizationService), typeof(DemoLocalizationService));
        }

        public void Configure(IComponentsApplicationBuilder app) {
            app.AddComponent<App>("app");
        }
    }
}
