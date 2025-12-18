using EstoqueAPI.Interfaces;
using EstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacao _movimentacaoRepositorio;
        public MovimentacaoController(IMovimentacao movimentacaoRepositorio)
        {
            _movimentacaoRepositorio = movimentacaoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<MovimentacaoModel>>> BuscarPorTodasAsMovimentãcoes()
        {
            List<MovimentacaoModel> movimentacoes = await _movimentacaoRepositorio.BuscarPorTodasAsMovimentacoes();
            return Ok(movimentacoes);
        }
        [HttpGet("{MovimentacaoId}")]
        public async Task<ActionResult<MovimentacaoModel>> BuscarPorId(int MovimentacaoId)
        {
            MovimentacaoModel movimentacao = await _movimentacaoRepositorio.BuscarPorId(MovimentacaoId);
            if(movimentacao == null)
                return NotFound($"Movimentação de identificação ({MovimentacaoId}) não encontrada");

            return Ok(movimentacao);
        }

        [HttpPost]
        public async Task<ActionResult<MovimentacaoModel>> Cadastrar([FromBody] MovimentacaoModel MovimentacaoId)
        {
            MovimentacaoModel movimentacao = await _movimentacaoRepositorio.Adicionar(MovimentacaoId);
            if (movimentacao.Tipo == Enums.MovimentacaoEnum.Entrada)
                return CreatedAtAction(
                    nameof(BuscarPorId),
                    new {MovimentacaoId = movimentacao.MovimentacaoId },
                    new {mensagem = $"Entrada de mercadoria efetuada com sucesso, seu identificador é ({movimentacao.MovimentacaoId})"});

            return CreatedAtAction(
                     nameof(BuscarPorId),
                     new { MovimentacaoId = movimentacao.MovimentacaoId },
                     new { mensagem = $"Venda efetuada com sucesso, seu identificador é ({movimentacao.MovimentacaoId})" });

        }

        // Não terá configuração do PUt, pois movimentação não pode atualizar as informações 

        [HttpDelete("{MovimentacaoId}")]
        public async Task<ActionResult<MovimentacaoModel>> Apagar(int movimentacaoId)
        {
            MovimentacaoModel movimentacao = await _movimentacaoRepositorio.Apagar(movimentacaoId);
            return NoContent(); // Tem que retornar 204 - No Content
        }
    }
}
