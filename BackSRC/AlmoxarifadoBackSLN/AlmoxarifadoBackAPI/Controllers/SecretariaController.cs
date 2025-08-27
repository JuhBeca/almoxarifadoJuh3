using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private readonly ISecretariaRepositorio _db;
        private readonly ISecretariaRepositorio _secreRepo;
        private readonly ISaidaRepositorio _saidaRepo;
        public SecretariaController(ISecretariaRepositorio db, ISecretariaRepositorio secreRepo, ISaidaRepositorio saidaRepo)
        {
            _db = db;
            _secreRepo = secreRepo;
            _saidaRepo = saidaRepo;

        }

        [HttpGet("/listaSecretaria")]
        public IActionResult listaSecretaria()
        {
            return Ok(_db.GetAll());
        }

        [HttpGet("/rankSec")]
        public IActionResult GetRankingSecretaria()
        {
            var secretaria = _secreRepo.GetAll();  // todos os secretarias
            var saidas = _saidaRepo.GetAll();      // todas as saídas

            var ranking = saidas
                .GroupBy(s => s.CodigoSecretaria)
                .Select(g => new
                {
                    CodigoSecretaria = g.Key,
                    QuantidadeTotal = g.Sum(s => s.Quantidade),
                    TotalSaidas = g.Count()
                })
                .Join(secretaria,
                      saida => saida.CodigoSecretaria,
                      secretaria => secretaria.Codigo,
                      (saida, secretaria) => new
                      {
                          secretaria.Codigo,
                          secretaria.Nome,
                          saida.QuantidadeTotal,
                          saida.TotalSaidas
                      })
                .OrderByDescending(x => x.TotalSaidas)
                .Select((x, index) => new
                {
                    Ranking = index + 1,
                    x.Codigo,
                    x.Nome,
                    x.TotalSaidas,
                    x.QuantidadeTotal
                })
                .Take(10);

            return Ok(ranking);
        }

        [HttpPost("/Secretaria")]
        public IActionResult listaSecretaria(SecretariaDTO secretaria)
        {
            return Ok(_db.GetAll().Where(x=>x.Codigo==secretaria.Codigo));
        }

       

        [HttpPost("/criarSecretaria")]
        public IActionResult criarSecretaria(SecretariacadastroDTO secretaria)
        {

            var novase = new Secretaria()
            {
                Nome = secretaria.Nome,
                Telefone = secretaria.Telefone,
                Estado = secretaria.Estado,
                Cidade = secretaria.Cidade,
                CNPJ = secretaria.CNPJ,
            };
            //_categorias.Add(novase);
            _db.Add(novase);
            return Ok("Cadastro com Sucesso");
        }



    }
}
