using Loja.Domain.Estoque.Entities;
using Loja.Domain.Estoque.Repositories;
using Loja.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Loja.Infra.Estoque.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Loja.Infra.Data.Context.MigrationContext _context;

        public ProdutoRepository(MigrationContext context)
        {
            _context = context;
        }

        public void ApagarProduto(Produto produto)
        {
            _context.Produto.Remove(produto);
            _context.SaveChanges();
        }

        public Produto AtualizarProduto(Produto produto)
        {
            _context.Produto.Update(produto);
            _context.SaveChanges();

            return produto;
        }

        public Produto ObterProdutoPorId(long id)
        {
            return _context.Produto.Find(id);
        }

        public IEnumerable<Produto> ObterProdutos()
        {
            return _context.Produto.ToList();
        }

        public long RegistrarProduto(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();

            return produto.Id;
        }
    }
}
