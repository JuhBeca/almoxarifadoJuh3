using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface IFornecedorRepositorio
    {
        void Add(Fornecedor obj);

        List<Fornecedor> GetAll();

        
    }
}
