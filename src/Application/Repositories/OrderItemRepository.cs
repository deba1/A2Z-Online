using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {

    }

    class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        private readonly IAppDbContext _context;

        public OrderItemRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
