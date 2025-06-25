using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Distribuidora.Bebidas.Domain.Broker.Consumers.Message;
using Distribuidora.Bebidas.Domain.Client.BeverageFactory;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Domain.Profiles
{
    public class OrderToBeverageProfile : Profile
    {
        public OrderToBeverageProfile()
        {
            CreateMap<Order, BeverageRequest>()
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Resale.Cnpj))
                .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(src => src.Resale.RazaoSocial))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Resale.Name))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src =>
                    src.Resale.Address.FirstOrDefault(a => a.Id == src.IdDeliveryAddress).Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src =>
                    src.Resale.Address.FirstOrDefault(a => a.Id == src.IdDeliveryAddress).City))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src =>
                    src.Resale.Address.FirstOrDefault(a => a.Id == src.IdDeliveryAddress).ZipCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src =>
                    src.Resale.Address.FirstOrDefault(a => a.Id == src.IdDeliveryAddress).Country))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<Items, ItemsBeverage>()
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.SKU))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.ToString()));
        }
    }
}
