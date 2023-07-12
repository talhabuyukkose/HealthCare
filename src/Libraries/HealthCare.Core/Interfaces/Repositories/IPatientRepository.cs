using HealthCare.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<ICollection<Patient>> GetIncludedAsync();
        Task<Patient> GetFindIncludedAsync(Expression<Func<Patient, bool>> expression);
        Task<ICollection<Patient>> GetFilterIncludedAsync(Expression<Func<Patient, bool>> expression);
    }
}
