using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepositorio _db;
        public FornecedorController(IFornecedorRepositorio db)
        {
            _db =db;
      
        }

        [HttpGet("/listaFornecedor")]
        public IActionResult listaFornecedor()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/Fornecedor")]
        public IActionResult listaFornecedor(FornecedorDTO fornecedor)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == fornecedor.Codigo));
        }

        [HttpPost("/criarFornecedor")]
        public IActionResult criarFornecedor(FornecedorCadastroDTO fornecedor)
        {

            var novafor = new Fornecedor()
            {
                Nome = fornecedor.Nome,
                Telefone = fornecedor.Telefone,
                Estado = fornecedor.Estado,
                Cidade = fornecedor.Cidade,
                CNPJ = fornecedor.CNPJ,

            };
            //_categorias.Add(novafor);
            _db.Add(novafor);
            return Ok("Cadastro com Sucesso");
        }



    }
}
