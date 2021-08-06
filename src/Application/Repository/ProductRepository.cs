using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {

    }

    class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(IAppDbContext context) : base(context)
        {
            _context = context.Instance;
        }
    }
}
