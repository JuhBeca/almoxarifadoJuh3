using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class EstoqueController : Controller
    {
        public  IActionResult Index()
        {
            var url = "https://localhost:44366/listaEstoque";
            List <EstoqueDTO> estoques = new List < EstoqueDTO> ();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response =  client.GetAsync(url).Result ;
                response.EnsureSuccessStatusCode();
                string json =  response.Content.ReadAsStringAsync().Result;
                 estoques = JsonSerializer.Deserialize<List<EstoqueDTO>>(json); 
                 ViewBag.Estoques = estoques;


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
        public IActionResult Cadastrar(string produto, int quantidade)
        {
            var url = "https://localhost:44366/criarEstoque";
            using HttpClient client = new HttpClient();
            try
            {
                var Estoquenova = new EstoqueDTONova { produto = produto };
                var estoqueSerializada= JsonSerializer.Serialize<EstoqueDTONova>(Estoquenova);

                var jsonContent = new StringContent(estoqueSerializada, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;
                response.EnsureSuccessStatusCode();
            }
            catch(Exception)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
