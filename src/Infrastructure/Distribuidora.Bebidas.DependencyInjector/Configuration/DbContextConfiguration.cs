using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Distribuidora.Bebidas.Domain.Options;
using Distribuidora.Bebidas.Repository.Postgresql.Context;

namespace Distribuidora.Bebidas.Repository.Postgresql.Extension
{
    public static class DbContextConfiguration
    {

        public static IServiceCollection ConfigureDistribuidoraContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DistribuidoraContext>(c => c.UseNpgsql(config.GetConnectionString("Distribuidora")));
            return services;
        }

    }
}
