using Loja.Domain.Estoque.Logistica.Commands.Output;
using Loja.Domain.Estoque.Logistica.Handler;
using Loja.Tests.Estoque.Logistica.Arguments;
using Loja.Tests.Estoque.Logistica.Teste;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loja.Tests.Estoque.Logistica
{
    [TestClass]
    public class FreteTeste
    {
        [TestMethod]
        public void CalcularFreteCEPNaoValido()
        {
            FreteHandler handle = new FreteHandler(ConsultaCEPRepositoryFactory.ObterRepositoryVazio());

            var command = new Loja.Domain.Estoque.Logistica.Commands.Input.ConsultarFreteCommand(CalculaFreteArguments.FreteNaoValido);
            var result = handle.Handle(command);

            Assert.IsTrue(!result.Success);
        }

        [TestMethod]
        public void CalcularFreteEstadoMT()
        {
            FreteHandler handle = new FreteHandler(ConsultaCEPRepositoryFactory.ObterFreteMatoGrosso());

            var command = new Loja.Domain.Estoque.Logistica.Commands.Input.ConsultarFreteCommand(CalculaFreteArguments.CepMatoGrosso);
            var result = handle.Handle(command);

            Assert.IsTrue(((ConsultarFreteCommandResult)result.Data).Valor == CalculaFreteArguments.ValorFreteOutrosEstados);
        }

        [TestMethod]
        public void CalcularFreteCidadeRIO()
        {
            FreteHandler handle = new FreteHandler(ConsultaCEPRepositoryFactory.ObterFreteCidadeEEstadoRioDeJaneiro());

            var command = new Loja.Domain.Estoque.Logistica.Commands.Input.ConsultarFreteCommand(CalculaFreteArguments.CepEstadoECidadeRioDeJaneiro);
            var result = handle.Handle(command);

            Assert.IsTrue(((ConsultarFreteCommandResult)result.Data).Valor == CalculaFreteArguments.ValorFreteCidadeEEstadoRioDeJaneiro);
        }

        [TestMethod]
        public void CalcularFreteOutraCidadeEstadoRIO()
        {
            FreteHandler handle = new FreteHandler(ConsultaCEPRepositoryFactory.ObterFreteSomenteEstadoRioDeJaneiro());

            var command = new Loja.Domain.Estoque.Logistica.Commands.Input.ConsultarFreteCommand(CalculaFreteArguments.CepSomenteEstadoRioDeJaneiro);
            var result = handle.Handle(command);

            Assert.IsTrue(((ConsultarFreteCommandResult)result.Data).Valor == CalculaFreteArguments.ValorFreteSomenteEstadoRioDeJaneiro);
        }
    }
}
