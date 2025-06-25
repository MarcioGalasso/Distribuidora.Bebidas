using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Bebidas.Domain.Broker.Producer
{
    public interface IProducerBase 
    {
        Task ProduceAsync<Tmessage>(Tmessage message) where Tmessage : class;
    }
}
