using Loja.Domain.Shared.Entities;
using Loja.Domain.Vendas.Entities.Enum;

namespace Loja.Domain.Vendas.Entities
{
    public class Venda : Entity
    {
        public long ClienteId { get; set; } 
        public StatusVenda Status { get; set; }
    }
}
