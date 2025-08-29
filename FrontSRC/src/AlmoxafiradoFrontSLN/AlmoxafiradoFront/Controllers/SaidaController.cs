using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
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
            // SECRETARIAS
            var urlSecretaria = "https://localhost:44366/listaSecretaria";
            List<SecretariaDTO> dep = new List<SecretariaDTO>();

            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(urlSecretaria).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                dep = JsonSerializer.Deserialize<List<SecretariaDTO>>(json);
                ViewBag.departamentosS = dep;
            }
            catch
            {
                ViewBag.departamentosS = new List<SecretariaDTO>();
            }

            // PRODUTOS
            var urlProdutos = "https://localhost:44366/listaprodutos";
            List<ProdutoDTO> depP = new List<ProdutoDTO>();

            try
            {
                HttpResponseMessage response = client.GetAsync(urlProdutos).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                depP = JsonSerializer.Deserialize<List<ProdutoDTO>>(json);
                ViewBag.departamentosP = depP;
            }
            catch
            {
                ViewBag.departamentosP = new List<ProdutoDTO>();
            }

            
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(DateTime dataSaida, int codigoSecretaria, int codigoProduto, int quantidade, string observacao)
        {
            
            var url = "https://localhost:44366/criarSaida";
            using HttpClient client = new HttpClient();
            try
            {
                var saidaNova = new SaidaDTO
                {
                    dataSaida = dataSaida,
                    codigoSecretaria = codigoSecretaria,
                    codigoProduto = codigoProduto,
                    quantidade = quantidade,
                    observacao = observacao
                };
                var saiSerializada = JsonSerializer.Serialize<SaidaDTO>(saidaNova);

                var jsonContent = new StringContent(saiSerializada, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;

                // 👇 Aqui tratamos erro vindo da API (como 404 ou 400)
                if (!response.IsSuccessStatusCode)
                {
                    var mensagemErro = response.Content.ReadAsStringAsync().Result;

                    // 👇 Adiciona o erro para mostrar na tela
                    ModelState.AddModelError(string.Empty, mensagemErro);

                    return View("Create"); // Volta para a tela de cadastro
                }

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao conectar à API.");
                return View("Create");
            }


            
        }
    }
}
