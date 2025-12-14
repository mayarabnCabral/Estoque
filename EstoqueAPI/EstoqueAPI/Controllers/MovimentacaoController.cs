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
            return Ok(movimentacao);
        }
    }
}
