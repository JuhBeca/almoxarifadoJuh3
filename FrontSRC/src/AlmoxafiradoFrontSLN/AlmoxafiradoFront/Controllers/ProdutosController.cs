using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class ProdutoController : Controller
    {
        public  IActionResult Index()
        {
            var url = "https://localhost:44366/listaprodutos";
            List <ProdutosDTO> produtos = new List < ProdutosDTO> ();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response =  client.GetAsync(url).Result ;
                response.EnsureSuccessStatusCode();
                string json =  response.Content.ReadAsStringAsync().Result;
                 produtos = JsonSerializer.Deserialize<List<ProdutosDTO>>(json); 
                 ViewBag.Produtos = produtos;


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
        public IActionResult Cadastrar(string descricao, string UnidadeMedida, float EstoqueAtual, bool Epermanente, int CodigoCategoria)
        {
            return RedirectToAction("index");
        }
    }
}
