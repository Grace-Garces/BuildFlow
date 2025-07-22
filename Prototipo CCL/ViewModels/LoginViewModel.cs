using Prototipo_CCL.Services; // Adicionado
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

        private readonly DatabaseService _databaseService;

        // Injeção de dependência do nosso novo serviço de banco de dados
        public LoginViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            LoginCommand = new Command(async () => await OnLoginClicked());
        }

        private async Task OnLoginClicked()
        {
            // Chama o método de validação do nosso serviço de banco de dados
            bool isValid = await _databaseService.ValidateLoginAsync(Username, Password);

            if (isValid)
            {
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
