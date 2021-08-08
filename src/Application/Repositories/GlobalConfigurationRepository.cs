using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public interface IGlobalConfigurationRepository : IBaseRepository<GlobalConfiguration>
    {

    }

    class GlobalConfigurationRepository : BaseRepository<GlobalConfiguration>, IGlobalConfigurationRepository
    {
        private readonly DbContext _context;

        public GlobalConfigurationRepository(IAppDbContext context) : base(context)
        {
            _context = context.Instance;
        }
    }
}
