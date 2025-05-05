using API.Models;
namespace API.Data;

public interface ILivroRepository
{
    void Cadastrar(Livro livro);
    List<Livro> Listar();
}
