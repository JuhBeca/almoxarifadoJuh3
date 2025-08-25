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
        public IActionResult ProZero()
        {
            var url = "https://localhost:44366/listaproZero";
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
        public IActionResult Rank()
        {
            var url = "https://localhost:44366/rankPro";
            List<RankDTO> produtos = new List<RankDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                produtos = JsonSerializer.Deserialize<List<RankDTO>>(json);
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
        public IActionResult Cadastro(string descricao, decimal preco, string unidadeMedida, float estoqueAtual, bool epermanente, int codigoCategoria  )
        {
       
            var url = "https://localhost:44366/criarproduto";
            using HttpClient client = new HttpClient();
            try
            {
                var produtoNova = new ProdutoDTO
                {
                    descricao = descricao,
                    unidadeMedida = unidadeMedida,
                    preco = preco,
                    estoqueAtual = estoqueAtual,
                    epermanente = epermanente,
                    codigoCategoria = codigoCategoria
                };
                var proSerializada = JsonSerializer.Serialize<ProdutoDTO>(produtoNova);

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
    
