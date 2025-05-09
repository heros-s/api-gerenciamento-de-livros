
using API.Data;
using Microsoft.EntityFrameworkCore;
using EmprestimoLivros.Models;
namespace API.Repositories;

public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly AppDataContext _context;

    public EmprestimoRepository(AppDataContext context)
    {
        _context = context;
    }

    public void Cadastrar(Emprestimo emprestimo)
    {
        emprestimo.DataEmprestimo = DateTime.Now;
        emprestimo.Multa = emprestimo.CalcularMulta();
        _context.emprestimos.Add(emprestimo);
        _context.SaveChanges();
    }

    public void Devolucao(int emprestimoId)
    {
        var emprestimo = _context.emprestimos.Find(emprestimoId);
        if (emprestimo != null)
        {
            emprestimo.DataDevolucao = DateTime.Now;
            emprestimo.Multa = emprestimo.CalcularMulta();
            _context.SaveChanges();
        }
    }

    public List<Emprestimo> Listar()
    {
        return _context.emprestimos
            .Include(l => l.Usuario)
            .Include(l => l.Livro)
            .ToList();
    }

    public void Salvar()
    {
        _context.SaveChanges();
    }
}
