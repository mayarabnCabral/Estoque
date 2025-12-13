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

        public async Task<List<MovimentacaoModel>> BuscarTodosOsMovimentacoes()
        {
            return await _dbContext.Movimentacoes.ToListAsync();
        }

        public async Task<MovimentacaoModel> Adicianar(MovimentacaoModel movimentacao)
        {
            await _dbContext.Movimentacoes.AddAsync(movimentacao);

            await _dbContext.SaveChangesAsync();

            return movimentacao;
        }

        public async Task<bool> Apagar(int movimentacaoId)
        {
            MovimentacaoModel movimentacaoPorId = await BuscarPorId(movimentacaoId);

            if (movimentacaoPorId == null)
                throw new Exception($"Movimentação para O ID: {movimentacaoPorId} não encontrada");

            _dbContext.Movimentacoes.Remove(movimentacaoPorId);

            await _dbContext.SaveChangesAsync();    
            return true;
        }

        public List<MovimentacaoModel> BuscarPorTodasAsMovimentãcoes()
        {
            throw new NotImplementedException();
        }

        public Task<MovimentacaoModel> Adicionar(MovimentacaoModel movimentacoes)
        {
            throw new NotImplementedException();
        }

        public Task<MovimentacaoModel> Atualizar(MovimentacaoModel movimentacoes, int MovimentacoesId)
        {
            throw new NotImplementedException();
        }

        Task<MovimentacaoModel> IMovimentacao.Apagar(int Movimentacoes)
        {
            throw new NotImplementedException();
        }
    }
}
