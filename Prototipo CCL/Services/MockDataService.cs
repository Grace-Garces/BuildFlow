using Prototipo_CCL.Models;
using System.Collections.ObjectModel;

namespace Prototipo_CCL.Services
{
    public static class MockDataService
    {
        public static ObservableCollection<Apontamento> Apontamentos { get; } = new ObservableCollection<Apontamento>();

        public static List<string> GetServicos()
        {
            return new List<string>
            {
                "Roçada Mecanizada",
                "Tapa-Buraco",
                "Limpeza de Drenagem",
                "Sinalização Viária"
            };
        }

        public static List<string> GetEquipes()
        {
            return new List<string>
            {
                "Equipe Alpha",
                "Equipe Bravo",
                "Equipe Charlie"
            };
        }

        public static List<string> GetRestaurantes()
        {
            return new List<string>
            {
                "Restaurante do Zé",
                "Sabor da Fazenda",
                "Churrascaria Pampa"
            };
        }

        public static void SalvarApontamento(Apontamento apontamento)
        {
            var existente = Apontamentos.FirstOrDefault(a => a.Id == apontamento.Id);
            if (existente != null)
            {
                existente.Status = apontamento.Status;
            }
            else
            {
                Apontamentos.Add(apontamento);
            }
        }
    }
}