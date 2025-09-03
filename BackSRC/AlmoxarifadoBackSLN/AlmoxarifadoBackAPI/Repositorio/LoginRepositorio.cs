using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class LoginRepositorio : ILoginRepositorio
    {
    {
        private readonly Context _db;

        public LoginRepositorio(Context db)
        {
            _db = db;
        }

        public Login GetById(int id)
        {
            return _db.Login.FirstOrDefault(p => p.Codigo == id);
        }

        public void Add(Login obj)
        {
            _db.Login.Add(obj);
            _db.SaveChanges();
        }

        public void Update(Login login)
        {
            _db.Login.Update(login);
            _db.SaveChanges();
        }

        public List<Produto> GetAll()
        {
            return _db.Login.ToList();
        }
    }
}
