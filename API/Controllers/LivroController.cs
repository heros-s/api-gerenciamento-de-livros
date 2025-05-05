using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/livro/")]
    public class LivroControlller : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroControlller(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Livro livro)
        {
            _livroRepository.Cadastrar(livro);
            return Created("",livro);
        }
    }
}
