using EstoqueAPI.Models;
using EstoqueAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using EstoqueAPI.Interfaces;

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
            await _dbContext.Movimentacoes.AddAsync(movimentacao);

            await _dbContext.SaveChangesAsync();

            return movimentacao;
        }

        public async Task<bool> Apagar(int movimentacaoId)
        {
            MovimentacaoModel movimentacaoPorId = await BuscarPorId(movimentacaoId);


            if (movimentacaoPorId == null)
                throw new Exception($"Fornecedor para o ID: {movimentacaoPorId} não encontrado");

            _dbContext.Movimentacoes.Remove(movimentacaoPorId); 

            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}
