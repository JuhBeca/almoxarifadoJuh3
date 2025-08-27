using AlmoxarifadoBackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly Context _db;

        public ProdutoRepositorio(Context db)
        {
            _db = db;
        }

        public Produto GetById(int id)
        {
            return _db.Produto.FirstOrDefault(p => p.Codigo == id);
        }

        public void Add(Produto obj)
        {
            _db.Produto.Add(obj);
            _db.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _db.Produto.Update(produto);
            _db.SaveChanges();
        }

        public List<Produto> GetAll()
        {
            return _db.Produto.ToList();
        }
    }
}
