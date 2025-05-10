using System.Text.Json.Serialization;

namespace API.Models;

public class Livro
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public double PrecoDia { get; set; }
    public int AutorId { get; set; }
    [JsonIgnore]
    public Autor Autor { get; set; } = new Autor();
}
