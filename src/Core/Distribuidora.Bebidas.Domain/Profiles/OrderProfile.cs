using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;
using Distribuidora.Bebidas.Domain.Broker.Producer.Message;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Domain.Profiles
{

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, DeliveryIntegrationMessage>()
                .ForMember(dest => dest.IdOrder, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<Items, ItemsIntegrationMessage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));
        }
    }
}
