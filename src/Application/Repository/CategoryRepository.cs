using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {

    }
    class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DbContext _context;

        public CategoryRepository(IAppDbContext context) : base(context)
        {
            _context = context.Instance;
        }
    }
}
