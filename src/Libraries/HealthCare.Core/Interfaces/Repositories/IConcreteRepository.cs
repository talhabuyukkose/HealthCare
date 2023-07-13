using HealthCare.Core.Domain.Common;
using HealthCare.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IConcreteRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        Task<ICollection<T>> GetListIncludedAsync();
        Task<T> GetFindIncludedAsync(Expression<Func<T, bool>> expression);
        Task<ICollection<Hospital>> GetListWithFilterIncludedAsync(Expression<Func<Hospital, bool>> expression);
    }
}
