using EstoqueAPI.Data;
using EstoqueAPI.Enums;
using EstoqueAPI.Interfaces;
using EstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EstoqueAPI.Repositorios
{
    public class MovimentacaoRepositorio : IMovimentacao
    {
        private readonly EstoqueDBContext _dbContext;

        public MovimentacaoRepositorio(EstoqueDBContext estoqueDBContext) // Construtor recebe o DbContext via injeção de dependência
        {
            _dbContext = estoqueDBContext;
        }

        public async Task<MovimentacaoModel> BuscarPorId(int movimentacaoId)
        {
            return await _dbContext.Movimentacoes.FirstOrDefaultAsync(x => x.MovimentacaoId == movimentacaoId);
        }

        public async Task<List<MovimentacaoModel>> BuscarPorTodasAsMovimentacoes()
        {
            return await _dbContext.Movimentacoes.ToListAsync();
        }

        public async Task<MovimentacaoModel> Adicionar(MovimentacaoModel movimentacao)
        {
            // Busca o produto
            ProdutoModel produto = await _dbContext.Produtos
                .FirstOrDefaultAsync(p => p.ProdutoId == movimentacao.ProdutoId);

            if (produto == null)
                throw new Exception("Produto não encontrado");

            // Inicio da regra de negócio
            if (movimentacao.Tipo == MovimentacaoEnum.Entrada) // Se o tipo de movimentação for de entrada (1) irá incluir a quantidade no produto
            {
                produto.Quantidade += movimentacao.Quantidade;
            }
            if (movimentacao.Tipo == MovimentacaoEnum.Saida) // Se o tipo de movimentação for de saída (2) e tiver estoque suficiente irá tirar a quantidade no produto
            {
                if (produto.Quantidade < movimentacao.Quantidade)
                    throw new Exception("Estoque insuficiente");

                produto.Quantidade -= movimentacao.Quantidade;
            }

            // Fim da regra de negócio

            
            await _dbContext.Movimentacoes.AddAsync(movimentacao); // Salva a movimentação

            
            await _dbContext.SaveChangesAsync(); // Salva tudo (produto + movimentação)

            return movimentacao;
        }

        public async Task<MovimentacaoModel> Apagar(int movimentacaoId)
        {
            MovimentacaoModel movimentacaoPorId = await BuscarPorId(movimentacaoId);


            if (movimentacaoPorId == null)
                throw new Exception($"Movimentação  para o ID: {movimentacaoId} não encontrado");

            _dbContext.Movimentacoes.Remove(movimentacaoPorId);

            // Inicio Regra de negocio para excluir a alteração no saldo do produto 

            ProdutoModel produto = await _dbContext.Produtos
        .FirstOrDefaultAsync(p => p.ProdutoId == movimentacaoPorId.ProdutoId); // Busca pelo primeiro produto que supri a busca

            if (produto == null) 
                throw new Exception("Produto não encontrado"); // Se não encontrar retorna "Produto não encontrado"

            if (movimentacaoPorId.Tipo == MovimentacaoEnum.Entrada) // Se o tipo de movimentação for de entrada (1) e o estoque não for ficar negativo ele vai desfazer a quantidade da movimentação
            {

                if (produto.Quantidade < movimentacaoPorId.Quantidade)
                    throw new Exception("Cancelamento não permitido: seu estoque ficará negativo");

               produto.Quantidade -= movimentacaoPorId.Quantidade;

            }
            else if (movimentacaoPorId.Tipo == MovimentacaoEnum.Saida)// Se o tipo de movimentação for de saída (2) ele vai desfazer a quantidade da movimentação
            {
                produto.Quantidade += movimentacaoPorId.Quantidade;
            }

            // Fim Regra de negocio para excluir a alteração no saldo do produto 

            await _dbContext.SaveChangesAsync();

            return movimentacaoPorId;

        }
    }
}
