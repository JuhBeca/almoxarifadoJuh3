using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class EntradaController : Controller
    {
        public  IActionResult Index()
        {
            var url = "https://localhost:44366/Entrada";
            List <EntradaDTO> entrada = new List <EntradaDTO> ();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response =  client.GetAsync(url).Result ;
                response.EnsureSuccessStatusCode();
                string json =  response.Content.ReadAsStringAsync().Result;
                 entrada = JsonSerializer.Deserialize<List<EntradaDTO>>(json); 
                 ViewBag.Entradas = entrada;


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
        public IActionResult Cadastro(DateTime dataEntrada, int codigoFronecedor, int codigoProduto, int quantidade, string observacao)
        {

            var url = "https://localhost:44366/criarEntrada";
            using HttpClient client = new HttpClient();
            try
            {
                var entradaNova = new EntradaDTO
                {
                    dataEntrada = dataEntrada,
                    codigoFronecedor = codigoFronecedor,
                    codigoProduto = codigoProduto,
                    quantidade = quantidade,
                    observacao = observacao
                };
                var entSerializada = JsonSerializer.Serialize<EntradaDTO>(entradaNova);

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
