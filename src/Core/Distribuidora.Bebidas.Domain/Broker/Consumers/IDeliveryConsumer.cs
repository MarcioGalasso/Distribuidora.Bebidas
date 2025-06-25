using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;

namespace Distribuidora.Bebidas.Domain.Broker.Consumers
{
    public interface IDeliveryConsumer
    {
        Task IntegrationAsync(DeliveryMessage message);
    }
}
