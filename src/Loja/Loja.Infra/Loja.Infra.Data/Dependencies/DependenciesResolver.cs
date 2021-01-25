using Loja.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infra.Data.Dependencies
{
    public static class DependenciesResolver
    {
        public static IServiceCollection ResolveConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            string cnnString = configuration.GetConnectionString("DefaultConnection");

            services.AddSingleton(cnnString);

            return services;
        }

        public static IServiceCollection ResolveContext(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddScoped<DataContext, DataContext>(); 
            services.AddDbContext<MigrationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            #region Handlers
                services.AddScoped<Loja.Domain.Estoque.Handler.Handler, Loja.Domain.Estoque.Handler.Handler>();
            #endregion

            return services;
        }
       
    }
}
