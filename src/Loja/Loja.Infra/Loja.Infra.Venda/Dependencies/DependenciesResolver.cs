using Loja.Domain.Vendas.Handler;
using Loja.Domain.Vendas.Repositories;
using Loja.Infra.Venda.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infra.Venda.Dependencies
{
    public static class DependenciesResolver
    {
        public static IServiceCollection ResolveRepositories(this IServiceCollection services)
        {
            services.AddScoped<VendaHandler, VendaHandler>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            return services;
        }
    }
}
