using EstoqueAPI.Models;

namespace EstoqueAPI.Interfaces
{
    public interface IProduto
    {
        List<ProdutoModel> BuscarTodosOSProdutos();
        Task<ProdutoModel> BuscarPorId(int ProdutoId);
        Task<ProdutoModel> Adiconar(ProdutoModel produtos);
        Task<ProdutoModel> Atualizar(ProdutoModel produtos, int ProdutoId);
        Task<bool> Apagar(int ProdutoId); 
    }
}
