using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using AlmoxafiradoFront.Models;
using Microsoft.AspNetCore.Mvc;
using AlmoxafiradoFront.DTO;

namespace AlmoxafiradoFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            ViewBag.BodyClass = "centralizado";

            return View();
        }
        public IActionResult Dashboard()
        {
            ViewBag.BodyClass = "tela-cheia";
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.BodyClass = "tela-cheia";
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(string nome, string email, string nomeUsuario, string senha)
        {

            var url = "https://localhost:44366/criarUsuario";
            using HttpClient client = new HttpClient();
            try
            {
                var usuarioNovo = new UsuariosDTO
                {
                    nome = nome,
                    email = email,
                    nomeUsuario = nomeUsuario,
                    senha = senha
                };
                var proSerializada = JsonSerializer.Serialize<UsuariosDTO>(usuarioNovo);

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var client = _httpClientFactory.CreateClient();

            var apiUrl = "https://localhost:44366/api/Usuarios/login\r\n";

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var loginResult = JsonSerializer.Deserialize<LoginResult>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                HttpContext.Session.SetString("UsuarioLogado", loginResult.nome);

                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Erro = "Usu�rio ou senha inv�lidos.";
                return View("Index", model);
            }
        }

        public class LoginResult
        {
            public bool sucesso { get; set; }
            public string nome { get; set; }
            public int codigo { get; set; }
        }
    }
}
