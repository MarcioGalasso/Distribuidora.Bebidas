using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Bebidas.Domain.Broker.Producer.Message
{
    public class PreparationOrderIntegrationMessage
    {
        public Guid IdOrder { get; set; }
    }
}
