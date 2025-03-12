using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class CategoriaController : Controller
    {
        public  IActionResult Index()
        {
            var url = "https://localhost:44366/lista";
            List <CategoriaDTO> categorias = new List < CategoriaDTO> ();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response =  client.GetAsync(url).Result ;
                response.EnsureSuccessStatusCode();
                string json =  response.Content.ReadAsStringAsync().Result;
                 categorias = JsonSerializer.Deserialize<List<CategoriaDTO>>(json);
                 ViewBag.Categoria = categorias;


            }
            catch (Exception)
            {
                return View();
                
            }

            return View();
        }
    }
}
