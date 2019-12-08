using CalculaJuros.Domain.Command;
using CalculaJuros.Service.ViewModels;
using System.Threading.Tasks;

namespace CalculaJuros.Service.Interfaces
{
    public interface ICalcularJurosService
    {
        Task<CalculoJurosCommandCalcular> CalcularJurosServiceAsync(decimal valorInicial, int meses);
        Task<TaxaJurosViewModel> Request();
    }
}
