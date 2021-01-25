using Loja.Domain.Estoque.Logistica.Repositories;
using Loja.Domain.Estoque.Repositories;
using Loja.Infra.Estoque.Logistica;
using Loja.Infra.Estoque.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infra.Estoque.Dependencies
{
    public static class DependenciesResolver
    {

        public static IServiceCollection ResolveRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IConsultaCEPRepository, ConsultaCEPRepository>();
            return services;
        }
    }
}
