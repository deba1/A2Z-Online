using Application.Interfaces.DBContextInterfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Remove(T entity);
    }
    class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public BaseRepository(IAppDbContext context)
        {
            _context = context.Instance;
        }

        /// <summary>
        /// Gets the DbSet of entity by setting it to context.
        /// </summary>
        protected virtual DbSet<T> DbTable
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public async virtual Task<int> Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            DbTable.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async virtual Task<ICollection<T>> GetAll()
        {
            return await DbTable.ToListAsync();
        }

        public async virtual Task<T> GetById(int id)
        {
            return await DbTable.FindAsync(id);
        }

        public async virtual Task<int> Remove(T entity)
        {
            DbTable.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async virtual Task<int> Update(T entity)
        {
            entity.ModifiedAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
