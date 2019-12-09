using CalculaJuros.Domain.Interfaces;

namespace CalculaJuros.Infra.Repository
{
    public class CalculaJurosRepository : ICalculaJurosRepository
    {
        public string GetRepositoryGit() => "https://github.com/Juliannotcg/DesafioSoftplan";
    }
}
