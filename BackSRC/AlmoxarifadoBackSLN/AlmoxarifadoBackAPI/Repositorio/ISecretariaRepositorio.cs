using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface ISecretariaRepositorio
    {
        void Add(Secretaria secretaria);

        List<Secretaria> GetAll();
    }
}
