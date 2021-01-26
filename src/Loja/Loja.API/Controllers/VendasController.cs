using Loja.Domain.Shared.Command;
using Loja.Domain.Vendas.Commands;
using Loja.Domain.Vendas.Handler;
using Loja.Domain.Vendas.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("v1/vendas")]
    public class VendasController : Controller
    {
        [HttpPost]
        public IActionResult Registrar([FromServices] VendaHandler handler, [FromBody] RegistrarVendaCommand command)
        {
            var result = handler.Handle(command);

            return result.Success ? (IActionResult)Created("", result) : UnprocessableEntity(result);
        }

        [HttpDelete("{vendaId}")]
        public IActionResult Cancelar([FromServices] IVendaRepository _repo, long vendaId)
        {
            _repo.CancelarVenda(vendaId);

            return Accepted(new GenericCommandResult(true, "Venda cancelada com sucesso", new { vendaId = vendaId }));
        }



        [HttpGet]
        public IActionResult ObterTodos([FromServices] IVendaRepository _repo, [FromQuery] int offSet, int limits)
        {
            var result = _repo.ObterHistorico(new Domain.Shared.Entities.Filters.PaginatedFilter(offSet, limits));
            return result.Result.Any() ? (IActionResult)Ok(result) : NoContent();
        }
    }
}
