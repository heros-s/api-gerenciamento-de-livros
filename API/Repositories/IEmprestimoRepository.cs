using API.Models;

namespace API.Repositories
{
    public interface IEmprestimoRepository
    {
        void Cadastrar(Emprestimo emprestimo);
        void Devolucao(int EmprestimoId);
        int ContarEmprestimosAtivosPorUsuario(int usuarioId);
        List<Emprestimo> Listar();
        void Salvar();
    }
}
