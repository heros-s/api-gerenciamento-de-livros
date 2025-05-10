using API.Data;
using API.Models;

namespace API.Repositories;

public class AutorRepository : IAutorRepository
{
    private readonly AppDataContext _context;

    public AutorRepository(AppDataContext context)
    {
        _context = context;
    }

    public void Cadastrar(Autor autor)
    {
        _context.Autores.Add(autor);
        _context.SaveChanges();
    }

    public List<Autor> Listar()
    {
        return _context.Autores.ToList();
    }

    public Autor? BuscarAutorPorId(int id)
    {
        return _context.Autores.Find(id);
    }

    public void Deletar(Autor autor)
    {
        _context.Autores.Remove(autor);
        _context.SaveChanges();
    }

    public void Salvar()
    {
        _context.SaveChanges();
    }
}