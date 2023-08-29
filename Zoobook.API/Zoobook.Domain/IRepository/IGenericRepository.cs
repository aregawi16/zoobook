using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IList<TEntity> entities);
        Task UpdateAsync(TEntity newEntity, TEntity exisEntity);
        Task RemoveAsync(int id);
        Task RemoveRange(IList<int> ids);
    }
}
