using Loja.Domain.Estoque.Entities;
using System.Collections.Generic;

namespace Loja.Domain.Estoque.Repositories
{
    public interface IProdutoRepository
    {
        long RegistrarProduto(Produto produto);
        Produto AtualizarProduto(Produto produto);
        IEnumerable<Produto> ObterProdutos();
        Produto ObterProdutoPorId(long id);
        void ApagarProduto(Produto produto);
    }
}
