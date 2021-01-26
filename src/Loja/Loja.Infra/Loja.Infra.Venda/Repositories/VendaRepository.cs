using Dapper;
using Dapper.Contrib.Extensions;
using Loja.Domain.Shared.Entities;
using Loja.Domain.Shared.Entities.Filters;
using Loja.Domain.Vendas.Entities;
using Loja.Domain.Vendas.Repositories;
using Loja.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Loja.Infra.Venda.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;
        private SqlTransaction _transacton;

        public VendaRepository(DataContext context)
        {
            _context = context;
        }

        public void CancelarVenda(long vendaId)
        {
            _context.Connection.Execute("UPDATE Venda set Status = 4 where Id = @vendaId", new { vendaId });
        }

        public PaginatedEntity<Domain.Vendas.Entities.Venda> ObterHistorico(PaginatedFilter filtro)
        {
            var lookup = new Dictionary<long, Domain.Vendas.Entities.Venda>();
            var result = new PaginatedEntity<Domain.Vendas.Entities.Venda>
            {
                Limits = filtro.Limit,
                OffSet = filtro.Offset
            };

            result.Result = _context.Connection.Query<Domain.Vendas.Entities.Venda, VendaSumario, Domain.Vendas.Entities.Venda>
                ($@"select t0.*, t2.*  
                   from Venda t0 
                   inner join VendaSumario t2 on t0.Id = t2.VendaId
                   order by t0.DataCadastro
                   OFFSET {filtro.Offset} ROWS FETCH NEXT {filtro.Limit} ROWS ONLY  ", (s, a) =>
                 {
                     Domain.Vendas.Entities.Venda Venda;
                     if (!lookup.TryGetValue(s.Id, out Venda))
                     {
                         lookup.Add(s.Id, Venda = s);
                     }
                     if (Venda.VendaSumario == null)
                         Venda.VendaSumario = new List<VendaSumario>();
                     Venda.VendaSumario.Add(a);
                     return Venda;
                 });

            return result;
        }

        public long RegistrarVenda(Domain.Vendas.Entities.Venda venda)
        {
            return _context.Connection.ExecuteScalar<long>(@"INSERT INTO Venda(ClienteId, Status, ValorTotal, ValorFrete, ValorProduto, DataCadastro)
                                                            VALUES (@ClienteId, @Status, @ValorTotal, @ValorFrete, @ValorProduto, @DataCadastro);
                                                            select SCOPE_IDENTITY() ", new
            {
                venda.ClienteId,
                Status = (long)venda.Status,
                venda.ValorTotal,
                venda.ValorFrete,
                venda.ValorProduto,
                venda.DataCadastro
            }, transaction: _transacton);
        }

        public long RegistrarVendaSumario(VendaSumario sumario)
        {
            return _context.Connection.ExecuteScalar<long>(@"INSERT INTO VendaSumario(VendaId, ProdutoId, ValorProduto, DataCadastro)
                                                            VALUES (@VendaId, @ProdutoId, @ValorProduto, @DataCadastro);
                                                            select SCOPE_IDENTITY() ", new
            {
                sumario.DataCadastro,
                sumario.VendaId,
                sumario.ProdutoId,
                sumario.ValorProduto
            }, transaction: _transacton);
        }


        public void AbrirTransacao()
        {
            _transacton = _context.Connection.BeginTransaction("VendaTransaction");
        }

        public void Commit()
        {
            _transacton.Commit();
        }

        public void RollBack()
        {
            _transacton.Rollback();
        }
    }
}
