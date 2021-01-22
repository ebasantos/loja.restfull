using Loja.Domain.Shared.Entities.Filters;
using Loja.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace Loja.Domain.Vendas.Repositories
{
    public interface IVendaRepository
    {
        long RegistrarVenda(Venda venda);
        void CancelarVenda(long vendaId);
        IEnumerable<Venda> ObterHistorico(PaginatedFilter filtro);
    }
}
