using HealthCare.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<ICollection<Doctor>> GetIncludedAsync();
        Task<Doctor> GetFindIncludedAsync(Expression<Func<Doctor, bool>> expression);
        Task<ICollection<Doctor>> GetFilterIncludedAsync(Expression<Func<Doctor, bool>> expression);
    }
}
