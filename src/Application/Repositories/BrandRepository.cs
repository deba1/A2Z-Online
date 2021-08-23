using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {

    }
    class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly IAppDbContext _context;

        public BrandRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
