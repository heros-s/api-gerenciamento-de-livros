using API.Models;
using Microsoft.EntityFrameworkCore;    

namespace API.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions options) :  
        base(options) { }
    public DbSet<Livro> livros { get; set; }       
    public DbSet<Usuario> usuarios { get; set; }  
}
