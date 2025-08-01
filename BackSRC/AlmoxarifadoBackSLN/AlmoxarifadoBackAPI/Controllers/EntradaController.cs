﻿using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {

        private readonly IEntradaRepositorio _db;
        public EntradaController(IEntradaRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/listaEntrada")]
        public IActionResult listaEntradas()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/Entrada")]
        public IActionResult listaEntradas(EntradaDTO entrada)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == entrada.Codigo));
        }

        [HttpPost("/criarEntrada")]
        public IActionResult criarEntrada(EntradaCadastroDTO entrada)
        {

            var novaEntrada = new Entrada()
            {
                DataEntrada = entrada.DataEntrada,
                CodigoFronecedor = entrada.CodigoFronecedor,
                Observacao = entrada.Observacao

            };
            //_Entradas.Add(novaEntrada);
            _db.Add(novaEntrada);
            return Ok("Cadastro com Sucesso");
        }
    }
}
