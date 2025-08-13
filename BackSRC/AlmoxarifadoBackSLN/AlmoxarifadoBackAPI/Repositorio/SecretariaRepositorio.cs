using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class SecretariaRepositorio : ISecretariaRepositorio
    {
        private readonly Context _db;

        public SecretariaRepositorio(Context db)
        {
            _db = db;
        }

        public void Add(Secretaria obj)
        {
            
            _db.Secretaria.Add(obj);
            _db.SaveChanges();
        }

        public List<Secretaria> GetAll() { 
          return _db.Secretaria.ToList();
        }

    }
}
