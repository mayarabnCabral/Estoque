using EstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoModel>> BuscarTodosOsFornecedores()
        {
            return Ok();
        }
    }
}
