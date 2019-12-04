using System.Threading.Tasks;

namespace TaxaJuros.Api.Configuration
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
