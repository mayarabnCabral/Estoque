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
            List<MovimentacaoModel> movimentacao = await _movimentacaoRepositorio.BuscarPorTodasAsMovimentacoes();
            return Ok(movimentacao);
        }
        [HttpGet("{ProdutoId}")]
        public async Task<ActionResult<MovimentacaoModel>> BuscarPorId(int MovimentacaoId)
        {
            MovimentacaoModel movimentacao = await _movimentacaoRepositorio.BuscarPorId(MovimentacaoId);
            return Ok(movimentacao);
        }

        [HttpPost]
        public async Task<ActionResult<MovimentacaoModel>> Cadastrar([FromBody] MovimentacaoModel MovimentacaoId)
        {
            MovimentacaoModel movimentacao = await _movimentacaoRepositorio.Adicionar(MovimentacaoId);
           if (movimentacao.Tipo == Enums.MovimentacaoEnum.Entrada)
                return Ok(new { mensagem = $"Entrada de mercadoria efetuada com sucesso, seu identificador é ({movimentacao.MovimentacaoId})" });

           return Ok(new { mensagem = $"Venda efetuada com sucesso, seu identificador é ({movimentacao.MovimentacaoId})" });

        }

        // Não terá configuração do PUt, pois movimentação não pode atualizar as informações 

        [HttpDelete("{MovimentacaoId}")]
        public async Task<ActionResult<MovimentacaoModel>> Apagar(int movimentacaoId)
        {
            MovimentacaoModel movimentacao = await _movimentacaoRepositorio.Apagar(movimentacaoId);
            return Ok($"Movimentação de identificação ({movimentacaoId}) cancelada com sucesso");
        }
    }
}
