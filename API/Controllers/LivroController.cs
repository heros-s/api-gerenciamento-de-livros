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
        public IActionResult Cadastrar([FromBody] Livro livro, [FromRoute] Autor autorNome)
        {
            var autor = _repository.BuscarAutorPorId(livro.AutorId);

            if (autor == null)
                return BadRequest($"Autor com ID {livro.AutorId} não encontrado.");

            livro.Autor = autorNome;
            _repository.Cadastrar(livro);
            return Created("", livro);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_repository.Listar());
        }

        //deletar livro
        [HttpDelete("deletar/{id}")]
        [Authorize(Roles = "administrador")]
        public IActionResult Deletar(int id)
        {
            var livro = _repository.BuscarPorId(id);
            if (livro == null)
                return NotFound($"Livro com ID {id} não encontrado.");

            _repository.Deletar(livro);
            return NoContent();
        }
    }
}
