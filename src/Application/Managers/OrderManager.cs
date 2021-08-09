using Domain.Entities;
using Application.Repositories;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Managers
{
    public interface IOrderManager : IBaseManager<Order>
    {
        Task<ICollection<Payment>> GetAllPayments(int orderId);
        Task<Payment> GetOrderPaymentById(int orderId, int paymentId);
        Task<ICollection<OrderItem>> GetAllOrderItems(int orderId);
        Task<OrderItem> GetOrderOrderItemById(int orderId, int orderItemId);
    }

    class OrderManager : BaseManager<Order>, IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IBaseSecondLevelRepository<Order, Payment> _orderPaymentRepository;

        public OrderManager(IOrderRepository orderRepository, IMapper mapper, 
            IBaseSecondLevelRepository<Order, Payment> orderPaymentRepository
            ) 
            : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderPaymentRepository = orderPaymentRepository;
        }

        #region Payments

        public async Task<ICollection<Payment>> GetAllPayments(int orderId)
        {
            return await _orderPaymentRepository.GetAllSecondLevel(orderId, "OrderId");
        }

        public async Task<Payment> GetOrderPaymentById(int orderId, int paymentId)
        {
            return await _orderPaymentRepository.GetSecondLevelById(orderId, paymentId, "OrderId");
        }
        #endregion

        #region OrderItems

        public async Task<ICollection<OrderItem>> GetAllOrderItems(int orderId)
        {
            return await _orderRepository.GetAllOrderItems(orderId);
        }

        public async Task<OrderItem> GetOrderOrderItemById(int orderId, int orderItemId)
        {
            return await _orderRepository.GetOrderOrderItemById(orderId, orderItemId);
        }

        #endregion
    }
}
