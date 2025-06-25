using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Distribuidora.Bebidas.Domain.Entities;
using Distribuidora.Bebidas.Domain.ViewModel.Order;

namespace Distribuidora.Bebidas.Domain.Profiles
{
    public class OrderRequestToOrderProfile : Profile
    {
        public OrderRequestToOrderProfile()
        {
            CreateMap<OrderRequest, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.Resale, opt => opt.Ignore())
                .ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.Request))
                .ForMember(dest => dest.IdResale, opt => opt.MapFrom(src => src.IdResale))
                .ForMember(dest => dest.IdDeliveryAddress, opt => opt.MapFrom(src => src.IdDeliveryAddress));

            CreateMap<ItemsRequest, Items>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.IdOrder, opt => opt.Ignore());
        }
    }
}
