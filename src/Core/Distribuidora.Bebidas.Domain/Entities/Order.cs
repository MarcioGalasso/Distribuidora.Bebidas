using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.Bebidas.Domain.Enum;

namespace Distribuidora.Bebidas.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime Request { get; set; }
        public OrderStatusEnum Status { get; private set; } = OrderStatusEnum.Pending;
        public IList<Items> Items { get; set; }

        public Guid IdResale { get; set; }
        public Resale Resale { get; set; }

        public Guid IdDeliveryAddress { get; set; }
        public void GroupItems()
        {
            Items = Items.GroupBy(x => x.SKU)
                .Select(c => new Items
                {
                    SKU = c.Key,
                    Description = c.First().Description,
                    Amount = c.Sum(t => t.Amount)
                })
                .ToList();
        }

        public void NextStatus()
        {
            switch (Status)
            {
                case OrderStatusEnum.Pending:
                    Status = OrderStatusEnum.Preparation;
                    break;
                case OrderStatusEnum.Preparation:
                    Status = OrderStatusEnum.InTransit;
                    break;
                case OrderStatusEnum.InTransit:
                    Status = OrderStatusEnum.Delivered;
                    break;
            }
        }

        public void Cancel()
        {
            Status = OrderStatusEnum.Canceled;
        }
    }
}
