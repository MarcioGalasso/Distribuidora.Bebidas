using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.Bebidas.Domain.Entities;
using Distribuidora.Bebidas.Domain.Enum;

namespace Distribuidora.Bebidas.Domain.ViewModel.Order
{
    public class OrderRequest
    {
        public DateTime Request { get; set; }
        public Guid IdResale { get; set; }
        public Guid IdDeliveryAddress { get; set; }
        public IList<ItemsRequest> Items { get; set; }
    }
}
