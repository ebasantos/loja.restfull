using Loja.Domain.Estoque.Logistica.Repositories;
using Moq;

namespace Loja.Tests.Estoque.Logistica.Teste
{
    public static class ConsultaCEPRepositoryFactory
    {
        public static IConsultaCEPRepository ObterRepositoryVazio()
        {
            Mock<IConsultaCEPRepository> mock = new Mock<IConsultaCEPRepository>();
            return (IConsultaCEPRepository)mock.Object;
        }

        public static IConsultaCEPRepository ObterFreteMatoGrosso()
        {
            Mock<IConsultaCEPRepository> mock = new Mock<IConsultaCEPRepository>();
            mock.Setup(m => m.ConsultaCEP("78110610")).Returns(new Domain.Estoque.Logistica.Commands.Output.ConsultarFreteQueryResult
            {
                Bairro = "Centro-Norte",
                Cep = "78110610",
                Complemento = "Centro",
                DDD = 65,
                Localidade = "Varzea Grande",
                Uf = "MT"
            });

            return (IConsultaCEPRepository)mock.Object;
        }


        public static IConsultaCEPRepository ObterFreteCidadeEEstadoRioDeJaneiro()
        {
            Mock<IConsultaCEPRepository> mock = new Mock<IConsultaCEPRepository>();
            mock.Setup(m => m.ConsultaCEP("22441020")).Returns(new Domain.Estoque.Logistica.Commands.Output.ConsultarFreteQueryResult
            {
                Bairro = "Leblon",
                Localidade = "Rio de Janeiro",
                Cep = "22441020",
                Complemento = "Rua Leblon",
                DDD = 21,
                Uf = "RJ"
            });

            return  (IConsultaCEPRepository)mock.Object;
        }

        public static IConsultaCEPRepository ObterFreteSomenteEstadoRioDeJaneiro()
        {
            Mock<IConsultaCEPRepository> mock = new Mock<IConsultaCEPRepository>();
            mock.Setup(m => m.ConsultaCEP("28950000")).Returns(new Domain.Estoque.Logistica.Commands.Output.ConsultarFreteQueryResult
            {
                Bairro = "Armacao dos Buzios",
                Localidade = "Armacao Dos Buzios",
                Cep = "28950000",
                Complemento = "Rua 22",
                Uf = "RJ"
            });

            return  (IConsultaCEPRepository)mock.Object;
        }
    }
}
