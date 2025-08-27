using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaidaController : ControllerBase
    {
        private readonly ISaidaRepositorio _db;
        private readonly IProdutoRepositorio _produtoRepo;
        public SaidaController(ISaidaRepositorio db, IProdutoRepositorio produtoRepo)
        {
            _db = db;
            _produtoRepo = produtoRepo;
        }

        [HttpGet("/listaSaida")]
        public IActionResult listaSaida()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/Saida")]
        public IActionResult listaSaida(SaidaDTO saida)
        {
            return Ok(_db.GetAll().Where(x=>x.Codigo==saida.Codigo));
        }

        [HttpPost("/criarSaida")]
        public IActionResult criarSaida(SaidaCadastroDTO saida)
        {
            var produto = _produtoRepo.GetById(saida.CodigoProduto);

            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            if (produto.EstoqueAtual < saida.Quantidade)
            {
                return BadRequest("Estoque insuficiente para essa saída.");
            }

            var precoUnitario = produto.Preco;
            var precoTotal = precoUnitario * saida.Quantidade;

            var novaSaida = new Saida()
            {
                DataSaida = saida.DataSaida,
                CodigoSecretaria = saida.CodigoSecretaria,
                CodigoProduto = saida.CodigoProduto,
                PrecoProduto = precoUnitario,
                PrecoTotal = precoTotal,
                Quantidade = saida.Quantidade,
                Observacao = saida.Observacao
            };

            // Atualiza o estoque
            produto.EstoqueAtual -= saida.Quantidade;
            _produtoRepo.Update(produto);

            _db.Add(novaSaida);

            return Ok("Saída registrada e estoque atualizado com sucesso.");
        }






    }
}
