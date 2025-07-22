using Prototipo_CCL.Models;
using Prototipo_CCL.Services;
using Prototipo_CCL.Views;
using System.Windows.Input;

namespace Prototipo_CCL.ViewModels
{
    public class NovoApontamentoViewModel : BaseViewModel
    {
        public Apontamento NovoApontamento { get; set; }
        public List<string> Servicos { get; }
        public List<string> Equipes { get; }
        public ICommand IniciarProducaoCommand { get; }

        public NovoApontamentoViewModel()
        {
            NovoApontamento = new Apontamento();
            Servicos = MockDataService.GetServicos();
            Equipes = MockDataService.GetEquipes();
            IniciarProducaoCommand = new Command(async () => await IniciarProducao());

            NovoApontamento.Servico = Servicos.FirstOrDefault() ?? string.Empty;
            NovoApontamento.Equipe = Equipes.FirstOrDefault() ?? string.Empty;
            NovoApontamento.InicioJornada = DateTime.Now;
        }

        private async Task IniciarProducao()
        {
            if (string.IsNullOrWhiteSpace(NovoApontamento.Servico) || string.IsNullOrWhiteSpace(NovoApontamento.Equipe))
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Selecione um serviço e uma equipe.", "OK");
                return;
            }

            MockDataService.SalvarApontamento(NovoApontamento);

            await Shell.Current.GoToAsync($"{nameof(DetalheProducaoPage)}?ApontamentoId={NovoApontamento.Id}");
        }
    }
}
