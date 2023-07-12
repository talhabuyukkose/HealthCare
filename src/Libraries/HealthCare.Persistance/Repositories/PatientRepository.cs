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
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(PostgreDbContext context) : base(context)
        {
        }

        private IQueryable<Patient> GetIncluded()
        {
            return GetEntitiesUnDeleted().Include(x => x.Appointments).Include(x => x.Diseases);
        }
        public async Task<ICollection<Patient>> GetFilterIncludedAsync(Expression<Func<Patient, bool>> expression)
        {
            return await GetIncluded().Where(expression).ToListAsync();
        }

        public async Task<Patient> GetFindIncludedAsync(Expression<Func<Patient, bool>> expression)
        {
            return await GetIncluded().SingleAsync(expression);
        }

        public async Task<ICollection<Patient>> GetIncludedAsync()
        {
            return await GetIncluded().ToListAsync();
        }
    }
}
