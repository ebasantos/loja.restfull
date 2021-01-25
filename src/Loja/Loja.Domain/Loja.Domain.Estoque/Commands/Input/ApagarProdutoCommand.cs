using Flunt.Notifications;
using Flunt.Validations;
using Loja.Domain.Shared.Command.Input;

namespace Loja.Domain.Estoque.Commands.Input
{
    public class ApagarProdutoCommand : Notifiable, ICommand
    {
        public ApagarProdutoCommand(long produtoId)
        {
            ProdutoId = produtoId;
        }

        public ApagarProdutoCommand()
        {

        }

        public long ProdutoId { get; set; }

        public void Validate()
        {
            AddNotifications(
                   new Contract()
                       .Requires() 
                       .IsGreaterThan(ProdutoId, 0, "ProdutoId", "Produto inválido")
               );
        }
    }
}
