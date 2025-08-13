using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface ISaidaRepositorio
    {
        void Add(Saida saida);

        List<Saida> GetAll();

        
    }
}
