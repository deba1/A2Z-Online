using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {

    }
    class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly DbContext _context;

        public BrandRepository(IAppDbContext context) : base(context)
        {
            _context = context.Instance;
        }
    }
}
