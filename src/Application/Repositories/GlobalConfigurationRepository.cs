using Application.Interfaces;
using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IGlobalConfigurationRepository : IBaseRepository<GlobalConfiguration>
    {

    }

    class GlobalConfigurationRepository : BaseRepository<GlobalConfiguration>, IGlobalConfigurationRepository
    {
        private readonly IAppDbContext _context;

        public GlobalConfigurationRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
