using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface ILoginRepositorio
    {
        void Add(Login obj);

        List<Login> GetAll();

        Login GetById(int id);
        void Update(Login login);
    }
}
