using System.Text.Json.Serialization;

namespace API.Models;

    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Livro> Livros { get; set; } = new List<Livro>();
    }
