using Loja.Domain.Shared.Entities;
using Loja.Domain.Vendas.Entities.Enum;

namespace Loja.Domain.Vendas.Entities
{
    public class Venda : Entity
    {
        public long ClienteId { get; set; } 
        public StatusVenda Status { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorProduto { get; set; }
    }
}
