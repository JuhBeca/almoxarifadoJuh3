using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class SaidaController : Controller
    {


        public IActionResult Index()
        {
            var url = "https://localhost:44366/listaSaida";
            List<SaidaDTO> sai = new List<SaidaDTO>();
            
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                sai = JsonSerializer.Deserialize<List<SaidaDTO>>(json);
                ViewBag.Saidas = sai;


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
        public IActionResult Cadastro(DateTime dataSaida, int codigoSecretaria, string observacao)
        {

            var url = "https://localhost:44366/criarSaida";
            using HttpClient client = new HttpClient();
            try
            {
                var entradaNova = new SaidaDTO
                {
                    dataSaida = dataSaida,
                    codigoSecretaria = codigoSecretaria,
                    observacao = observacao
                };
                var entSerializada = JsonSerializer.Serialize<SaidaDTO>(entradaNova);

                var jsonContent = new StringContent(entSerializada, Encoding.UTF8, "application/json");

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
