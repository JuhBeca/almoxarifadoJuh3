using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace AlmoxafiradoFront.Controllers
{
    public class SaidaController : Controller
    {
        public IActionResult Index()
        {

            var url = "https://localhost:44366/listaSaida\r\n";
            List<SaidaDTO> saida = new List<SaidaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                saida = JsonSerializer.Deserialize<List<SaidaDTO>>(json);
                ViewBag.Saida = saida;


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
        public IActionResult Cadastrar(string descricao, int Quantidadeatual, int QuantidadedeSaida)
        {
            var url = "https://localhost:44366/criarSaida";

            using HttpClient client = new HttpClient();
            try
            {
                var saidaNova = new SaidaDTO
                {
                    descricao = descricao,
                    Quantidadeatual = Quantidadeatual,
                    QuantidadedeSaida = QuantidadedeSaida
                    
                };
                var saidaSerializada = JsonSerializer.Serialize<SaidaDTO>(saidaNova);
                var jsonContent = new StringContent(saidaSerializada, Encoding.UTF8, "application/json");

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
