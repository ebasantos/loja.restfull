using Flunt.Notifications;
using Flunt.Validations;
using Loja.Domain.Shared.Command.Input;

namespace Loja.Domain.Estoque.Commands.Input
{
    public class AtualizarProdutoCommand : Notifiable, ICommand
    {
        public AtualizarProdutoCommand(string descricao, decimal valor, long produtoId)
        {
            Descricao = descricao;
            Valor = valor;
            ProdutoId = produtoId;
        }

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public long ProdutoId { get; set; }

        public void Validate()
        {
            AddNotifications(
                   new Contract()
                       .Requires()
                       .IsNotNullOrEmpty(Descricao, "Descricao", "o campo Descricao é obrigatório")
                       .IsLowerOrEqualsThan(Valor, 0.00, "Valor", "o campo Valor deve ser maior que 0,00 ")
                       .IsLowerOrEqualsThan(ProdutoId, 0, "ProdutoId", "Produto inválido")
               );
        }
    }
}
