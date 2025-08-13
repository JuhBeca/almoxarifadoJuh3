using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/listaprodutos";
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                produtos = JsonSerializer.Deserialize<List<ProdutoDTO>>(json);
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
        [HttpPost]
        public IActionResult Cadastro(string descricao, string unidademedida, float estoqueatual, bool epermanente, int categoria  )
        {
       
            var url = "https://localhost:44366/criarproduto";
            using HttpClient client = new HttpClient();
            try
            {
                var produtoNova = new ProdutoDTONova
                {
                    descricao = descricao,
                    unidademedida = unidademedida,
                    estoqueatual = estoqueatual,
                    epermanente = epermanente,
                    codigocategoria = categoria
                };
                var proSerializada = JsonSerializer.Serialize<ProdutoDTONova>(produtoNova);

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
    
