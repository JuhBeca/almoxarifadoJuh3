using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class SecretariaController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/listasecretarias";
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
    }
}
