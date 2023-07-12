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
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(PostgreDbContext context) : base(context)
        {
        }
        private IQueryable<Appointment> GetIncluded()
        {
            return GetEntitiesUnDeleted().Include(x => x.Patient).Include(x => x.Doctor).Include(x => x.MedicalUnit).Include(x => x.Hospital);
        }
        public async Task<ICollection<Appointment>> GetFilterIncludedAsync(Expression<Func<Appointment, bool>> expression)
        {
            return await GetIncluded().Where(expression).ToListAsync();
        }

        public async Task<Appointment> GetFindIncludedAsync(Expression<Func<Appointment, bool>> expression)
        {
            return await GetIncluded().SingleAsync(expression);
        }

        public async Task<ICollection<Appointment>> GetIncludedAsync()
        {
            return await GetIncluded().ToListAsync();
        }
    }
}
