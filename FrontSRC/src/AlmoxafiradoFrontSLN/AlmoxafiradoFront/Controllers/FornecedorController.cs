using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class FornecedorController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/listaFornecedor";
            List<FornecedorDTO> fornecedo = new List<FornecedorDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                fornecedo = JsonSerializer.Deserialize<List<FornecedorDTO>>(json);
                ViewBag.Fornecedor = fornecedo;


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
        public IActionResult Cadastro(string nome, string telefone, string estado, string cidade, string cnpj)
        {

            var url = "https://localhost:44366/criarFornecedor";
            using HttpClient client = new HttpClient();
            try
            {
                var forNova = new FornecedorDTONova
                {
                    nome = nome,
                    telefone = telefone,
                    estado = estado,
                    cidade = cidade,
                    cnpj = cnpj,
                    
                };
                var forSerializada = JsonSerializer.Serialize<FornecedorDTONova>(forNova);

                var jsonContent = new StringContent(forSerializada, Encoding.UTF8, "application/json");

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