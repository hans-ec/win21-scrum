using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Repositories
{
    public abstract class GenericRepository<TEntity> where TEntity : class
    {
        private readonly SqlDataContext _context;

        protected GenericRepository(SqlDataContext context)
        {
            _context = context;
        }

        protected virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity != null)
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            return null!;
        }

        protected virtual async Task<List<TEntity>> ReadAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        protected virtual async Task<TEntity> ReadAsync(int id)
        {
            var _entity = await _context.Set<TEntity>().FindAsync(id);
            if (_entity != null)
                return _entity;
            
            return null!;
        }

        protected virtual async Task<TEntity> ReadAsync(string id)
        {
            var _entity = await _context.Set<TEntity>().FindAsync(id);
            if (_entity != null)
                return _entity;

            return null!;
        }

        protected virtual async Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            var _entity = await _context.Set<TEntity>().FindAsync(id);
            if (_entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return _entity;
            }
                
            return null!;
        }

        protected virtual async Task<TEntity> UpdateAsync(string id, TEntity entity)
        {
            var _entity = await _context.Set<TEntity>().FindAsync(id);
            if (_entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return _entity;
            }

            return null!;
        }

        protected virtual async Task<bool> DeleteAsync(int id)
        {
            var _entity = await _context.Set<TEntity>().FindAsync(id);
            if (_entity != null)
            {
                _context.Remove(_entity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        protected virtual async Task<bool> DeleteAsync(string id)
        {
            var _entity = await _context.Set<TEntity>().FindAsync(id);
            if (_entity != null)
            {
                _context.Remove(_entity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
