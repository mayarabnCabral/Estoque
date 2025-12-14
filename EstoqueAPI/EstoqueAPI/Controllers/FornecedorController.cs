using EstoqueAPI.Interfaces;
using EstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedor _fornecedorRepositorio;
        public FornecedorController(IFornecedor fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<FornecedorModel>>> BuscarTodosOsFornecedores()
        {
            List<FornecedorModel> fornecedor = await _fornecedorRepositorio.BuscarTodosOsFornecedores();
            return Ok(fornecedor);
        }
        [HttpGet("{ProdutoId}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int FornecedorId)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.BuscarPorId(FornecedorId);
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorModel>> Cadastrar([FromBody] FornecedorModel fornecedorModel)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.Adicionar(fornecedorModel);
            return Ok(fornecedor);
        }
    }
}
