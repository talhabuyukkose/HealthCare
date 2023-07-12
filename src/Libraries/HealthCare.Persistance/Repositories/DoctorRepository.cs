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
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(PostgreDbContext context) : base(context)
        {
        }
        private IQueryable<Doctor> GetIncluded()
        {
            return GetEntitiesUnDeleted().Include(x => x.Appointments).Include(x => x.Diseases).Include(x => x.Hospital).Include(x=>x.MedicalUnit);
        }
        public async Task<ICollection<Doctor>> GetFilterIncludedAsync(Expression<Func<Doctor, bool>> expression)
        {
            return await GetIncluded().Where(expression).ToListAsync();
        }

        public async Task<Doctor> GetFindIncludedAsync(Expression<Func<Doctor, bool>> expression)
        {
            return await GetIncluded().SingleAsync(expression);
        }

        public async Task<ICollection<Doctor>> GetIncludedAsync()
        {
            return await GetIncluded().ToListAsync();
        }
    }
}
