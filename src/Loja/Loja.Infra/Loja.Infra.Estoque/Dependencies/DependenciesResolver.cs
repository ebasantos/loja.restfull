using Loja.Domain.Estoque.Repositories;
using Loja.Infra.Estoque.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infra.Estoque.Dependencies
{
    public static class DependenciesResolver
    {

        public static IServiceCollection ResolveRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
