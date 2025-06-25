using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;
using Distribuidora.Bebidas.Domain.Broker.Producer.Message;

namespace Distribuidora.Bebidas.Domain.Profiles
{
    public class DeliveryToRetryProfile : Profile
    {
        public DeliveryToRetryProfile()
        {
            CreateMap<DeliveryMessage, RetryDeliveryIntegrationMessage>()
                .ForMember(dest => dest.IdOrder, opt => opt.MapFrom(src => src.IdOrder))
                .ForMember(dest => dest.IdResale, opt => opt.MapFrom(src => src.IdResale))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
