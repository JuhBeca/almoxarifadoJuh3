using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private readonly ISecretariaRepositorio _db;
        public SecretariaController(ISecretariaRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/listasecretaria")]
        public IActionResult listasecretaria()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/secretaria")]
        public IActionResult listaSecretaria(SecretariaDTO secretaria)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == secretaria.Codigo));
        }

        [HttpPost("/criarSecretaria")]
        public IActionResult criarSecretaria(SecretariaCadastroDTO secretaria)
        {

            var novaSecretaria = new Secretaria()
            {
                NomeSec = secretaria.NomeSec,
                EndereçoSec = secretaria.EndereçoSec,
                Bairro = secretaria.Bairro,
                CNPJ = secretaria.CNPJ,
                Cidade = secretaria.Cidade,
                EstadoSigla = secretaria.EstadoSigla,
                Telefone = secretaria.Telefone

            };
            //_categorias.Add(novaProduto);
            _db.Add(novaSecretaria);
            return Ok("Cadastro com Sucesso");
        }
    }
}
