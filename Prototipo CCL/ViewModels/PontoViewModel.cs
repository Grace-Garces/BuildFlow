using Prototipo_CCL.Views;
using System.Windows.Input;

namespace Prototipo_CCL.ViewModels
{
    public class PontoViewModel : BaseViewModel
    {
        private DateTime _horaAtual;
        public DateTime HoraAtual
        {
            get => _horaAtual;
            set => SetProperty(ref _horaAtual, value);
        }

        private string _mensagemUltimoPonto = string.Empty;
        public string MensagemUltimoPonto
        {
            get => _mensagemUltimoPonto;
            set => SetProperty(ref _mensagemUltimoPonto, value);
        }

        private bool _isUltimoPontoVisible;
        public bool IsUltimoPontoVisible
        {
            get => _isUltimoPontoVisible;
            set => SetProperty(ref _isUltimoPontoVisible, value);
        }

        public ICommand BaterPontoCommand { get; }
        public ICommand IrParaApontamentosCommand { get; }

        private IDispatcherTimer? _timer;

        public PontoViewModel()
        {
            HoraAtual = DateTime.Now;
            BaterPontoCommand = new Command(OnBaterPonto);
            IrParaApontamentosCommand = new Command(async () => await OnIrParaApontamentos());

            StartTimer();
        }

        private void StartTimer()
        {
            _timer = Application.Current.Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) => HoraAtual = DateTime.Now;
            _timer.Start();
        }

        private void OnBaterPonto()
        {
            DateTime pontoRegistrado = DateTime.Now;
            MensagemUltimoPonto = $"Último ponto batido às: {pontoRegistrado:HH:mm:ss}";
            IsUltimoPontoVisible = true;
        }

        private async Task OnIrParaApontamentos()
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

        // Helper para evitar repetição no BaseViewModel
        protected bool SetProperty<T>(ref T backingStore, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}