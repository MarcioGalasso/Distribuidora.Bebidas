
using System.Net.Sockets;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;
using Distribuidora.Bebidas.Domain.Broker.Producer.Message;
using Distribuidora.Bebidas.Domain.Options;
using Distribuidora.Bebidas.Kafka.Brokers.Delivery.Consumers;

namespace Distribuidora.Bebidas.DependencyInjector.Configuration
{
    public static class KafkaConfiguration
    {

        public static IServiceCollection AddKafka(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.UsingInMemory();

                x.AddRider(rider =>
               {
                   var build = x.BuildServiceProvider();
                   var option = build.GetService<IOptions<DistribuidoraKafkaOption>>()?.Value;
                   
                   rider.AddConsumer<DeliveryConsumer>();

                   rider.AddProducer<RetryDeliveryIntegrationMessage>(option.TopicConsumerRetryDelivery);
                   rider.AddProducer<PreparationOrderIntegrationMessage>(option.TopicConsumerPreparationOrder);
                   rider.AddProducer<DeliveryIntegrationMessage>(option.TopicConsumerName);
                   rider.UsingKafka((context, k) =>
                    {
                        k.Host($"{option.Host}:{option.Port}");
                        k.TopicEndpoint<DeliveryMessage>(option.TopicConsumerName, option.GroupName, e =>
                        {
                            e.ConfigureConsumer<DeliveryConsumer>(context);
                        });
                    });
                });


            });
            return services;
        }
    }
}

