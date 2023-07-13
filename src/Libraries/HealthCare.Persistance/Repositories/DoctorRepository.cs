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
        private async Task<IQueryable<Doctor>> IncludedAsync()
        {
            var values = await GetEntitiesUnDeleted();

            return values.Include(x => x.Appointments).Include(x => x.Hospital).Include(x=>x.MedicalUnit);
        }
        public async Task<ICollection<Doctor>> GetListWithFilterIncludedAsync(Expression<Func<Doctor, bool>> expression)
        {
            var values = await IncludedAsync();
            
            return await values.Where(expression).ToListAsync();
        }

        public async Task<Doctor> GetFindIncludedAsync(Expression<Func<Doctor, bool>> expression)
        {
            var values = await IncludedAsync();

            return await values.SingleAsync(expression);
        }

        public async Task<ICollection<Doctor>> GetListIncludedAsync()
        {
            var values = await IncludedAsync();

            return await values.ToListAsync();
        }
    }
}
