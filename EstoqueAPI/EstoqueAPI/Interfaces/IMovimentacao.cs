using EstoqueAPI.Models;

namespace EstoqueAPI.Interfaces
{
    public interface IMovimentacao
    {
        Task<List<MovimentacaoModel>> BuscarPorTodasAsMovimentacoes();
        Task<MovimentacaoModel> BuscarPorId(int MovimentacaoId);
        Task<MovimentacaoModel> Adicionar(MovimentacaoModel movimentacao);
        Task<MovimentacaoModel> Apagar(int Movimentacao);
    }
}
