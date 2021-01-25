using Flunt.Notifications;
using Loja.Domain.Estoque.Logistica.Commands.Input;
using Loja.Domain.Estoque.Logistica.Commands.Output;
using Loja.Domain.Estoque.Logistica.Repositories;
using Loja.Domain.Shared.Command;
using Loja.Domain.Shared.Handler;

namespace Loja.Domain.Estoque.Logistica.Handler
{
    public class FreteHandler :
            Notifiable,
        IHandler<ConsultarFreteCommand>
    {
        private readonly IConsultaCEPRepository _freteRepo;

        public FreteHandler(IConsultaCEPRepository freteRepo)
        {
            _freteRepo = freteRepo;
        }

        public IGenericCommandResult Handle(ConsultarFreteCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return new GenericCommandResult(false, "Ops...", command.Notifications);

            string cep = command.CEP.Replace("-", "").Replace(".", "").Trim();

            var resultado = _freteRepo.ConsultaCEP(cep);

            if (resultado is null)
                return new GenericCommandResult(false, "CEP Inválido", command);

            var result = new Commands.Output.ConsultarFreteCommandResult(command.CEP, CalcularFretePorLocalidade(resultado));

            return new GenericCommandResult(true, "Frete calculado com sucesso!", result);
        }

        private decimal CalcularFretePorLocalidade(ConsultarFreteQueryResult resultado)
        {
            if (resultado.Localidade.Equals("Rio de Janeiro"))
                return 10.00m;
            else if (resultado.Uf.Equals("RJ"))
                return 20.00m;
            else 
                return 40.00m;
        }
    }
}
