using HealthCare.Core.Domain.Entities;
using System.Linq.Expressions;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IMedicalUnitRepository : IBaseRepository<MedicalUnit>
    {
        Task<ICollection<MedicalUnit>> GetListIncludedAsync();
        Task<MedicalUnit> GetFindIncludedAsync(Expression<Func<MedicalUnit, bool>> expression);
        Task<ICollection<MedicalUnit>> GetListWithFilterIncludedAsync(Expression<Func<MedicalUnit, bool>> expression);
    }
}
