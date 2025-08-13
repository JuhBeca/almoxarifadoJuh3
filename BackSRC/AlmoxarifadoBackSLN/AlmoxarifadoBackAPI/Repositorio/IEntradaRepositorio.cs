using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface IEntradaRepositorio
    {
        void Add(Entrada entrada);

        List<Entrada> GetAll();

        
    }
}
