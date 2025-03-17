using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class SaidaRepositorio : ISaidaRepositorio
    {
        private readonly Context _db;

        public SaidaRepositorio(Context db)
        {
            _db = db;
        }

        public void Add(Saida saida)
        {

            _db.Saida.Add(saida);
            _db.SaveChanges();
        }

        public List<Saida> GetAll()
        {
            return _db.Saida.ToList();
        }
    }
}
