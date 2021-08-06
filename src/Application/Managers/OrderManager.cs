using Domain.Entities;
using Application.Repository;
using AutoMapper;

namespace Application.Managers
{
    public interface IOrderManager : IBaseManager<Order>
    {

    }

    class OrderManager : BaseManager<Order>, IOrderManager
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository, IMapper mapper) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
        }
    }
}
