using Loja.Domain.Shared.Entities;

namespace Loja.Domain.Estoque.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
