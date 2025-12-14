using EstoqueAPI.Interfaces;
using EstoqueAPI.Models;
using EstoqueAPI.Repositorios;
using Microsoft.AspNetCore.Mvc;


namespace EstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProduto _produtoRepositorio;
        public ProdutoController(IProduto produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosOsProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodosOsProdutos();
            return Ok(produtos);
        }
        [HttpGet("{ProdutoId}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int ProdutoId)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorId(ProdutoId);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);
            return Ok(produto);
        }
    }
}
