using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaRepositorio _db;
        private readonly IProdutoRepositorio _produtoRepo;

        public EntradaController(IEntradaRepositorio db, IProdutoRepositorio produtoRepo)
        {
            _db = db;
            _produtoRepo = produtoRepo;
        }

        [HttpGet("/Entrada")]
        public IActionResult listaEntrada()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/listaEntrada")]
        public IActionResult listaEntradaFiltro(EntradaDTO entrada)
        {
            return Ok(_db.GetAll().Where(x=>x.Codigo==entrada.Codigo));
        }

        [HttpPost("/criarEntrada")]
        public IActionResult criarEntrada(EntradaCadastroDTO entrada)
        {
            var produto = _produtoRepo.GetById(entrada.CodigoProduto);

            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            var novaEntrada = new Entrada()
            {
                DataEntrada = entrada.DataEntrada,
                CodigoFronecedor = entrada.CodigoFronecedor,
                CodigoProduto = entrada.CodigoProduto,
                Quantidade = entrada.Quantidade,
                Observacao = entrada.Observacao
            };

            // Atualiza o estoque
            produto.EstoqueAtual += entrada.Quantidade;
            _produtoRepo.Update(produto);

            _db.Add(novaEntrada);

            return Ok("Entrada registrada e estoque atualizado com sucesso");
        }




    }
}
