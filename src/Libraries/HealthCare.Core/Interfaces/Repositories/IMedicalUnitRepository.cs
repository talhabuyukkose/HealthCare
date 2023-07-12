using HealthCare.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IMedicalUnitRepository : IBaseRepository<MedicalUnit>
    {
        Task<ICollection<MedicalUnit>> GetIncludedAsync();
        Task<MedicalUnit> GetFindIncludedAsync(Expression<Func<MedicalUnit, bool>> expression);
        Task<ICollection<MedicalUnit>> GetFilterIncludedAsync(Expression<Func<MedicalUnit, bool>> expression);
    }
}
