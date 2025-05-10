using API.Models;

namespace API.Repositories;

public interface IAutorRepository
{        
    void Cadastrar(Autor autor);
    List<Autor> Listar();
    Autor? BuscarAutorPorId(int id);
    void Deletar(Autor autor);
    void Salvar();

}
