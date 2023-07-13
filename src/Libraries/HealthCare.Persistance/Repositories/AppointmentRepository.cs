using HealthCare.Core.Domain.Entities;
using HealthCare.Core.Interfaces.Repositories;
using HealthCare.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthCare.Persistance.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(PostgreDbContext context) : base(context)
        {
        }
        private async Task<IQueryable<Appointment>> IncludedAsync()
        {
            var values = await GetEntitiesUnDeleted();

            return values.Include(x => x.Patient).Include(x => x.Doctor).Include(x => x.MedicalUnit).Include(x => x.Hospital);
        }
        public async Task<ICollection<Appointment>> GetListWithFilterIncludedAsync(Expression<Func<Appointment, bool>> expression)
        {
            var values = await IncludedAsync();

            return await values.Where(expression).ToListAsync();
        }

        public async Task<Appointment> GetFindIncludedAsync(Expression<Func<Appointment, bool>> expression)
        {
            var values = await IncludedAsync();

            return await values.SingleAsync(expression);
        }

        public async Task<ICollection<Appointment>> GetListIncludedAsync()
        {
            var values = await IncludedAsync();

            return await values.ToListAsync();
        }
    }
}
