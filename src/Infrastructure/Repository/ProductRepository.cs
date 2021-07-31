using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {

    }

    class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
