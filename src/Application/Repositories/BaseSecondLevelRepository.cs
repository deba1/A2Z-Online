using Application.Interfaces.DBContextInterfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IBaseSecondLevelRepository<TOne, TTwo> where TOne : BaseEntity where TTwo : BaseEntity 
    {
        Task<ICollection<TTwo>> GetAllSecondLevel(int tOneId, string property);
        Task<TTwo> GetSecondLevelById(int tOneId, int tTwoId, string property);
    }

    class BaseSecondLevelRepository<TOne, TTwo> : IBaseSecondLevelRepository<TOne, TTwo> where TOne : BaseEntity where TTwo : BaseEntity
    {
        private readonly DbContext _context;
        public BaseSecondLevelRepository(IAppDbContext context)
        {
            _context = context.Instance;
        }

        protected virtual DbSet<TTwo> DbSecondLevelTable => _context.Set<TTwo>();

        public async Task<ICollection<TTwo>> GetAllSecondLevel(int tOneId, string property)
        {
            return await DbSecondLevelTable.Where(x => (int)x[property] == tOneId).ToListAsync();
        }

        public async Task<TTwo> GetSecondLevelById(int tOneId, int tTwoId, string property)
        {
            return await DbSecondLevelTable.Where(x => (int)x[property] == tOneId && x.Id == tTwoId).FirstOrDefaultAsync();
        }
    }
}
