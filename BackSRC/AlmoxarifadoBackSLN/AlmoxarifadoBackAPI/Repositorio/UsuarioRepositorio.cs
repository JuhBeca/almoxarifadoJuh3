using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Context _db;

        public UsuarioRepositorio(Context db)
        {
            _db = db;
        }

        public Usuarios GetById(int id)
        {
            return _db.Usuarios.FirstOrDefault(p => p.Codigo == id);
        }

        public void Add(Usuarios obj)
        {
            _db.Usuarios.Add(obj);
            _db.SaveChanges();
        }

        public void Update(Usuarios Usuarios)
        {
            _db.Usuarios.Update(Usuarios);
            _db.SaveChanges();
        }

        public List<Usuarios> GetAll()
        {
            return _db.Usuarios.ToList();
        }
    }
}
