
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/autor/")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        [HttpPost("cadastrar")]
        [Authorize(Roles = "administrador")]
        public IActionResult Cadastrar(Autor autor)
        {
            _autorRepository.Cadastrar(autor);
            return Ok(autor);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_autorRepository.Listar());
        }

        [HttpGet("buscar/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var autor = _autorRepository.BuscarAutorPorId(id);
            if (autor == null) return NotFound();
            return Ok(autor);
        }

        [HttpDelete("deletar/{id}")]
        [Authorize(Roles = "administrador")]
        public IActionResult Deletar(int id)
        {
            var autor = _autorRepository.BuscarAutorPorId(id);
            if (autor == null) return NotFound();
            _autorRepository.Deletar(autor);
            return NoContent();
        }
    }
}
