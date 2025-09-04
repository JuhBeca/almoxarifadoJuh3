using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface IUsuarioRepositorio
    {
        void Add(Usuarios obj);

        List<Usuarios> GetAll();

        Usuarios GetById(int id);
        void Update(Usuarios login);
    }
}
