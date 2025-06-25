
using FluentAssertions;
using Distribuidora.Bebidas.Domain.Validators;
using Distribuidora.Bebidas.Domain.ViewModel.Order;
using Distribuidora.Bebidas.Domain.Entities;
using AutoMapper;
using Distribuidora.Bebidas.Domain.Profiles;

namespace Distribuidora.Bebidas.Tests.Unitary
{
    public class OrderRequestTest
    {
        private readonly IMapper _mapper;

        public OrderRequestTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<OrderRequestToOrderProfile>();
                
            });

            _mapper = config.CreateMapper();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Order_Must(OrderRequest orderRequest, string messageExpected)
        {
            var order = _mapper.Map<Order>(orderRequest);
            order.GroupItems();

            var validator = new OrderValidator();
            var result = validator.Validate(order);

            if (!string.IsNullOrEmpty(messageExpected))
            {
                result.IsValid.Should().Be(false);
                result.Errors.Should().Contain(c => c.ErrorMessage == messageExpected);
            }
            else
                result.IsValid.Should().Be(true);
           
        }

        public static IEnumerable<object[]> Data =>
          new List<object[]>
          {
                    new object[] { OrderRequestFakeGenerator.GenerateFakeErrorAmount(), Domain.Resources.OrderResource.MinAmountItems},
                    new object[] { OrderRequestFakeGenerator.GenerateFakeSuccess(), ""},
                    new object[] { OrderRequestFakeGenerator.GenerateFakeErrorIdResale(), Domain.Resources.OrderResource.ResaleRequired },
                    new object[] { OrderRequestFakeGenerator.GenerateFakeErrorIdAdress(), Domain.Resources.OrderResource.DeliveryAddressRequired }
          };
         }
}