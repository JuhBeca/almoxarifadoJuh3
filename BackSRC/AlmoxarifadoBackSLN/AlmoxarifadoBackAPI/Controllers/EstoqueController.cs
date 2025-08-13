using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepositorio _db;
        public EstoqueController(IEstoqueRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/listaEstoque")]
        public IActionResult listaestoque()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/Estoque")]
        public IActionResult listaEstoque(EstoqueDTO estoque)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == estoque.Codigo));
        }

        [HttpPost("/criarEstoque")]
        public IActionResult criarEstoque(EstoqueCadastroDTO estoque)
        {

            var novaEstoque = new Estoque()
            {               
                Produto = estoque.Produto,
                Quantidade = estoque.Quantidade
            };
            //_categorias.Add(novaCategoria);
            _db.Add(novaEstoque);
            return Ok("Cadastro com Sucesso");
        }



    }
}
