using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {

    }
    class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly IAppDbContext _context;

        public CategoryRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
