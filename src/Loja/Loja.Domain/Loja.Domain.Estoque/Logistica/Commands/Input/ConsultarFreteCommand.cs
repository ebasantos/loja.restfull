using Flunt.Notifications;
using Flunt.Validations;
using Loja.Domain.Shared.Command.Input;

namespace Loja.Domain.Estoque.Logistica.Commands.Input
{
    public class ConsultarFreteCommand : Notifiable, ICommand
    {
        public ConsultarFreteCommand(string cep)
        {
            CEP = cep;
        }

        public ConsultarFreteCommand()
        {

        }

        public string CEP { get; set; }

        public void Validate()
        {
            AddNotifications(
                     new Contract()
                         .Requires()
                         .IsNotNullOrEmpty(CEP, "CEP", "CEP inválido")
                 );
        }
    }
}
