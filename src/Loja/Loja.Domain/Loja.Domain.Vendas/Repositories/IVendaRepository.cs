using Loja.Domain.Shared.Entities;
using Loja.Domain.Shared.Entities.Filters;
using Loja.Domain.Shared.Repository;
using Loja.Domain.Vendas.Entities;

namespace Loja.Domain.Vendas.Repositories
{
    public interface IVendaRepository: IConnection
    {
        long RegistrarVenda(Venda venda);
        long RegistrarVendaSumario(VendaSumario sumario);
        void CancelarVenda(long vendaId);
        PaginatedEntity<Venda> ObterHistorico(PaginatedFilter filtro);
       
    }
}
