using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {

    }

    class UserReposity : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserReposity(AppDbContext context): base(context)
        {
            _context = context;
        }
    }
}
