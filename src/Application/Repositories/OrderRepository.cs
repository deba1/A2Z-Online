using Application.Interfaces.DBContextInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<OrderItem>> GetAllOrderItems(int orderId);
        Task<OrderItem> GetOrderOrderItemById(int orderId, int orderItemsId);
    }

    class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly IAppDbContext _context;

        public OrderRepository(IAppDbContext context) : base(context)
        {
            _context = context;
        }

        #region Order-item

        public async Task<List<OrderItem>> GetAllOrderItems(int tOneId)
        {
            return await _context.OrderItems.Where(x => x.OrderId.Equals(tOneId))
                .Include(p => p.Product).ToListAsync();
        }

        public async Task<OrderItem> GetOrderOrderItemById(int tOneId, int tTwoId)
        {
            return await _context.OrderItems.Where(x => x.OrderId.Equals(tOneId) && x.Id.Equals(tTwoId))
                .Include(p => p.Product).FirstOrDefaultAsync();
        }

        #endregion
    }
}
