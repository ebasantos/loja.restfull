using Loja.Domain.Estoque.Entities;
using Loja.Domain.Shared.Entities;
using Loja.Domain.Vendas.Entities.Enum;
using System.Collections;
using System.Collections.Generic;

namespace Loja.Domain.Vendas.Entities
{
    public class Venda : Entity
    {
        public string CodigoCliente { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        public StatusVenda Status { get; set; }
    }
}
