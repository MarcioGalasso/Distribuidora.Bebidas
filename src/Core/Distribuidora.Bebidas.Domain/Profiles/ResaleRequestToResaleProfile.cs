using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Domain.Profiles
{
    public class ResaleRequestToResaleProfile : Profile
    {
        public ResaleRequestToResaleProfile()
        {
            CreateMap<ResaleRequest, Resale>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(src => src.RazaoSocial))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<ContactRequest, Contact>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.ResaleId, opt => opt.Ignore());

            CreateMap<DeliveryAddressRequest, DeliveryAddress>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.ResaleId, opt => opt.Ignore());
        }
    }
}
