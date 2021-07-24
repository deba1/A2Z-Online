using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {

    }
    class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
