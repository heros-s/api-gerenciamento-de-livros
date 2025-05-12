using Microsoft.AspNetCore.Mvc;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using EmprestimoLivros.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/emprestimo/")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IUsuarioRepository _repositoryUsuarios;

        public EmprestimoController(
            IEmprestimoRepository repository,
            IUsuarioRepository repositoryUsuarios)
        {
            _repository = repository;
            _repositoryUsuarios = repositoryUsuarios;
        }

        [HttpPost("cadastrar")]
        [Authorize(Roles = "administrador,comum")] // Permite acesso para administradores e comuns
        public IActionResult Cadastrar([FromBody] Emprestimo emprestimo)
        {
            // Pega o e-mail do usuário do token JWT
            var emailUsuario = User.Identity?.Name;

            if (string.IsNullOrEmpty(emailUsuario))
            {
                return Unauthorized(new { mensagem = "Usuário não identificado." });
            }

            // Busca o usuário pelo e-mail
            var usuario = _repositoryUsuarios.BuscarUsuarioPorEmail(emailUsuario);

            if (usuario == null)
            {
                return NotFound(new { mensagem = "Usuário não encontrado." });
            }

            // Associa o usuário ao empréstimo
            emprestimo.UsuarioId = usuario.Id;
            emprestimo.Usuario = usuario;

            // Cadastra o empréstimo
            _repository.Cadastrar(emprestimo);

            return Created("", emprestimo);
        }

        [HttpGet("listar")]
        [Authorize(Roles = "administrador")]
        public IActionResult Listar()
        {
            return Ok(_repository.Listar());
        }
    }
}
