using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Prototipo_CCL.Models
{
    public class Apontamento : INotifyPropertyChanged
    {
        private string _status = "Em Andamento";

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Servico { get; set; } = string.Empty;
        public string Equipe { get; set; } = string.Empty;
        public int Trabalhadores { get; set; }
        public int Motoristas { get; set; }
        public int Ajudantes { get; set; }
        public int Tratores { get; set; }
        public DateTime InicioJornada { get; set; }
        public DateTime? FimJornada { get; set; }
        public string PontoInicial { get; set; } = string.Empty;
        public double LarguraTrecho { get; set; }
        public double AreaCalculada => (LarguraTrecho * 1000) / 10000;
        public string CaminhoFoto { get; set; } = string.Empty;
        public string LocalizacaoFoto { get; set; } = string.Empty;
        public DateTime? InicioPausaAlmoco { get; set; }
        public DateTime? FimPausaAlmoco { get; set; }
        public string Restaurante { get; set; } = string.Empty;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}