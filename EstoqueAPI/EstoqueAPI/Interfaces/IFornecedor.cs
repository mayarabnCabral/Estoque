using EstoqueAPI.Models;

namespace EstoqueAPI.Interfaces
{
    public interface IFornecedor
    {
        List<FornecedorModel> BuscarTodosOsFornecedores();
        Task<FornecedorModel> BuscarPorId(int FornecedorId);
        Task<FornecedorModel> Adiconar(FornecedorModel fornecedor);
        Task<FornecedorModel> Atualizar(FornecedorModel fornecedor, int FornecedorId);
        Task<bool> Apagar(int FornecedorId);
    }
}
