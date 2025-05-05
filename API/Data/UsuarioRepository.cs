using API.Models;

namespace API.Data;

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

    public List<Usuario> Listar()
    {
        return _context.usuarios.ToList();
    }
    
}
