using System.Text.RegularExpressions;
using FluentValidation;
using MassTransit;
using Distribuidora.Bebidas.Abstract.Services;
using Distribuidora.Bebidas.Domain.Broker.Consumers;
using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;
using Distribuidora.Bebidas.Domain.Broker.Producer;
using Distribuidora.Bebidas.Domain.Entities;
using Distribuidora.Bebidas.Abstract.Client;
using AutoMapper;
using Distribuidora.Bebidas.Domain.Client.BeverageFactory;
using Distribuidora.Bebidas.Domain.Broker.Producer.Message;
using Distribuidora.Bebidas.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
namespace Distribuidora.Bebidas.Kafka.Brokers.Delivery.Consumers
{
    public class DeliveryIntegrationConsumer : IDeliveryConsumer
    {
        private readonly IMapper _mapper;
        private readonly IBeverageFactoryClient _beverageFactoryClient;
        public readonly IProducerBase _producerBase;
        private readonly IOrderRepository _orderRepository;

        public DeliveryIntegrationConsumer(IMapper mapper, IBeverageFactoryClient beverageFactoryClient, IProducerBase producerBase, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _beverageFactoryClient = beverageFactoryClient;
            _producerBase = producerBase;
            _orderRepository = orderRepository;
        }



        public async Task IntegrationAsync(DeliveryMessage message)
        {
            var order = (await _orderRepository.GetAllAsync(c => c.Include(t => t.Items).Include(t => t.Resale).Where(c => c.Id == message.IdOrder))).FirstOrDefault(); 
            var beverageRequest = _mapper.Map<BeverageRequest>(order);

            var integration = await _beverageFactoryClient.RequestOrder(beverageRequest);
            
            if(integration.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await PostEventRetryRequestDelivery(message);
                return;
            }

            order.NextStatus();
            await _orderRepository.UpdateAsync(order);
            await PostEventPreparationItemsDelivery(message);
        }

        private async Task PostEventRetryRequestDelivery(DeliveryMessage message) 
        {
            var retryDelivery = _mapper.Map<RetryDeliveryIntegrationMessage>(message);
            await _producerBase.ProduceAsync(retryDelivery);

        }

        private async Task PostEventPreparationItemsDelivery(DeliveryMessage message)
        {
            var preparationDelivery = _mapper.Map<PreparationOrderIntegrationMessage>(message);
            await _producerBase.ProduceAsync(preparationDelivery);

        }
    }
}
