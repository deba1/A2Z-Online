using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<Feedback>> GetAllFeedbacks(int userId);
    }

    class UserReposity : BaseRepository<User>, IUserRepository
    {
        private readonly IAppDbContext _context;

        public UserReposity(IAppDbContext context) : base(context)
        {
            _context = context;
        }

        #region Feedback

        public async Task<List<Feedback>> GetAllFeedbacks(int tOneId)
        {
            return await _context.Feedbacks.Where(x => x.UserId.Equals(tOneId))
                .Include(p => p.Product).ToListAsync();
        }

        #endregion
    }
}
