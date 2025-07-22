using Prototipo_CCL.Views;
using System.Windows.Input;

namespace Prototipo_CCL.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username = string.Empty;
        public string Username { get => _username; set => SetProperty(ref _username, value); }

        private string _password = string.Empty;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {

            LoginCommand = new Command(async () => await OnLoginClicked());
        }

        private async Task OnLoginClicked()
        {
            if (Username == "Admin" && Password == "admin")
            {
                // Navega para a rota da TabBar, que por padrão abrirá a primeira Tab (PontoPage)
                await Shell.Current.GoToAsync($"//MainApp");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro de Login", "Usuário ou senha inválidos. Tente novamente.", "OK");
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(backingStore, value)) return false;
            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}