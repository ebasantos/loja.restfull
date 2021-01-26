using Loja.Domain.Estoque.Logistica.Commands.Output;
using Loja.Domain.Estoque.Logistica.Handler;
using Loja.Domain.Estoque.Logistica.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Loja.Tests.Estoque.Logistica
{
    [TestClass]
    public class FreteTeste
    {
        [TestMethod]
        public void CalcularFreteCEPNaoValido()
        {
            #region CONFIG
            Mock<IConsultaCEPRepository> mock = new Mock<IConsultaCEPRepository>(); 
            IConsultaCEPRepository repo = (IConsultaCEPRepository)mock.Object;
            FreteHandler handle = new FreteHandler(repo);
            #endregion

            var command = new Loja.Domain.Estoque.Logistica.Commands.Input.ConsultarFreteCommand("cep nao valido");
            var result = handle.Handle(command);

            Assert.IsTrue(result.Success == false);
        }


        [TestMethod]
        public void CalcularFreteEstadoMT()
        {
            #region CONFIG
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
            IConsultaCEPRepository repo = (IConsultaCEPRepository)mock.Object;
            FreteHandler handle = new FreteHandler(repo);
            #endregion

            var command = new Loja.Domain.Estoque.Logistica.Commands.Input.ConsultarFreteCommand("78110610");
            var result = handle.Handle(command);

            Assert.IsTrue(((ConsultarFreteCommandResult)result.Data).Valor == 40.00M);
        }

    }
}
