namespace API.Models;
    public class Emprestimo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public int LivroId { get; set; }
        public Livro Livro { get; set; } = new Livro();
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
        public DateTime? DataDevolucao { get; set; } = DateTime.Now.AddDays(7);
        public decimal ValorLocacao { get; set; }
        public decimal Multa { get; set; }
        
        
        public bool Atrasado()
        {
            return DataDevolucao == null && (DateTime.Now - DataEmprestimo).TotalDays > 7;
        }

        public decimal CalcularMulta()
        {
            return Atrasado() ? ValorLocacao * 0.10m : 0;
        }

    }