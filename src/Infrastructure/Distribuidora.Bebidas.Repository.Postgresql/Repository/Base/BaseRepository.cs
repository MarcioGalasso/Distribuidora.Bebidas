using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Distribuidora.Bebidas.Abstract.Repository.Base;

namespace Distribuidora.Bebidas.Repository.Postgresql.Repository.Base
{
    public class BaseRepository<TEntitie> : IBaseRepostirory<TEntitie> where TEntitie : class
    {
        protected readonly DbContext DatabaseContext;

        protected BaseRepository(DbContext context)
        {
            DatabaseContext = context;
        }
        public virtual async Task<bool> AddAsync(TEntitie entity)
        {
            await DatabaseContext.Set<TEntitie>().AddAsync(entity);
            var returnValue = DatabaseContext.SaveChanges();
            return returnValue > 0;
        }

        public virtual async Task<bool> AddRangeAsync(List<TEntitie> models)
        {
            if (models.Count <= 0)
                return false;

            await DatabaseContext.Set<TEntitie>().AddRangeAsync(models);
            var returnValue = DatabaseContext.SaveChanges();
            return returnValue > 0;
        }

        public virtual async Task<TEntitie> GetAsync(Guid id)
        {
            return await DatabaseContext.Set<TEntitie>().FindAsync(id);
        }

        public virtual async Task<bool> UpdateAsync(TEntitie entity)
        {
            DatabaseContext.Set<TEntitie>().Update(entity);
            var returnValue = DatabaseContext.SaveChanges();
            await Task.CompletedTask;
            return returnValue > 0;
        }

        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<TEntitie> entities)
        {
            DatabaseContext.Set<TEntitie>().UpdateRange(entities);
            var returnValue = DatabaseContext.SaveChanges();
            await Task.CompletedTask;
            return returnValue > 0;
        }

        public virtual async Task<IEnumerable<TEntitie>> GetAllAsync(Func<IQueryable<TEntitie>, IQueryable<TEntitie>> func)
        {
            var dbSet = DatabaseContext.Set<TEntitie>();

            if (func != null)
            {
                return await func(dbSet)
                    .ToListAsync();
            }

            return await dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntitie>> GetAllAsync()
        {
            return await DatabaseContext.Set<TEntitie>()
                .ToListAsync();
        }

        public virtual async Task<bool> RemoveByIdAsync(Guid id)
        {
            var existingEntity = DatabaseContext.Set<TEntitie>().FindAsync(id);
            DatabaseContext.Remove(existingEntity);
            var returnValue = DatabaseContext.SaveChanges();
            await Task.CompletedTask;
            return returnValue > 0;
        }

        public virtual async Task<bool> RemoveRangeAsync(IEnumerable<TEntitie> entities)
        {
            DatabaseContext.RemoveRange(entities);
            var returnValue = await DatabaseContext.SaveChangesAsync();

            return returnValue > 0;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await DatabaseContext.Database.BeginTransactionAsync();
        }

    
    }
}