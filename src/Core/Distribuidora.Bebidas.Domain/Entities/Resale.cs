using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Bebidas.Domain.Entities
{
    public class Resale
    {
        public Guid Id { get; set; }    
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Name { get; set; }
        public virtual IList<Contact> Contact { get; set; }
        public virtual IList<DeliveryAddress> Address { get; set; }
    }
}
