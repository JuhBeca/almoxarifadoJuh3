using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class SecretariaController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/listasecretarias\r\n";
            List<SecretariaDTO> secretaria = new List<SecretariaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                secretaria = JsonSerializer.Deserialize<List<SecretariaDTO>>(json);
                ViewBag.Categorias = secretaria;


            }
            catch (Exception)
            {
                return View();

            }

            return View();
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar(string NomeSec, string EndereçoSec, string Bairro, string Cidade, string EstadoSigla, string Telefone, string CNPJ)
        {
            var url = "https://localhost:44366/criarSecretaria";

            using HttpClient client = new HttpClient();
            try
            {
                var secretariaNova = new SecretariaDTO
                {
                   NomeSec =NomeSec,
                   EndereçoSec = EndereçoSec,
                   Bairro = Bairro,
                   Cidade = Cidade,
                   EstadoSigla = EstadoSigla,
                   Telefone = Telefone,
                   CNPJ = CNPJ

                };
                var secretariaSerializada = JsonSerializer.Serialize<SecretariaDTO>(secretariaNova);
                var jsonContent = new StringContent(secretariaSerializada, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return View();
            }
            return RedirectToAction("index");
        }
    }
}
