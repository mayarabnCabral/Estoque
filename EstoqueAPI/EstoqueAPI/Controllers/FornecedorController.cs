using EstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    public class FornecedorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutosModel>> BuscarTodosOsProdutos()
        {
            return Ok();
        }
    }
}
