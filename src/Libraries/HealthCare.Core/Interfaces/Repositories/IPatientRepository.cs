using HealthCare.Core.Domain.Entities;
using System.Linq.Expressions;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<ICollection<Patient>> GetListIncludedAsync();
        Task<Patient> GetFindIncludedAsync(Expression<Func<Patient, bool>> expression);
        Task<ICollection<Patient>> GetListWithFilterIncludedAsync(Expression<Func<Patient, bool>> expression);
    }
}
