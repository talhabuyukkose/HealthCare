using HealthCare.Core.Domain.Common;
using HealthCare.Core.Domain.Enums;
using HealthCare.Core.Exceptions;
using HealthCare.Core.Interfaces.Repositories;
using HealthCare.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;

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

        protected async Task<IQueryable<T>> GetEntitiesUnDeleted()
        {
            try
            {
                var entity = entities.Where(w => w.Status != Status.Deleted);

                if (await entity.CountAsync() == 0)
                {
                    throw new DbNotFoundException($"{nameof(T)} has not value or exist an exception.");
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("BaseRepository", ex);
            }
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

        public async Task AddRangeAsync(ICollection<T> item)
        {
            await entities.AddRangeAsync(item);

            await SaveAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            var values = await GetEntitiesUnDeleted();

            return await values.AnyAsync(expression);
        }

        public async Task<int> CountAsync()
        {
            var values = await GetEntitiesUnDeleted();

            return await values.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T item = await GetFindAsync(find => find.Id == id);

            item.Status = Status.Deleted;

            item.ModifiedDate = DateTime.UtcNow.AddHours(3);

            entities.Update(item);

            await SaveAsync();
        }

        public async Task<ICollection<T>> GetListWithDeletedAsync()
        {
            if (await entities.AnyAsync<T>())
            {
                throw new DbNotFoundException($"{nameof(T)} has not value or exist an exception.");
            }
            return await entities.ToListAsync();
        }
        public async Task<ICollection<T>> GetListAsync()
        {
            var values = await GetEntitiesUnDeleted();

            return await values.ToListAsync();
        }
        public async Task<ICollection<T>> GetWithFilterAsync(Expression<Func<T, bool>> expression)
        {
            var values = await GetEntitiesUnDeleted();

            return await values.Where(expression).ToListAsync();
        }

        public async Task<T> GetFindAsync(Expression<Func<T, bool>> expression)
        {
            var values = await GetEntitiesUnDeleted();
            return await values.SingleAsync(expression);
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

            var values = await GetEntitiesUnDeleted();

            return await values.Skip(page * limit).Take(limit).OrderBy(order => order.Id).ToListAsync();
        }
    }
}
