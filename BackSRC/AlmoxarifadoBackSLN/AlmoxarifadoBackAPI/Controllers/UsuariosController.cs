using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepositorio _db;
        public UsuariosController(IUsuarioRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/listaUsuarios")]
        public IActionResult listaUsuarioss()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/Usuario")]
        public IActionResult listaUsuarioss(UsuariosDTO usuarios)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == usuarios.Codigo));
        }

        [HttpPost("/criarUsuario")]
        public IActionResult criarUsuarios(UsuariosCadastroDTO usuarios)
        {

            var novaUsuarios = new Usuarios()
            {
                Nome = usuarios.Nome,
                Email = usuarios.Email,
                NomeUsuario = usuarios.NomeUsuario,
                Senha = usuarios.Senha
            };
            //_Usuarioss.Add(novaUsuarios);
            _db.Add(novaUsuarios);
            return Ok("Cadastro com Sucesso");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            var usuario = _db.GetAll().FirstOrDefault(u =>
                (u.NomeUsuario.Equals(login.NomeUsuario, StringComparison.OrdinalIgnoreCase)
                 || u.Email.Equals(login.NomeUsuario, StringComparison.OrdinalIgnoreCase))
                && u.Senha == login.Senha);

            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos");

            return Ok(new { sucesso = true, nome = usuario.Nome, codigo = usuario.Codigo });
        }


    }
}
