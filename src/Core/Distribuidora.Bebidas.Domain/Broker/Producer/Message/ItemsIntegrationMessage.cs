using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Bebidas.Domain.Entities
{
    public class ItemsIntegrationMessage
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public string SKU { get; set; }
    }
}
