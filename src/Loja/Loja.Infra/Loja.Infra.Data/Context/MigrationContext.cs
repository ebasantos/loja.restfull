using Loja.Domain.Estoque.Entities;
using Loja.Domain.Vendas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Data.Context
{
    public class MigrationContext  : DbContext
    {
        public MigrationContext(DbContextOptions<MigrationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaSumario> VendaSumario { get; set; }
    }
}
