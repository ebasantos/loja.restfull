using Loja.Domain.Estoque.Logistica.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("v1/frete")]
    public class FreteController : Controller
    {
        [HttpGet]
        public IActionResult ObterProduto([FromServices] FreteHandler handler, [FromQuery] string cep)
        {
            var result = handler.Handle(new Domain.Estoque.Logistica.Commands.Input.ConsultarFreteCommand(cep));
            return result != null ? (IActionResult)Ok(result) : NoContent();
        }
    }
}
