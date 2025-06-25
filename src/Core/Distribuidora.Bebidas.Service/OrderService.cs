
using AutoMapper;
using Distribuidora.Bebidas.Abstract.Repository;
using Distribuidora.Bebidas.Abstract.Services;
using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;
using Distribuidora.Bebidas.Domain.Broker.Producer;
using Distribuidora.Bebidas.Domain.Broker.Producer.Message;
using Distribuidora.Bebidas.Domain.Entities;
using Distribuidora.Bebidas.Domain.ViewModel.Order;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Distribuidora.Bebidas.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProducerBase _producerBase;
        private readonly IMapper _mapper;
        private readonly IValidator<Order> _validator;

        public OrderService(IOrderRepository orderRepository, IProducerBase producerBase, IMapper mapper, IValidator<Order> validator)
        {
            _orderRepository = orderRepository;
            _producerBase = producerBase;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> AddAsync(OrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);
            order.GroupItems();

            ValidateOrder(order);

            if (await _orderRepository.AddAsync(order))
            {
                await SeparationForDelivery(order);
                return true;
            }
            return false;
        }

        private void ValidateOrder(Order order)
        {
            var result = _validator.Validate(order);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

        }

        public async Task<Order> GetAsync(Guid id) => (await _orderRepository.GetAllAsync(c => c.Include(t => t.Resale.Contact).Include(t => t.Resale.Address).Include(t => t.Items).Where(t => t.Id == id))).FirstOrDefault();

        private async Task SeparationForDelivery(Order order)
        {
            var orderMessage = _mapper.Map<DeliveryIntegrationMessage>(order);
            await _producerBase.ProduceAsync(orderMessage);

        }
    }
}
