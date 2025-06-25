using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Bebidas.Domain.Entities
{
    public class ResaleRequest
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Name { get; set; }
        public IList<ContactRequest> Contact { get; set; }
        public virtual IList<DeliveryAddressRequest> Address { get; set; }
    }
}
    