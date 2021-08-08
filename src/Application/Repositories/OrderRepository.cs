using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {

    }

    class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly DbContext _context;

        public OrderRepository(IAppDbContext context) : base(context)
        {
            _context = context.Instance;
        }
    }
}
