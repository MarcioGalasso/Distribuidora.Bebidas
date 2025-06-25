using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Distribuidora.Bebidas.Abstract.Repository.Base;
using Distribuidora.Bebidas.Abstract.Services.Base;
using Distribuidora.Bebidas.Domain.Broker.Consumers;
using Distribuidora.Bebidas.Domain.Broker.Producer;
using Distribuidora.Bebidas.Repository.Postgresql.Context;
using Distribuidora.Bebidas.Domain.Profiles;
using Distribuidora.Bebidas.Kafka.Brokers.Delivery.Producers;
using Distribuidora.Bebidas.Kafka.Brokers.Delivery.Consumers;
using Distribuidora.Bebidas.Abstract.Client;
using Distribuidora.Bebidas.Client;

namespace Distribuidora.Bebidas.DependencyInjector.Configuration
{
    public static class ServicesConfiguration
    {
        private const string Distrubuidora = "Distribuidora.";
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromApplicationDependencies(r => r.FullName.StartsWith(Distrubuidora))
                                      .AddClasses(classes => classes.AssignableToAny(typeof(IBaseService)))
                                      .AsImplementedInterfaces()
                                      .WithScopedLifetime());
                                       
            return services;
        }

        public static IServiceCollection AddClient(this IServiceCollection services)
        {
            services.AddScoped<IBeverageFactoryClient, BeverageFactoryClient>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromApplicationDependencies(r => r.FullName.StartsWith(Distrubuidora))
                                                .AddClasses(classes => classes.AssignableToAny(typeof(IBaseRepostirory<>)))
                                      .AsImplementedInterfaces()
                                      .WithScopedLifetime());
            return services;
        }

        public static IServiceCollection AddConsumers(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryConsumer,DeliveryIntegrationConsumer>();
            services.AddScoped<DeliveryConsumer>();
            return services;
        }
        public static IServiceCollection AddProducers(this IServiceCollection services)
        {
            services.AddScoped<IProducerBase, ProducerBase>();
            return services;
        }

        public static IServiceCollection AddProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(OrderProfile));
            return services;
        }

    }
}
