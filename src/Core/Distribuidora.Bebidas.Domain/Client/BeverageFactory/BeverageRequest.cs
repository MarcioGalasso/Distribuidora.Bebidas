using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Bebidas.Domain.Client.BeverageFactory
{
    public class BeverageRequest
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public IList<ItemsBeverage> Items { get; set; }
    }
}
