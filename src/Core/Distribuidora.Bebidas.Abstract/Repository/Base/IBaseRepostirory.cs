using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Distribuidora.Bebidas.Abstract.Repository.Base
{
    public interface IBaseRepostirory<TEntitie> where TEntitie : class
    {
        Task<TEntitie> GetAsync(Guid id);
        Task<IEnumerable<TEntitie>> GetAllAsync(Func<IQueryable<TEntitie>, IQueryable<TEntitie>> func);
        Task<IEnumerable<TEntitie>> GetAllAsync();
        Task<bool> AddAsync(TEntitie entity);
        Task<bool> AddRangeAsync(List<TEntitie> models);
        Task<bool> UpdateAsync(TEntitie entity);
        Task<bool> UpdateRangeAsync(IEnumerable<TEntitie> entities);
        Task<bool> RemoveByIdAsync(Guid id);
        Task<bool> RemoveRangeAsync(IEnumerable<TEntitie> entities);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
