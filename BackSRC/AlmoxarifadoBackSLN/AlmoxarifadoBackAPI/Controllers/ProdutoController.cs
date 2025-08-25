using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _db;
        private readonly IProdutoRepositorio _produtoRepo;
        private readonly ISaidaRepositorio _saidaRepo;
        public ProdutoController(IProdutoRepositorio db, IProdutoRepositorio produtoRepo, ISaidaRepositorio saidaRepo)
        {
            _db =db;
            _produtoRepo = produtoRepo;
            _saidaRepo = saidaRepo;

        }

        [HttpGet("/listaprodutos")]
        public IActionResult listaProdutos()
        {
            return Ok(_db.GetAll());
        }

        [HttpGet("/listaproZero")]
        public IActionResult listaProdutosZero()
        {
            return Ok(_db.GetAll().Where(x => x.EstoqueAtual == 0));
        }

        [HttpGet("/rankPro")]
        public IActionResult GetRankingProdutos()
        {
            var produtos = _produtoRepo.GetAll();  // todos os produtos
            var saidas = _saidaRepo.GetAll();      // todas as saídas

            var ranking = saidas
                .GroupBy(s => s.CodigoProduto)
                .Select(g => new
                {
                    CodigoProduto = g.Key,
                    QuantidadeTotal = g.Sum(s => s.Quantidade),
                    TotalSaidas = g.Count()
                })
                .Join(produtos,
                      saida => saida.CodigoProduto,
                      produto => produto.Codigo,
                      (saida, produto) => new
                      {
                          produto.Codigo,
                          produto.Descricao,
                          saida.QuantidadeTotal,
                          saida.TotalSaidas
                      })
                .OrderByDescending(x => x.TotalSaidas)
                .Select((x, index) => new
                {
                    Ranking = index + 1,
                    x.Codigo,
                    x.Descricao,
                    x.TotalSaidas,
                    x.QuantidadeTotal
                })
                .Take(10);

            return Ok(ranking);
        }


        [HttpPost("/produto")]
        public IActionResult listaProdutos(ProdutoDTO produto)
        {
            return Ok(_db.GetAll().Where(x=>x.Codigo==produto.Codigo));
        }

        [HttpPost("/criarproduto")]
        public IActionResult criarProduto(ProdutoCadastroDTO produto)
        {

            var novaProduto = new Produto()
            {               
                Descricao = produto.Descricao,
                UnidadeMedida = produto.UnidadeMedida,
                EstoqueAtual = produto.EstoqueAtual,
                Epermanente = produto.Epermanente,
                CodigoCategoria = produto.CodigoCategoria,

            };
            //_categorias.Add(novaProduto);
            _db.Add(novaProduto);
            return Ok("Cadastro com Sucesso");
        }

        
        
        
        

        


    }
}
