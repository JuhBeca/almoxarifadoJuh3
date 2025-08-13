using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface ISecretariaRepositorio
    {
        void Add(Secretaria obj);

        List<Secretaria> GetAll();

        
    }
}
