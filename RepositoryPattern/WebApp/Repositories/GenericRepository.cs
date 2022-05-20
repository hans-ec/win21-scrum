using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Repositories
{
    public abstract class GenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        protected GenericRepository(DataContext context)
        {
            _context = context;
        }


        #region CreateAsync
        /// <summary>
        /// Creates a new record of TEntity
        /// </summary>
        /// <param name="entity">Entity for the database</param>
        /// <returns>TEntity with Id</returns>
        protected virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity != null)
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            return null!;
        }
        #endregion

        #region GetAsync
        /// <summary>
        /// Get a specific TEntity based of the provided id
        /// </summary>
        /// <param name="id">id of the TEntity</param>
        /// <returns>Returns TEntity</returns>
        protected virtual async Task<TEntity> GetAsync(int id)
        {
            var _entity = await _context.Set<TEntity>().FindAsync(id);
            if (_entity != null)
                return _entity;

            return null!;
        }


        /// <summary>
        /// Get a list of TEntity
        /// </summary>
        /// <returns>Returns a List of TEntity</returns>
        protected virtual async Task<List<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        #endregion

        #region UpdateAsync
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
        #endregion

        #region DeleteAsync
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
        #endregion
    }
}
