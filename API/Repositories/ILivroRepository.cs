using API.Models;
namespace API.Repositories;

public interface ILivroRepository
{
    void Cadastrar(Livro livro);
    List<Livro> Listar();
    Autor? BuscarAutorPorId(int id);
    void Deletar(Livro livro);
    Livro? BuscarPorId(int id);
    void Salvar();
}
