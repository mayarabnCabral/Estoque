    using EstoqueAPI.Models;
    using EstoqueAPI.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Runtime.InteropServices;
    using EstoqueAPI.Interfaces;

namespace EstoqueAPI.Repositorios
{
    public class FornecedorRepositorio : IFornecedor
    {
        private readonly EstoqueDBContext _dbContext; // DbContext para acessar o banco de dados

        public FornecedorRepositorio(EstoqueDBContext estoqueDBContext) // Construtor recebe o DbContext via injeção de dependência
        {
            _dbContext = estoqueDBContext;
        }

        public async Task<FornecedorModel> BuscarPorId(int fornecedorId)
        {
            return await _dbContext.Fornecedores.FirstOrDefaultAsync(x => x.FornecedorId == fornecedorId);
        }


        public async Task<List<FornecedorModel>> BuscarTodosOsFornecedores() // Retorna todos os Fornecedores
        {
            return await _dbContext.Fornecedores.ToListAsync(); // Converte o DbSet em uma lista assíncrona
        }

        public async Task<FornecedorModel> Adicionar(FornecedorModel fornecedor)
        {
            await _dbContext.Fornecedores.AddAsync(fornecedor);  // Adiciona o fornecedor ao DbSet

            await _dbContext.SaveChangesAsync(); // Salva as alterações no banco de dados


            return fornecedor; // Retorna o fornecedor adicionado, agora com o ID gerado pelo banco
        }

        public async Task<FornecedorModel> Atualizar(FornecedorModel fornecedor, int fornecedorId) // Atualiza um usuário existente
        {
            FornecedorModel fornecedorPorId = await BuscarPorId(fornecedorId);

            // Se não encontrar ativa a exceção
            if (fornecedorPorId == null)
                throw new Exception($"Fornecedor para o ID: {fornecedorId} não foi encontrado");
            // Atualiza os campos do 
            fornecedorPorId.CNPJ = fornecedor.CNPJ; // Atualiza o CNPJ
            fornecedorPorId.Descricao = fornecedor.Descricao; // Atualiza a descrição

            await _dbContext.SaveChangesAsync(); // Salva as alterações
            return fornecedorPorId;

        }

        public async Task<FornecedorModel> Apagar(int fornecedorId) // Apaga um forncedore pelo id
        {
            FornecedorModel fornecedorPorId = await BuscarPorId(fornecedorId);  // Busca o fornecedor pelo id

            // Se não encontrar, ativa a exceção

            if (fornecedorPorId == null)
                throw new Exception($"Fornecedor para o ID: {fornecedorPorId} não encontrado");

            _dbContext.Fornecedores.Remove(fornecedorPorId); // Remove o fornecedor

            await _dbContext.SaveChangesAsync();

            return fornecedorPorId; // Retorna true para indicar sucesso

        }

    }
}
