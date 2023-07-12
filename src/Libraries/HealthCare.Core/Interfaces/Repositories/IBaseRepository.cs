using HealthCare.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Interfaces.Repositories
{
    /// <summary>
    /// Classes inherited from BaseEntity can use this interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        /// <summary>
        /// Can get all rows from a table from database
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAllAsync();
        /// <summary>
        /// Can get rows without deleted rows from database
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAsync();
        /// <summary>
        /// Add new row to table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddAsync(T item);
        /// <summary>
        /// Update given row to database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T item);
        /// <summary>
        /// Updates the Status column for the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
        /// <summary>
        /// Deletes the row for the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task HardDeleteAsync(int id);
        /// <summary>
        /// It gives filtered rows with expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<ICollection<T>> GetWithFilterAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// It gives filtered row with expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<T> GetFindAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// It gives count about rows
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();
        /// <summary>
        /// It gives boolean value about filtered values
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<ICollection<T>> SelectByLimitAsync(int page, int limit);
    }
}
