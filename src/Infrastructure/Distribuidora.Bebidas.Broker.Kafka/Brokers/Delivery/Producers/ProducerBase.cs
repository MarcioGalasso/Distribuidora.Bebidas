using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Distribuidora.Bebidas.Domain.Broker.Producer;

namespace Distribuidora.Bebidas.Kafka.Brokers.Delivery.Producers
{
    public class ProducerBase : IProducerBase
    {
        private readonly IBusControl _busControl;
        private readonly IServiceProvider _serviceProvider;

        public ProducerBase(IBusControl busControl, IServiceProvider serviceProvider)
        {
            _busControl = busControl;
            _serviceProvider = serviceProvider;
        }

        public async Task ProduceAsync<Tmessage>(Tmessage message) where Tmessage : class
        {
            await _busControl.StartAsync(new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token);
            var producer = _serviceProvider.GetRequiredService<ITopicProducer<Tmessage>>();
            await producer.Produce(message);
        }
    }
}
