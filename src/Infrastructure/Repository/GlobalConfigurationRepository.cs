using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public interface IGlobalConfigurationRepository : IBaseRepository<GlobalConfiguration>
    {

    }

    class GlobalConfigurationRepository : BaseRepository<GlobalConfiguration>, IGlobalConfigurationRepository
    {
        private readonly AppDbContext _context;

        public GlobalConfigurationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
