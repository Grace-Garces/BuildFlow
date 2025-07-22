using Prototipo_CCL.Models;
using Prototipo_CCL.Services;
using System.Windows.Input;
using Microsoft.Maui.Media;
using Microsoft.Maui.Devices.Sensors;

namespace Prototipo_CCL.ViewModels
{
    [QueryProperty(nameof(ApontamentoId), "ApontamentoId")]
    public class DetalheProducaoViewModel : BaseViewModel
    {
        private Apontamento? _apontamentoAtual;
        public Apontamento? ApontamentoAtual
        {
            get => _apontamentoAtual;
            set
            {
                _apontamentoAtual = value;
                OnPropertyChanged();
            }
        }

        private string? _apontamentoId;
        public string? ApontamentoId
        {
            get => _apontamentoId;
            set
            {
                _apontamentoId = value;
                CarregarApontamento(value);
            }
        }

        public List<string> Restaurantes { get; }
        public ICommand TirarFotoCommand { get; }
        public ICommand IniciarPausaCommand { get; }
        public ICommand FinalizarPausaCommand { get; }
        public ICommand EncerrarApontamentoCommand { get; }

        public DetalheProducaoViewModel()
        {
            Restaurantes = MockDataService.GetRestaurantes();
            TirarFotoCommand = new Command(async () => await TirarFoto());
            IniciarPausaCommand = new Command(IniciarPausa);
            FinalizarPausaCommand = new Command(FinalizarPausa);
            EncerrarApontamentoCommand = new Command(async () => await EncerrarApontamento());
        }

        private void CarregarApontamento(string? id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                ApontamentoAtual = MockDataService.Apontamentos.FirstOrDefault(a => a.Id == guid);
                if (ApontamentoAtual != null)
                {
                    ApontamentoAtual.Restaurante = Restaurantes.FirstOrDefault() ?? string.Empty;
                }
            }
        }

        private async Task TirarFoto()
        {
            if (ApontamentoAtual == null) return;
            try
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();
                    if (photo != null)
                    {
                        ApontamentoAtual.CaminhoFoto = photo.FullPath;
                        OnPropertyChanged(nameof(ApontamentoAtual));
                        await ObterLocalizacao();
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Captura de foto não é suportada neste dispositivo.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro ao tirar a foto: {ex.Message}", "OK");
            }
        }

        private async Task ObterLocalizacao()
        {
            if (ApontamentoAtual == null) return;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                Location? location = await Geolocation.Default.GetLocationAsync(request);

                if (location != null)
                {
                    ApontamentoAtual.LocalizacaoFoto = $"Lat: {location.Latitude}, Lon: {location.Longitude}";
                }
            }
            catch (Exception)
            {
                ApontamentoAtual.LocalizacaoFoto = "Não foi possível obter a localização.";
            }
            finally
            {
                OnPropertyChanged(nameof(ApontamentoAtual));
            }
        }

        private void IniciarPausa()
        {
            if (ApontamentoAtual == null) return;
            ApontamentoAtual.InicioPausaAlmoco = DateTime.Now;
            OnPropertyChanged(nameof(ApontamentoAtual));
        }

        private void FinalizarPausa()
        {
            if (ApontamentoAtual == null) return;
            ApontamentoAtual.FimPausaAlmoco = DateTime.Now;
            OnPropertyChanged(nameof(ApontamentoAtual));
        }

        private async Task EncerrarApontamento()
        {
            if (ApontamentoAtual == null) return;
            bool confirmar = await Application.Current.MainPage.DisplayAlert("Confirmar", "Deseja realmente encerrar este apontamento?", "Sim", "Não");
            if (confirmar)
            {
                ApontamentoAtual.FimJornada = DateTime.Now;
                ApontamentoAtual.Status = "Pendente de Validação";
                MockDataService.SalvarApontamento(ApontamentoAtual);
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}