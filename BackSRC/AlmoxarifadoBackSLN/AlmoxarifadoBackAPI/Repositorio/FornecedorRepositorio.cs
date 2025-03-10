using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly Context _db;

        public FornecedorRepositorio(Context db)
        {
            _db = db;
        }

        public void Add(Fornecedor fornecedor)
        {

            _db.Fornecedor.Add(fornecedor);
            _db.SaveChanges();
        }

        public List<Fornecedor> GetAll()
        {
            return _db.Fornecedor.ToList();
        }
    }
}
