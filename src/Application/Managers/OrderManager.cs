using Domain.Entities;
using Application.Repositories;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.DTOs.EntityDTOs;
using Microsoft.EntityFrameworkCore.Storage;
using Application.Services.DbServices;

namespace Application.Managers
{
    public interface IOrderManager : IBaseManager<Order>
    {
        Task<List<Payment>> GetAllPayments(int orderId);
        Task<Payment> GetOrderPaymentById(int orderId, int paymentId);
        Task<List<OrderItem>> GetAllOrderItems(int orderId);
        Task<OrderItem> GetOrderOrderItemById(int orderId, int orderItemId);
        Task<Order> NewOrder(OrderDTO orderDTO);
    }

    class OrderManager : BaseManager<Order>, IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;
        private readonly IBaseSecondLevelRepository<Order, Payment> _orderPaymentRepository;
        private readonly ITransactionService _transactionService;

        public OrderManager(
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            IMapper mapper, 
            IBaseSecondLevelRepository<Order, Payment> orderPaymentRepository,
            ITransactionService transactionService
            ) 
            : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
            _orderPaymentRepository = orderPaymentRepository;
            _transactionService = transactionService;
        }

        public async Task<Order> NewOrder(OrderDTO orderDTO)
        {
            using IDbContextTransaction transaction = _transactionService.GetTransaction();
            try
            {
                var orderItemList = new List<OrderItemDTO>(orderDTO.OrderItems);
                orderDTO.OrderItems = new List<OrderItemDTO>();
                Order order = _mapper.Map<Order>(orderDTO);
                await _orderRepository.Add(order);

                foreach (var item in orderItemList)
                {
                    OrderItem orderItem = _mapper.Map<OrderItem>(item);
                    orderItem.OrderId = order.Id;
                    await _orderItemRepository.Add(orderItem);
                }

                await transaction.CommitAsync();
                return order;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        #region Payments

        public async Task<List<Payment>> GetAllPayments(int orderId)
        {
            return await _orderPaymentRepository.GetAllSecondLevel(orderId, "OrderId");
        }

        public async Task<Payment> GetOrderPaymentById(int orderId, int paymentId)
        {
            return await _orderPaymentRepository.GetSecondLevelById(orderId, paymentId, "OrderId");
        }

        #endregion

        #region OrderItems

        public async Task<List<OrderItem>> GetAllOrderItems(int orderId)
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
