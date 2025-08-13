using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class EstoqueRepositorio : IEstoqueRepositorio
    {
        private readonly Context _db;

        public EstoqueRepositorio(Context db)
        {
            _db = db;
        }

        public void Add(Estoque estoque)
        {
            
            _db.Estoque.Add(estoque);
            _db.SaveChanges();
        }

        public Context Get_db()
        {
            return _db;
        }

        public List<Estoque> GetAll()
        {
            return _db.Estoque.ToList();
        }

    }
}
