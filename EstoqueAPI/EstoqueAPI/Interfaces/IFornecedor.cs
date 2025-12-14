using EstoqueAPI.Models;

namespace EstoqueAPI.Interfaces
{
    public interface IFornecedor
    {
        Task<List<FornecedorModel>> BuscarTodosOsFornecedores();
        Task<FornecedorModel> BuscarPorId(int FornecedorId);
        Task<FornecedorModel> Adicionar(FornecedorModel fornecedor);
        Task<FornecedorModel> Atualizar(FornecedorModel fornecedor, int FornecedorId);
        Task<bool> Apagar(int FornecedorId);
    }
}
