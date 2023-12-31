﻿using HealthCare.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Interfaces.Repositories
{
    public interface IHospitalRepository :IBaseRepository<Hospital>
    {
        Task<ICollection<Hospital>> GetListIncludedAsync();
        Task<Hospital> GetFindIncludedAsync(Expression<Func<Hospital, bool>> expression);
        Task<ICollection<Hospital>> GetListWithFilterIncludedAsync(Expression<Func<Hospital, bool>> expression);
    }
}
