using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
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

        public IActionResult Rank()
        {
            var url = "https://localhost:44366/listaSecretarias"; // Corrija para a rota certa
            List<SecretariaDTO> dep = new List<SecretariaDTO>();

            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                dep = JsonSerializer.Deserialize<List<SecretariaDTO>>(json);
                ViewBag.departamentos = dep;
            }
            catch
            {
                ViewBag.departamentos = new List<SecretariaDTO>();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(string nome, string telefone, string estado, string cidade, string cnpj)
        {

            var url = "https://localhost:44366/criarSecretaria";
            using HttpClient client = new HttpClient();
            try
            {
                var secNova = new SecretariaDTO
                {
                    nome = nome,
                    telefone = telefone,
                    estado = estado,
                    cidade = cidade,
                    cnpj = cnpj,

                };
                var secSerializada = JsonSerializer.Serialize<SecretariaDTO>(secNova);

                var jsonContent = new StringContent(secSerializada, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}