using Loja.Domain.Estoque.Logistica.Commands.Output;
using Loja.Domain.Estoque.Logistica.Repositories;
using RestSharp;

namespace Loja.Infra.Estoque.Logistica
{
    public class ConsultaCEPRepository : IConsultaCEPRepository
    {
        public ConsultarFreteQueryResult ConsultaCEP(string cep)
        {
            var client = new RestClient(string.Concat("https://viacep.com.br/ws/", cep, "/json"));
            var request = new RestRequest(Method.GET);
            return client.Execute<ConsultarFreteQueryResult>(request).Data;
        }
    }
}
