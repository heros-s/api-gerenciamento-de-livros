using API.Models;
using API.Data;

namespace API.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly AppDataContext _context;

    public LivroRepository(AppDataContext context)
    {
        _context = context;
    }

    public void Cadastrar(Livro livro)
    {
        _context.livros.Add(livro);
        _context.SaveChanges();
    }

    public Autor? BuscarAutorPorId(int id)
    {
        return _context.Autores.FirstOrDefault(a => a.Id == id);
    }


    public void Deletar(Livro livro)
    {
        _context.livros.Remove(livro);
        _context.SaveChanges();
    }

    public List<Livro> Listar()
    {
        return _context.livros.ToList();
    }

    public Livro? BuscarPorId(int id)
    {
        return _context.livros.FirstOrDefault(l => l.Id == id);
    }

    public void Salvar()
    {
        _context.SaveChanges();
    }

}
