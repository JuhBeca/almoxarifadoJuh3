using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
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
        public IActionResult Cadastrar(string Descricao, string UnMedida, int EstoqueAtual, bool EPermanente, int CodigoCategoria)
        {
            var url = "https://localhost:44366/criarproduto";

            using HttpClient client = new HttpClient();
            try
            {
                var produtosNovo = new ProdutosDTO
                {
                    Descricao = Descricao,
                    UnMedida = UnMedida,
                    EPermanente = EPermanente,
                    EstoqueAtual = EstoqueAtual,
                    CodigoCategoria = CodigoCategoria
                };
                var produtosSerializada = JsonSerializer.Serialize<ProdutosDTO>(produtosNovo);
                var jsonContent = new StringContent(produtosSerializada, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;
                response.EnsureSuccessStatusCode();
            }
            
            catch (Exception)
            {
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
