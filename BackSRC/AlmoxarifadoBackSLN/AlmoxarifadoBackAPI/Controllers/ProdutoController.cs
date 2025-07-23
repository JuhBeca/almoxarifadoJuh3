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
        public ProdutoController(IProdutoRepositorio db)
        {
            _db =db;
      
        }

        [HttpGet("/listaprodutos")]
        public IActionResult listaProdutos()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/produto")]
        public IActionResult listaProdutos(ProdutoDTO categoria)
        {
            return Ok(_db.GetAll().Where(x=>x.Codigo==categoria.Codigo));
        }

        [HttpPost("/criarproduto")]
        public IActionResult criarProduto(ProdutoCadastroDTO produto)
        {

            var novaProduto = new Produto()
            {               
                Descricao = produto.Descricao,
                UnMedida = produto.UnMedida,
                EstoqueAtual = produto.EstoqueAtual,
                EPermanente = produto.EPermanente,
                CodigoCategoria = produto.CodigoCategoria,

            };
            //_categorias.Add(novaProduto);
            _db.Add(novaProduto);
            return Ok("Cadastro com Sucesso");
        }



    }
}
