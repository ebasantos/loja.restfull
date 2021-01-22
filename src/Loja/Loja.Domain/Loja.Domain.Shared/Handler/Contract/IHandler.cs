using Loja.Domain.Shared.Command;
using Loja.Domain.Shared.Command.Input;

namespace Loja.Domain.Shared.Handler
{
    public interface IHandler<T> where T : ICommand
    {
        IGenericCommandResult Handle(T command);
    }
}
