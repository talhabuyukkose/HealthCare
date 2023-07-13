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

        private async Task<IQueryable<Patient>> IncludedAsync()
        {
            var values = await GetEntitiesUnDeleted();

            return values.Include(x => x.Appointments);
        }
        public async Task<ICollection<Patient>> GetListWithFilterIncludedAsync(Expression<Func<Patient, bool>> expression)
        {
            var values = await IncludedAsync();

            return await values.Where(expression).ToListAsync();
        }

        public async Task<Patient> GetFindIncludedAsync(Expression<Func<Patient, bool>> expression)
        {
            var values = await IncludedAsync();

            return await values.SingleAsync(expression);
        }

        public async Task<ICollection<Patient>> GetListIncludedAsync()
        {
            var values = await IncludedAsync();

            return await values.ToListAsync();
        }
    }
}
