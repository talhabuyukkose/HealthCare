using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using HealthCare.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthCare.Persistance.Repositories
{
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(PostgreDbContext context) : base(context)
        {
        }
        private async Task<IQueryable<Hospital>> IncludedAsync()
        {
            var values = await GetEntitiesUnDeleted();

            return values.Include(x => x.Doctors).Include(x => x. HospitalMedicalUnits).ThenInclude(x => x.MedicalUnit).Include(x => x.Appointments);
        }
        public async Task<ICollection<Hospital>> GetListWithFilterIncludedAsync(Expression<Func<Hospital, bool>> expression)
        {
            var values = await IncludedAsync();

            return await values.Where(expression).ToListAsync();
        }

        public async Task<Hospital> GetFindIncludedAsync(Expression<Func<Hospital, bool>> expression)
        {
            var values = await IncludedAsync();

            return await values.SingleAsync(expression);
        }

        public async Task<ICollection<Hospital>> GetListIncludedAsync()
        {
            var values = await IncludedAsync();

            return await values.ToListAsync();
        }
    }
}
