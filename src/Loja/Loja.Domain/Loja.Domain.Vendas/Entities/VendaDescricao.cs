using Loja.Domain.Estoque.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Vendas.Entities
{
    public class VendaDescricao
    {
        [ForeignKey(nameof(Venda))]
        public long VendaId { get; set; }
        [ForeignKey("Produto")]
        public long ProdutoId { get; set; }
        public virtual Venda Venda { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}
