using EstoqueAPI.Models;

namespace EstoqueAPI.Interfaces
{
    public interface IProduto
    {
        Task<List<ProdutoModel>> BuscarTodosOsProdutos();
        Task<ProdutoModel> BuscarPorId(int ProdutoId);
        Task<ProdutoModel> Adicionar(ProdutoModel produto);
        Task<ProdutoModel> Atualizar(ProdutoModel produto, int ProdutoId);
        Task<bool> Apagar(int ProdutoId); 
    }
}
