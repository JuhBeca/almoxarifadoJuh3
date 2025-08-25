using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/lista";
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                categorias = JsonSerializer.Deserialize<List<CategoriaDTO>>(json);
                ViewBag.Categorias = categorias;


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
        [HttpPost]
        public IActionResult Cadastro(string descricao)
        {

            var url = "https://localhost:44366/criarcategoria";
            using HttpClient client = new HttpClient();
            try
            {
                var categoriaNova = new CategoriaDTO
                {
                    descricao = descricao,
                   
                };
                var proSerializada = JsonSerializer.Serialize<CategoriaDTO>(categoriaNova);

                var jsonContent = new StringContent(proSerializada, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
