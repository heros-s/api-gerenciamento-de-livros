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

        public EmprestimoController(IEmprestimoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("cadastrar")]
        [Authorize(Roles = "administrador")]
        public IActionResult Cadastrar([FromBody] Emprestimo emprestimo)
        {
            _repository.Cadastrar(emprestimo);
            return Created("",emprestimo);
        }

        [HttpGet("listar")]
        [Authorize]
        public IActionResult Listar()
        {
        return Ok(_repository.Listar());
        }
    }

}