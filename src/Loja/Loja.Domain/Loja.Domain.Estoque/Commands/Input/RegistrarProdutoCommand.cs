using Flunt.Notifications;
using Flunt.Validations;
using Loja.Domain.Shared.Command.Input;

namespace Loja.Domain.Estoque.Commands.Input
{
    public class RegistrarProdutoCommand : Notifiable, ICommand
    {
        public RegistrarProdutoCommand(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
        }
        public RegistrarProdutoCommand()
        {

        }

        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public void Validate()
        {
            AddNotifications(
                   new Contract()
                       .Requires()
                       .IsNotNullOrEmpty(Descricao, "Descricao", "o campo Descricao é obrigatório")
                       .IsGreaterThan(Valor, 0.00, "Valor", "o campo Valor deve ser maior que 0,00 ")
               );
        }
    }
}
