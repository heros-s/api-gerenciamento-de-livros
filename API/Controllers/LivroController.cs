using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/livro/")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repository;

        public LivroController(ILivroRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("cadastrar")]
        [Authorize(Roles = "administrador")]
        public IActionResult Cadastrar([FromBody] Livro livro)
        {
            _repository.Cadastrar(livro);
            return Created("",livro);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
        return Ok(_repository.Listar());
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var livro = _repository.Listar().FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound($"Livro com ID {id} não encontrado");
                
            _repository.Deletar(livro);
            return Ok();
        }
    }
}
