using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {

    }

    class UserReposity : BaseRepository<User>, IUserRepository
    {
        private readonly DbContext _context;

        public UserReposity(IAppDbContext context) : base(context)
        {
            _context = context.Instance;
        }
    }
}
