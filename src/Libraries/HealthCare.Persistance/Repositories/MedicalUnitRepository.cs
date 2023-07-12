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
    public class MedicalUnitRepository : BaseRepository<MedicalUnit>, IMedicalUnitRepository
    {
        public MedicalUnitRepository(PostgreDbContext context) : base(context)
        {
        }
        private IQueryable<MedicalUnit> GetIncluded()
        {
            return GetEntitiesUnDeleted().Include(x => x.Appointments).Include(x => x.Doctors).Include(x=>x.Hospitals);
        }
        public async Task<ICollection<MedicalUnit>> GetFilterIncludedAsync(Expression<Func<MedicalUnit, bool>> expression)
        {
            return await GetIncluded().Where(expression).ToListAsync();
        }

        public async Task<MedicalUnit> GetFindIncludedAsync(Expression<Func<MedicalUnit, bool>> expression)
        {
            return await GetIncluded().SingleAsync(expression);
        }

        public async Task<ICollection<MedicalUnit>> GetIncludedAsync()
        {
            return await GetIncluded().ToListAsync();
        }
    }
}
