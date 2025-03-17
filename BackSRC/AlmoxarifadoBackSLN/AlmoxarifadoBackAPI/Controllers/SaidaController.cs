using AlmoxarifadoBackAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaidaController : ControllerBase
    {

        private readonly ISaidaRepositorio _db;
        public SaidaController(ISaidaRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/lista")]
        public IActionResult listaSaidas()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/Saida")]
        public IActionResult listaSaidas(SaidaDTO saida)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == saida.Codigo));
        }

        [HttpPost("/criarSaida")]
        public IActionResult criarSaida(SaidaCadastroDTO saida)
        {

            var novaSaida = new Saida()
            {
                Descricao = saida.Descricao,
                Quantidadeatual = saida.Quantidadeatual,
                QuantidadedeSaida = saida.Quantidadedesaida
            };
            //_Saidas.Add(novaSaida);
            _db.Add(novaSaida);
            return Ok("Cadastro com Sucesso");
        }
    }
}
