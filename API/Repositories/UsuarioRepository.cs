using API.Models;
using API.Data;

namespace API.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDataContext _context;

    public UsuarioRepository(AppDataContext context)
    {
        _context = context;
    }

    public void Cadastrar(Usuario usuario)
    {
        _context.usuarios.Add(usuario);
        _context.SaveChanges();
    }
    public void Deletar(Usuario usuario)
    {
        _context.usuarios.Remove(usuario);
        _context.SaveChanges();
    }

    public List<Usuario> Listar()
    {
        return _context.usuarios.ToList();
    }
    
    public Usuario? BuscarUsuarioPorEmail(string email)
    {
        return _context.usuarios
            .FirstOrDefault(u => u.Email == email);
    }

    

    public void Salvar()
    {
        _context.SaveChanges();
    }
}
