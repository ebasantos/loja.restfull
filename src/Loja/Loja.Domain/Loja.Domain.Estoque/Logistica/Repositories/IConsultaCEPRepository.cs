using Loja.Domain.Estoque.Logistica.Commands.Output;

namespace Loja.Domain.Estoque.Logistica.Repositories
{
    public interface IConsultaCEPRepository
    {
        ConsultarFreteQueryResult ConsultaCEP(string cep);
    }
}
