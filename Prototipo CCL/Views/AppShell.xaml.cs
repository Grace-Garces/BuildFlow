using Prototipo_CCL.Views;

namespace Prototipo_CCL;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registra as rotas para as páginas que serão navegadas
        Routing.RegisterRoute(nameof(AlmocoPage), typeof(AlmocoPage));
        Routing.RegisterRoute(nameof(UsuarioPage), typeof(UsuarioPage));
        Routing.RegisterRoute(nameof(PontoPage), typeof(PontoPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(NovoApontamentoPage), typeof(NovoApontamentoPage));
        Routing.RegisterRoute(nameof(DetalheProducaoPage), typeof(DetalheProducaoPage));
    }
}