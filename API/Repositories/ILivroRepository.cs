using API.Models;
namespace API.Repositories;

public interface ILivroRepository
{
    void Cadastrar(Livro livro);
    List<Livro> Listar();
    void Deletar(Livro livro);
    
}
