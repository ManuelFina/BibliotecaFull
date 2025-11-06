using Microsoft.Extensions.Logging;
using PracticoBiblioteca.Services.Implementaciones;
using PracticoBiblioteca.Services.Interfaces;

namespace PracticoBiblioteca
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddSingleton<HttpClient>(sp =>
            {
                var navigationManager = sp.GetRequiredService<Microsoft.AspNetCore.Components.NavigationManager>();
                return new HttpClient
                {
                    //BaseAddress = new Uri(navigationManager.BaseUri)
                    BaseAddress = new Uri("http://www.BibliotecaApp.somee.com")
                };
            });

            builder.Services.AddScoped<ILibroService, LibroService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<ISesionService, SesionService>();
            builder.Services.AddScoped<IPrestamoService, PrestamoService>();



#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
