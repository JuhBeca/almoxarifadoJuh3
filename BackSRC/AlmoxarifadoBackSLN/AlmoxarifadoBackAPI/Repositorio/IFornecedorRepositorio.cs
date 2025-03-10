using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface IFornecedorRepositorio
    {
        void Add(Fornecedor fornecedor);

        List<Fornecedor> GetAll();
    }
}

