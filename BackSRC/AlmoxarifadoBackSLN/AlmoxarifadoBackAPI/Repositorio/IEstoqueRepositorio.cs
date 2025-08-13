using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface IEstoqueRepositorio
    {
        void Add(Estoque obj);

        List<Estoque> GetAll();

        
    }
}
