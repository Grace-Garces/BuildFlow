using Prototipo_CCL.ViewModels;
using Prototipo_CCL.Views;
using Prototipo_CCL.Converters;
using Prototipo_CCL.Services; // Adicionado

namespace Prototipo_CCL;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FontAwesomeSolid.otf", "FontAwesome");
            });

        // Registro dos Serviços
        builder.Services.AddSingleton<DatabaseService>(); // Adicionado

        // Registro dos ViewModels
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<PontoViewModel>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<AlmocoViewModel>();
        builder.Services.AddSingleton<UsuarioViewModel>();
        builder.Services.AddTransient<NovoApontamentoViewModel>();
        builder.Services.AddTransient<DetalheProducaoViewModel>();

        // Registro das Views (Páginas)
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<PontoPage>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AlmocoPage>();
        builder.Services.AddSingleton<UsuarioPage>();
        builder.Services.AddTransient<NovoApontamentoPage>();
        builder.Services.AddTransient<DetalheProducaoPage>();

        // Registro dos Converters
        builder.Services.AddSingleton<IsNotNullOrEmptyConverter>();
        builder.Services.AddSingleton<IsNullConverter>();
        builder.Services.AddSingleton<IsNotNullConverter>();


        return builder.Build();
    }
}