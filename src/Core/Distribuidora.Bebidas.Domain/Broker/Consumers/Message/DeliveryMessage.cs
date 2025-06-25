using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Domain.Broker.Consumers.Message
{
    public class DeliveryMessage
    {
        public Guid IdOrder { get; set; }
        public Guid IdResale { get; set; }
        public IList<ItemsMessage> Items { get; set; }

    }
}
