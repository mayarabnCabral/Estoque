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
        [HttpGet("{FornecedorId}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int FornecedorId)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.BuscarPorId(FornecedorId);
            if (fornecedor == null)
                return NotFound($"Fornecedor de identificação ({FornecedorId}) não encontrado");
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorModel>> Cadastrar([FromBody] FornecedorModel fornecedorModel)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.Adicionar(fornecedorModel);
            return CreatedAtAction(
                nameof(BuscarPorId), // Nome da ação
                new { FornecedorId = fornecedor.FornecedorId }, // Parâmetros da rota
                new { mensagem = "Fornecedor cadastrado com sucesso", fornecedor } // Corpo da resposta
                );
        }

        [HttpPut("{FornecedorId}")]
        public async Task<ActionResult<FornecedorModel>> Atualizar([FromBody] FornecedorModel fornecedorModel, int fornecedorId)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.Atualizar(fornecedorModel, fornecedorId);
            if (fornecedor == null)
                return NotFound($"Fornecedor de identificação ({fornecedorId}) não encontrado");
            return NoContent();
        }

        [HttpDelete("{FornecedorId}")]
        public async Task<ActionResult<FornecedorModel>> Apagar(int fornecedorId)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.Apagar(fornecedorId);
            return NoContent();
        }

    }
}
