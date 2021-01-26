using Flunt.Notifications;
using Loja.Domain.Estoque.Logistica.Commands.Output;
using Loja.Domain.Estoque.Logistica.Handler;
using Loja.Domain.Estoque.Repositories;
using Loja.Domain.Shared.Command;
using Loja.Domain.Shared.Handler;
using Loja.Domain.Vendas.Commands;
using Loja.Domain.Vendas.Entities;
using Loja.Domain.Vendas.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Loja.Domain.Vendas.Handler
{
    public class VendaHandler :
            Notifiable,
        IHandler<RegistrarVendaCommand>
    {
        private readonly IProdutoRepository _produtosRepo;
        private readonly IVendaRepository _vendasRepo;
        private readonly FreteHandler _freteHandle;

        public VendaHandler(IProdutoRepository produtosRepo, IVendaRepository vendasRepo, FreteHandler freteHandle)
        {
            _produtosRepo = produtosRepo;
            _vendasRepo = vendasRepo;
            _freteHandle = freteHandle;
        }

        public IGenericCommandResult Handle(RegistrarVendaCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return new GenericCommandResult(false, "Ops...", command.Notifications);

            decimal valorFrete = ObterValorFrete(command.CEPEntrega);

            if (valorFrete < 10)
                return new GenericCommandResult(false, "Cep Inválido", "CEP");


            decimal valorProdutos = 0m;
            Dictionary<long, decimal> produtoPreco = new Dictionary<long, decimal>();

            command.Produtos.ToList().ForEach(id =>
            {
                var produto = _produtosRepo.ObterProdutoPorId(id);

                if (produto != null)
                {
                    valorProdutos += produto.Valor;
                    produtoPreco.Add(produto.Id, produto.Valor);
                }
            });

            if (valorProdutos < 1)
                return new GenericCommandResult(false, "Produtos Inválidos", "Produtos");

            GenericCommandResult result = new GenericCommandResult(true, "Venda inserida com sucesso", command);

            try
            {
                _vendasRepo.AbrirTransacao();

                var venda = new Venda(command.ClienteId, Entities.Enum.StatusVenda.EmAnalise,
                                                            valorProdutos + valorFrete,
                                                            valorFrete, valorProdutos);

                var vendaId = _vendasRepo.RegistrarVenda(venda);

                if (vendaId == 0)
                    return new GenericCommandResult(false, "Ocorreu um erro ao tentar registar a venda", command);

                List<VendaSumario> sumarioList = new List<VendaSumario>();

                foreach (var item in produtoPreco.ToList())
                {
                    var sumario = new VendaSumario
                    {
                        ProdutoId = item.Key,
                        ValorProduto = item.Value,
                        VendaId = vendaId
                    };

                    var sumarioId = _vendasRepo.RegistrarVendaSumario(sumario);

                    if (sumarioId < 1)
                    {
                        result = new GenericCommandResult(false, "Ocorreu um erro ao processar um item da lista", new { produtoId = item.Key });
                        break;
                    }

                    sumarioList.Add(sumario);
                };

                if (result.Success)
                {
                    _vendasRepo.Commit();
                    venda.VendaSumario = sumarioList;
                    result.Data = venda;
                }
                else
                    _vendasRepo.RollBack();
            }
            catch (System.Exception ex)
            {
                _vendasRepo.RollBack();
                return new GenericCommandResult(false, "Ocorreu um erro ao processar esta venda ", new { erro = ex.Message });
            }

            return result;
        }

        private decimal ObterValorFrete(string cep)
        {
            var result = _freteHandle.Handle(new Estoque.Logistica.Commands.Input.ConsultarFreteCommand(cep));
            return !result.Success ? 0m : ((ConsultarFreteCommandResult)result.Data).Valor;
        }
    }
}
