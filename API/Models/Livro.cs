using System.Text.Json.Serialization;

namespace API.Models;

public class Livro
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public int AutorId { get; set; }
    public Autor? Autor { get; set; }
}
