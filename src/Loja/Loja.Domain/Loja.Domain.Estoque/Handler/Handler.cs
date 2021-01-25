using Flunt.Notifications;
using Loja.Domain.Estoque.Commands.Input;
using Loja.Domain.Estoque.Entities;
using Loja.Domain.Estoque.Repositories;
using Loja.Domain.Shared.Command;
using Loja.Domain.Shared.Handler;
using System;

namespace Loja.Domain.Estoque.Handler
{
    public class Handler :
            Notifiable,
            IHandler<RegistrarProdutoCommand>,
            IHandler<AtualizarProdutoCommand>,
            IHandler<ApagarProdutoCommand>
    {
        private readonly IProdutoRepository _repo;

        public Handler(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public IGenericCommandResult Handle(RegistrarProdutoCommand command)
        {
            command.Validate();

            if(!command.Valid)
                return new GenericCommandResult(false, "Ops...", command.Notifications);

            var produto = new Produto(command.Descricao, command.Valor);
            
            
            if( _repo.RegistrarProduto(produto) < 1 )
                return new GenericCommandResult(false, "ocorreu um erro ao registrar o produto", produto);


            return new GenericCommandResult(true, "Produto registrado com sucesso", produto);
        }

        public IGenericCommandResult Handle(AtualizarProdutoCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return new GenericCommandResult(false, "Ops...", command.Notifications);


            var produtoEmBanco = _repo.ObterProdutoPorId(command.ProdutoId);

            if(produtoEmBanco is null)
                return new GenericCommandResult(false, "Produto não localizado", command);

            produtoEmBanco.Descricao = command.Descricao;
            produtoEmBanco.Valor = command.Valor;
            produtoEmBanco.DataAtualizacao = DateTime.Now;

            _repo.AtualizarProduto(produtoEmBanco);


            return new GenericCommandResult(true, "Produto atualizado com sucesso", produtoEmBanco);

        }

        public IGenericCommandResult Handle(ApagarProdutoCommand command)
        {
            var produto = _repo.ObterProdutoPorId(command.ProdutoId);

            if (produto is null)
                return new GenericCommandResult(false, "Produto não localizado", command);

            _repo.ApagarProduto(produto);

            return new GenericCommandResult(true, "Produto apagado com sucesso");
        }
    }
}
