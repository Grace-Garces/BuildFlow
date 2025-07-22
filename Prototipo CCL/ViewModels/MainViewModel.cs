using Prototipo_CCL.Models;
using Prototipo_CCL.Services;
using Prototipo_CCL.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Prototipo_CCL.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Apontamento> Apontamentos => MockDataService.Apontamentos;
        public ICommand IniciarNovoApontamentoCommand { get; }

        public MainViewModel()
        {
            IniciarNovoApontamentoCommand = new Command(async () => await IniciarNovoApontamento());
        }

        private async Task IniciarNovoApontamento()
        {
            await Shell.Current.GoToAsync(nameof(NovoApontamentoPage));
        }
    }
}
