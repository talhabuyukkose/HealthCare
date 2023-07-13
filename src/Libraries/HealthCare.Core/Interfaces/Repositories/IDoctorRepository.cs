using HealthCare.Core.Domain.Entities;
using System.Linq.Expressions;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<ICollection<Doctor>> GetListIncludedAsync();
        Task<Doctor> GetFindIncludedAsync(Expression<Func<Doctor, bool>> expression);
        Task<ICollection<Doctor>> GetListWithFilterIncludedAsync(Expression<Func<Doctor, bool>> expression);
    }
}
