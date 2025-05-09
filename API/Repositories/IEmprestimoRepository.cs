using API.Models;
using EmprestimoLivros.Models;

namespace API.Repositories
{
    public interface IEmprestimoRepository
    {
        void Cadastrar(Emprestimo emprestimo);
        void Devolucao(int EmprestimoId);
        List<Emprestimo> Listar();
        void Salvar();
    }
}
