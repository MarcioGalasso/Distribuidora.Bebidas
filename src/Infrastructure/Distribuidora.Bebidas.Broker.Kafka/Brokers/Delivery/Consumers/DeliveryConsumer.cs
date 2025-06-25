using MassTransit;
using Distribuidora.Bebidas.Domain.Broker.Consumers;
using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;

namespace Distribuidora.Bebidas.Kafka.Brokers.Delivery.Consumers
{
    public class DeliveryConsumer : IConsumer<DeliveryMessage>
    {
        private readonly IDeliveryConsumer _deliveryConsumer;

        public DeliveryConsumer(IDeliveryConsumer deliveryConsumer)
        {
            _deliveryConsumer = deliveryConsumer;
        }

        public Task Consume(ConsumeContext<DeliveryMessage> context) => _deliveryConsumer.IntegrationAsync(context.Message);
    }
}
