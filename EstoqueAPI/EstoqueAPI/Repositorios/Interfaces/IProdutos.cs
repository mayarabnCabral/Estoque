using EstoqueAPI.Models;

namespace EstoqueAPI.Repositorios.Interfaces
{
    public interface IProdutos
    {
        List<ProdutosModel> BuscarTodosOSProdutos();
        Task<ProdutosModel> BuscarPorId(int ProdutoId);
        Task<ProdutosModel> Adiconar(ProdutosModel produtos);
        Task<ProdutosModel> Atualizar(ProdutosModel produtos, int ProdutoId);
        Task<bool> Apagar(int ProdutoId); 
    }
}
