using System.Text.Json.Serialization;

namespace API.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int idade { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public Permissao Permissao { get; set; } = Permissao.administrador;
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}