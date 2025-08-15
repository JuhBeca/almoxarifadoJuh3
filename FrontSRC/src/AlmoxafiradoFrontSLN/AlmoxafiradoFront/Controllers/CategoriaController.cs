using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

public class CategoriasController : Controller
{
    public IActionResult Index()
    {
        var url = "https://localhost:44366/lista";
        List<CategoriaDTO> categorias = new List<CategoriaDTO>();
        using HttpClient client = new HttpClient();
        try
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            string json = response.Content.ReadAsStringAsync().Result;
            categorias = JsonSerializer.Deserialize<List<CategoriaDTO>>(json);
            ViewBag.Categorias = categorias;


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
    public IActionResult Cadastrar(string descricao )
    {
        var url = "https://localhost:7215/criarCategoria";

        using HttpClient client = new HttpClient();
        try
        {
            var CategoriasNovo = new CategoriaDTO
            {
                descricao = descricao,
                
            };
            var CategoriasSerializada = JsonSerializer.Serialize<CategoriaDTO>(CategoriasNovo);
            var jsonContent = new StringContent(CategoriasSerializada, Encoding.UTF8, "application/json");

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

