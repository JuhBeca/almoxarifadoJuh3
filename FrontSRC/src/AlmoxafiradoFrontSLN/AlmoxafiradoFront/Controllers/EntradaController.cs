using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class EntradaController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/listaEntrada";
            List<EntradaDTO> entrada = new List<EntradaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                entrada = JsonSerializer.Deserialize<List<EntradaDTO>>(json);
                ViewBag.Entrada = entrada;


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
        public IActionResult Cadastrar(string descricao, int DATAENTRADA, string QUANTIDADEATUAL)
        {
            var url = "https://localhost:44366/criarEntrada";

            using HttpClient client = new HttpClient();
            try
            {
                var entradaNova = new EntradaDTO {
                    descricao = descricao ,
                    DATAENTRADA = DATAENTRADA,
                    QUANTIDADEATUAL = QUANTIDADEATUAL
                };
                var entradaSerializada = JsonSerializer.Serialize<EntradaDTO>(entradaNova);
                var jsonContent = new StringContent(entradaSerializada, Encoding.UTF8, "application/json");

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
