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
    public class DeliveryToPreparationProfile : Profile
    {
        public DeliveryToPreparationProfile()
        {
            CreateMap<DeliveryMessage, PreparationOrderIntegrationMessage>()
                .ForMember(dest => dest.IdOrder,
                           opt => opt.MapFrom(src => src.IdOrder));
        }
    }
}
