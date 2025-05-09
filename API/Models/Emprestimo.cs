using System.Reflection.Metadata.Ecma335;
using API.Models;

namespace EmprestimoLivros.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public decimal ValorLocacao { get; set; }
        public decimal Multa { get; set; }
        public Livro Livro { get; set; } = new Livro();
        public Usuario Usuario { get; set; } = new Usuario();
        
        public bool Atrasado()
        {
            return DataDevolucao == null && (DateTime.Now - DataEmprestimo).TotalDays > 5;
        }

        public decimal CalcularMulta()
        {
            return Atrasado() ? ValorLocacao * 0.10m : 0;
        }

    }

}