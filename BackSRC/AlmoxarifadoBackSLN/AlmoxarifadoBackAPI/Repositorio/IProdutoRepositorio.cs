using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface IProdutoRepositorio
    {
        void Add(Produto obj);

        List<Produto> GetAll();

        Produto GetById(int id);



    }
}
