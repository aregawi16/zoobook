using Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class

    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            this._context = context;
            _dbSet = _context.Set<TEntity>();

        }
        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var e = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task AddRangeAsync(IList<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);

        }

        public async Task UpdateAsync(TEntity entity, TEntity exEntity)
        {
            try
            {

                _context.Entry(exEntity).State = EntityState.Detached;
                _context.Entry(entity).State = EntityState.Modified;
                _context.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveRange(IList<int> ids)
        {
            //var entities = await _dbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
            //if (entities.Any())
            //{
            //    _dbSet.RemoveRange(entities);
            //    await _context.SaveChangesAsync();
            //}
        }

    }
}
