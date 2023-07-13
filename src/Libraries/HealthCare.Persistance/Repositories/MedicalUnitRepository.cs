using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using HealthCare.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthCare.Persistance.Repositories
{
    public class MedicalUnitRepository : BaseRepository<MedicalUnit>, IMedicalUnitRepository
    {
        public MedicalUnitRepository(PostgreDbContext context) : base(context)
        {
        }
        private async Task<IQueryable<MedicalUnit>> IncludedAsnyc()
        {
            var values = await GetEntitiesUnDeleted();

            return values.Include(x => x.Appointments).Include(x => x.Doctors).Include(x=>x.HospitalMedicalUnits).ThenInclude(x=>x.Hospital);
        }
        public async Task<ICollection<MedicalUnit>> GetListWithFilterIncludedAsync(Expression<Func<MedicalUnit, bool>> expression)
        {
            var values = await IncludedAsnyc();

            return await values.Where(expression).ToListAsync();
        }

        public async Task<MedicalUnit> GetFindIncludedAsync(Expression<Func<MedicalUnit, bool>> expression)
        {
            var values = await IncludedAsnyc();

            return await values.SingleAsync(expression);
        }

        public async Task<ICollection<MedicalUnit>> GetListIncludedAsync()
        {
            var values = await IncludedAsnyc();

            return await values.ToListAsync();
        }
    }
}
