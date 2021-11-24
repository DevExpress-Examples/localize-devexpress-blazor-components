Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports BlazorServerApp.Services

Namespace BlazorServerApp

    Public Class Startup

        Public Sub New(ByVal configuration As IConfiguration)
            Me.Configuration = configuration
        End Sub

        Public ReadOnly Property Configuration As IConfiguration

        ' This method gets called by the runtime. Use this method to add services to the container.
        ' For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        Public Sub ConfigureServices(ByVal services As IServiceCollection)
            services.AddRazorPages()
            services.AddServerSideBlazor()
            services.AddControllers()
            services.AddLocalization(Sub(options) options.ResourcesPath = "Resources")
            services.AddSingleton(Of WeatherForecastService)()
            services.Configure(Of RequestLocalizationOptions)(Sub(options)
                options.DefaultRequestCulture = New Microsoft.AspNetCore.Localization.RequestCulture("en")
                options.SupportedUICultures = SupportedCultures.Cultures
                options.SupportedCultures = SupportedCultures.Cultures
            End Sub)
        End Sub

        ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IWebHostEnvironment)
            If env.IsDevelopment() Then
                app.UseDeveloperExceptionPage()
            Else
                app.UseExceptionHandler("/Error")
                ' The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts()
            End If

            app.UseRequestLocalization()
            app.UseHttpsRedirection()
            app.UseStaticFiles()
            app.UseRouting()
            app.UseEndpoints(Sub(endpoints)
                endpoints.MapControllers()
                endpoints.MapBlazorHub()
                endpoints.MapFallbackToPage("/_Host")
            End Sub)
        End Sub
    End Class
End Namespace
