using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.Bebidas.Abstract.Repository;
using Distribuidora.Bebidas.Abstract.Services.Base;
using Distribuidora.Bebidas.Domain.Entities;
using Distribuidora.Bebidas.Domain.ViewModel.Order;

namespace Distribuidora.Bebidas.Abstract.Services
{
    public interface IOrderService : IBaseService
    {
        Task<Order> GetAsync(Guid id);
        Task<bool> AddAsync(OrderRequest orderRequest);
    }
}
