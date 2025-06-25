using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distribuidora.Bebidas.Abstract.Repository;
using Distribuidora.Bebidas.Abstract.Services.Base;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Abstract.Services
{
    public interface IResaleService : IBaseService
    {
        Task<Resale> GetAsync(Guid id);
        Task<bool> AddAsync(ResaleRequest cnpjRecords);
    }
}
