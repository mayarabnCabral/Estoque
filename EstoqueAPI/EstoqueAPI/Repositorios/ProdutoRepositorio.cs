using EstoqueAPI.Models;
using EstoqueAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using EstoqueAPI.Interfaces;


namespace EstoqueAPI.Repositorios
{
    public class ProdutoRepositorio : IProduto
    {
        private readonly EstoqueDBContext _dbContext; // DbContext para acessar o banco de dados

        public ProdutoRepositorio(EstoqueDBContext estoqueDBContext) // Construtor recebe o DbContext via injeção de dependência
        {
            _dbContext = estoqueDBContext;
        }

        public async Task<ProdutoModel> BuscarPorId(int produtoId)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == produtoId);
        }


        public async Task<List<ProdutoModel>> BuscarTodosOsProdutos() // Retorna todos os Produtos
        {
            return await _dbContext.Produtos.ToListAsync(); // Converte o DbSet em uma lista assíncrona
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produtos)
        {
            await _dbContext.Produtos.AddAsync(produtos);  // Adiciona o produto ao DbSet
            
            await _dbContext.SaveChangesAsync(); // Salva as alterações no banco de dados


            return produtos; // Retorna o proddutos adicionado, agora com o ID gerado pelo banco
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produtos, int produtoId) // Atualiza um usuário existente
        {
            ProdutoModel produtoPorId = await BuscarPorId(produtoId);

            // Se não encontrar ativa a exceção
            if (produtoPorId == null)
                throw new Exception($"Produto para o ID: {produtoId} não foi encontrado" );
            // Atualiza os campos do produto
            produtoPorId.Descricao = produtos.Descricao; // Atualiza a descrição
            produtoPorId.Quantidade = produtos.Quantidade; // Atualiza a quantidade
            produtoPorId.Preco = produtos.Preco; // Atualiza a quantidade
            produtoPorId.FornecedorId = produtos.FornecedorId; // Atualiza o fornecedor

            await _dbContext.SaveChangesAsync(); // Salva as alterações
            return produtoPorId;

        }   

        public async Task<ProdutoModel> Apagar(int produtoId) // Apaga um produto pelo id
        {
            ProdutoModel produtoPorId = await BuscarPorId(produtoId);  // Busca o produto pelo id

            // Se não encontrar, ativa a exceção

            if (produtoPorId == null)
                throw new Exception($"Produto para o ID: {produtoId} não encontrado");

            _dbContext.Produtos.Remove(produtoPorId); // Remove o produto

            await _dbContext.SaveChangesAsync();

            return produtoPorId; // Retorna true para indicar sucesso
        }

    }
}
