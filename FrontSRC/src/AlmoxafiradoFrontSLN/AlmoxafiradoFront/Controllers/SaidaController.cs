﻿using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class SaidaController : Controller
    {
        public IActionResult Index()
        {

            var url = "https://localhost:44366/listaSaida";
            List<SaidaDTO> saida = new List<SaidaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                saida = JsonSerializer.Deserialize<List<SaidaDTO>>(json);
                ViewBag.Saida = saida;


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
        public IActionResult Cadastrar(string Descricao, int Quantidadeatual, int QuantidadedeSaida)
        {
            return RedirectToAction("index");
        }
    }
}
