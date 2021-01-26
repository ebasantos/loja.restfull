using Loja.Domain.Estoque.Entities;
using Loja.Domain.Shared.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Vendas.Entities
{
    [Dapper.Contrib.Extensions.Table("VendaSumario")]
    public class VendaSumario : Entity
    {
        [ForeignKey(nameof(Venda))]
        public long VendaId { get; set; }
        [ForeignKey("Produto")]
        public long ProdutoId { get; set; }
        public decimal ValorProduto { get; set; }
        public virtual Venda Venda { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}
