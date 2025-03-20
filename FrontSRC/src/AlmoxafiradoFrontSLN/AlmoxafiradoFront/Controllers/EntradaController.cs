using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
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
    }
}
