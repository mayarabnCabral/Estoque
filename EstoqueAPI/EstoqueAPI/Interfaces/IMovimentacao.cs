using EstoqueAPI.Models;

namespace EstoqueAPI.Interfaces
{
    public interface IMovimentacao
    {
        List<MovimentacaoModel> BuscarPorTodasAsMovimentãcoes();
        Task<MovimentacaoModel> BuscarPorId(int MovimentacoesId);
        Task<MovimentacaoModel> Adicionar(MovimentacaoModel movimentacoes);
        Task<MovimentacaoModel> Atualizar(MovimentacaoModel movimentacoes, int MovimentacoesId);
        Task<MovimentacaoModel> Apagar(int Movimentacoes);
    }
}
