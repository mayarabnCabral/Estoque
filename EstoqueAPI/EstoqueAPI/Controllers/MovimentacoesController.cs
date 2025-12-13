using EstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacoesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutosModel>> BuscarTodosOsProdutos()
        {
            return Ok();
        }
    }
}
