using HealthCare.Core.Domain.Common;
using HealthCare.Core.Domain.Enums;
using HealthCare.Core.Interfaces.Repositories;
using HealthCare.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Persistance.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly PostgreDbContext context;
        protected DbSet<T> entities;

        public BaseRepository(PostgreDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        protected IQueryable<T> GetEntitiesUnDeleted()
        {
            return entities.Where(w => w.Status != Status.Deleted);
        }
        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        public async Task AddAsync(T item)
        {
            await entities.AddAsync(item);

            await SaveAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await GetEntitiesUnDeleted().AnyAsync(expression);
        }

        public async Task<int> CountAsync()
        {
            return await GetEntitiesUnDeleted().CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T item = await GetFindAsync(find => find.Id == id);

            item.Status = Status.Deleted;

            item.ModifiedDate = DateTime.UtcNow.AddHours(3);

            entities.Update(item);

            await SaveAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }
        public async Task<ICollection<T>> GetAsync()
        {
            return await GetEntitiesUnDeleted().ToListAsync();
        }
        public async Task<ICollection<T>> GetWithFilterAsync(Expression<Func<T, bool>> expression)
        {
            return await GetEntitiesUnDeleted().Where(expression).ToListAsync();
        }

        public async Task<T> GetFindAsync(Expression<Func<T, bool>> expression)
        {
            return await GetEntitiesUnDeleted().SingleAsync(expression);
        }

        public async Task HardDeleteAsync(int id)
        {
            T? item = await GetFindAsync(find => find.Id == id);

            entities.Remove(item);

            await SaveAsync();
        }

        public async Task<bool> UpdateAsync(T item)
        {
            if (item.Status != Status.Deleted)
            {
                item.Status = Status.Updated;

                item.ModifiedDate = DateTime.UtcNow.AddHours(3);

                Task.Run(() => entities.Update(item));

                await SaveAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ICollection<T>> SelectByLimitAsync(int page, int limit)
        {
            limit = limit == 0 ? 50 : limit;
            limit = limit > 500 ? 500 : limit;

            return await GetEntitiesUnDeleted().Skip(page * limit).Take(limit).OrderBy(order => order.Id).ToListAsync();
        }
    }
}
