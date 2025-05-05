using API.Models;
namespace API.Repositories;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    List<Usuario> Listar();
    void Deletar(Usuario usuario);
    Usuario? BuscarUsuarioPorEmailSenha(string email, string senha);
}
