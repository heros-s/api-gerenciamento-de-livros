using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/usuario/")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IConfiguration _configuration;
        
        public UsuarioController(IUsuarioRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _repository.Cadastrar(usuario);
            return Created("", usuario);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            Usuario? usuarioExistente = _repository
                .BuscarUsuarioPorEmail(usuario.Email);

            if (usuarioExistente == null)
            {
                return Unauthorized(new { mensagem = "Usuário ou senha inválidos!" });
            }

            string token = GerarToken(usuarioExistente);
            return Ok(token);
        }

        [HttpGet("listar")]
        [Authorize(Roles = "administrador")]
        public IActionResult Listar()
        {
        return Ok(_repository.Listar());
        }

        [HttpDelete("deletar/{id}")]
        [Authorize(Roles = "administrador")]
        public IActionResult Deletar(int id)
        {
            var usuario = _repository.Listar().FirstOrDefault(U => U.Id == id);
            if(usuario == null)
                return NotFound($"Usuario com ID {id} não encontrado");
            
            _repository.Deletar(usuario);
            return Ok();
        }
        [ApiExplorerSettings(IgnoreApi = true)]
    public string GerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Permissao.ToString())
        };

        var chave = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!);
        
        var assinatura = new SigningCredentials(
            new SymmetricSecurityKey(chave),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: assinatura
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    }
}
