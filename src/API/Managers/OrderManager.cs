using Domain.Entities;
using Infrastructure.Repository;

namespace API.Managers
{
    public interface IOrderManager : IBaseManager<Order>
    {

    }

    class OrderManager : BaseManager<Order>, IOrderManager
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}
