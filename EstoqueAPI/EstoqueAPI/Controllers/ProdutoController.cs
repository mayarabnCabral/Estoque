using EstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace EstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoModel>> BuscarTodosOsProdutos()
        {
            return Ok();
        }
    }
}
