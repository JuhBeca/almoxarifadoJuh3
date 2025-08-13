using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class SecretariaController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/listaSecretaria";
            List<SecretariaDTO> secreta = new List<SecretariaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                secreta = JsonSerializer.Deserialize<List<SecretariaDTO>>(json);
                ViewBag.Secretaria = secreta;


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