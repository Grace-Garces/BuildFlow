using Prototipo_CCL.ViewModels;

namespace Prototipo_CCL.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel) // Modificado
    {
        InitializeComponent();
        BindingContext = viewModel; // Modificado
    }
}