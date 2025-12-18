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
            if (produto == null)
                return NotFound("Produtos não encontrados.");

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);
            return CreatedAtAction(
                        nameof(BuscarPorId), // Nome da ação
                        new {produtoId = produto.ProdutoId}, // parâmetros da rota
                        produto  // corpo da resposta
                    ); // retonar 201 - Create
        }

        [HttpPut("{ProdutoId}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produtoModel, int produtoId)
        {
            ProdutoModel produto = await _produtoRepositorio.Atualizar(produtoModel, produtoId);
            if(produto == null)
                return NotFound("Produto não encontrado");
            return NoContent(); // Tem que retornar 203 - Non-authoritative Information ou 204 - No Content
        }

        [HttpDelete("{ProdutoId}")]
        public async Task<ActionResult<ProdutoModel>> Apagar(int produtoId)
        {
            ProdutoModel produto = await _produtoRepositorio.Apagar(produtoId);
            return NoContent(); // Tem que retornar 204 - No Content
            

        }
    }
}
