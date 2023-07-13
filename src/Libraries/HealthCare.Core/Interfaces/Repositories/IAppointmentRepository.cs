using HealthCare.Core.Domain.Entities;
using System.Linq.Expressions;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Task<ICollection<Appointment>> GetListIncludedAsync();
        Task<Appointment> GetFindIncludedAsync(Expression<Func<Appointment, bool>> expression);
        Task<ICollection<Appointment>> GetListWithFilterIncludedAsync(Expression<Func<Appointment, bool>> expression);
    }
}
