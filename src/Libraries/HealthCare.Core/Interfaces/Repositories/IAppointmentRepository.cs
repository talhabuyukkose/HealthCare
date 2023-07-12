using HealthCare.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Task<ICollection<Appointment>> GetIncludedAsync();
        Task<Appointment> GetFindIncludedAsync(Expression<Func<Appointment, bool>> expression);
        Task<ICollection<Appointment>> GetFilterIncludedAsync(Expression<Func<Appointment, bool>> expression);
    }
}
