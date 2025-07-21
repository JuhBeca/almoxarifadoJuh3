using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepositorio _db;
        public FornecedorController(IFornecedorRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/listaFornecedor")]
        public IActionResult listaFornecedor()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/fornecedor")]
        public IActionResult listaFornecedor(FornecedorDTO fornecedor)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == fornecedor.codigo));
        }

        [HttpPost("/criarFornecedor")]
        public IActionResult criarFornecedor(FornecedorCadastroDTO fornecedor)
        {

            var novoFornecedor = new Fornecedor()
            {
                NomeFornecedor = fornecedor.NomeFornecedor,
                Cidade = fornecedor.Cidade,
                CNPJ = fornecedor.CNPJ,
                Telefone = fornecedor.Telefone,
                Estado = fornecedor.Estado,
                Estado = fornecedor.Estado,
                Estado = fornecedor.Estado

            };
            //_categorias.Add(novaCategoria);
            _db.Add(novoFornecedor);
            return Ok("Cadastro com Sucesso");
        }
    }
}
