using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class FornecedorController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:44366/listaFornecedor\r\n";
            List<FornecedorDTO> fornecedor = new List<FornecedorDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                fornecedor = JsonSerializer.Deserialize<List<FornecedorDTO>>(json);
                ViewBag.Fornecedor = fornecedor;


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
        public IActionResult Cadastrar (string NomeFornecedor, string Endereco, string Bairro, string Telefone,  string Estado, string Cidade, string CNPJ)
        {
            var url = "https://localhost:5001/criarFornecedor";

            using HttpClient client = new HttpClient();
            try
            {
                var fornecedorNovo = new FornecedorDTO
                {
                    NomeFornecedor = NomeFornecedor,
                    Endereco = Endereco,
                    Bairro = Bairro,
                    Telefone = Telefone,
                    Estado = Estado,
                    Cidade = Cidade,
                    CNPJ = CNPJ

                };
                var fornecedorSerializada = JsonSerializer.Serialize<FornecedorDTO>(fornecedorNovo);
                var jsonContent = new StringContent(fornecedorSerializada, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }

            return RedirectToAction("index");
        }
    }
}
