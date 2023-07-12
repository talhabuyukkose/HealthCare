using HealthCare.Core.Domain.Entities;
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
    public class DiseaseRepository : BaseRepository<Disease>, IDiseaseRepository
    {
        public DiseaseRepository(PostgreDbContext context) : base(context)
        {
        }

        private IQueryable<Disease> GetIncluded()
        {
            return GetEntitiesUnDeleted().Include(x => x.Patients);
        }
        public async Task<ICollection<Disease>> GetFilterIncludedAsync(Expression<Func<Disease, bool>> expression)
        {
            return await GetIncluded().Where(expression).ToListAsync();
        }

        public async Task<Disease> GetFindIncludedAsync(Expression<Func<Disease, bool>> expression)
        {
            return await GetIncluded().SingleAsync(expression);
        }

        public async Task<ICollection<Disease>> GetIncludedAsync()
        {
            return await GetIncluded().ToListAsync();
        }
    }
}
