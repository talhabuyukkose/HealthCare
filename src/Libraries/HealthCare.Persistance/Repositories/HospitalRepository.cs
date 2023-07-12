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
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(PostgreDbContext context) : base(context)
        {
        }
        private IQueryable<Hospital> GetIncluded()
        {
            return GetEntitiesUnDeleted().Include(x => x.Doctors).Include(x => x.MedicalUnits).Include(x => x.Appointments);
        }
        public async Task<ICollection<Hospital>> GetFilterIncludedAsync(Expression<Func<Hospital, bool>> expression)
        {
            return await GetIncluded().Where(expression).ToListAsync();
        }

        public async Task<Hospital> GetFindIncludedAsync(Expression<Func<Hospital, bool>> expression)
        {
            return await GetIncluded().SingleAsync(expression);
        }

        public async Task<ICollection<Hospital>> GetIncludedAsync()
        {
            return await GetIncluded().ToListAsync();
        }
    }
}
