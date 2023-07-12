using HealthCare.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IDiseaseRepository : IBaseRepository<Disease>
    {
        Task<ICollection<Disease>> GetIncludedAsync();
        Task<Disease> GetFindIncludedAsync(Expression<Func<Disease, bool>> expression);
        Task<ICollection<Disease>> GetFilterIncludedAsync(Expression<Func<Disease, bool>> expression);
    }
}
