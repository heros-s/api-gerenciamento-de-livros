using Microsoft.AspNetCore.Mvc;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using API.Models; // Certifique-se de importar o namespace que contém o modelo Livro

namespace API.Controllers
{
    [ApiController]
    [Route("api/emprestimo/")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IUsuarioRepository _repositoryUsuarios;
        private readonly ILivroRepository _livroRepository;

        public EmprestimoController(
            IEmprestimoRepository repository,
            IUsuarioRepository repositoryUsuarios,
            ILivroRepository livroRepository)
        {
            _repository = repository;
            _repositoryUsuarios = repositoryUsuarios;
            _livroRepository = livroRepository;
        }

        [HttpPost("cadastrar")]
        [Authorize(Roles = "administrador")]
        public IActionResult Cadastrar([FromBody] Emprestimo emprestimo)
        {
            var emailUsuario = User.Identity?.Name;

            if (string.IsNullOrEmpty(emailUsuario))
                return Unauthorized(new { mensagem = "Usuário não identificado." });

            var usuario = _repositoryUsuarios.BuscarUsuarioPorEmail(emailUsuario);

            if (usuario == null)
                return NotFound(new { mensagem = "Usuário não encontrado." });

            if (emprestimo.LivroId <= 0)
                return BadRequest(new { mensagem = "LivroId é obrigatório." });

            var livro = _livroRepository.Listar().FirstOrDefault(l => l.Id == emprestimo.LivroId);
            if (livro == null)
                return NotFound(new { mensagem = "Livro não encontrado." });

            emprestimo.UsuarioId = usuario.Id;
            emprestimo.Usuario = usuario;
            emprestimo.Livro = livro;

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
