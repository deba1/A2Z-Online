using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {

    }
    class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly AppDbContext _context;
       
        public BrandRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
