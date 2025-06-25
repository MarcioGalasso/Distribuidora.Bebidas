using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Bebidas.Domain.ViewModel.Order
{
    public class ItemsRequest
    {
        public string Description { get; set; }
        public int Amount { get; set; }
        public string SKU { get; set; }
    }
}
