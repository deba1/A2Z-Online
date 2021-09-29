using Domain.Entities;
using Application.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Managers
{
    public interface IUserManager : IBaseManager<User>
    {
        Task<List<Feedback>> GetAllFeedbacks(int userId);
        Task<Feedback> GetFeedbackByUserId(int userId, int feedbackId);
        Task<List<Order>> GetAllOrders(int userId);
        Task<Order> GetOrderById(int userId, int orderId);
    }
    class UserManager: BaseManager<User>, IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IBaseSecondLevelRepository<User, Feedback> _userFeedbackRepository;
        private readonly IBaseSecondLevelRepository<User, Order> _userOrderRepository;

        public UserManager(IUserRepository userRepostory, IMapper mapper, IBaseSecondLevelRepository<User, Feedback> userFeedbackRepository, IBaseSecondLevelRepository<User, Order> userOrderRepository) : base(userRepostory, mapper)
        {
            _userRepository = userRepostory;
            _userFeedbackRepository = userFeedbackRepository;
            _userOrderRepository = userOrderRepository;
        }

        #region Feedback
        public async Task<List<Feedback>> GetAllFeedbacks(int userId)
        {
            return await _userRepository.GetAllFeedbacks(userId);
        }

        public async Task<Feedback> GetFeedbackByUserId(int userId, int feedbackId)
        {
            return await _userFeedbackRepository.GetSecondLevelById(userId, feedbackId, "UserId");
        }

        #endregion

        #region Orders

        public async Task<List<Order>> GetAllOrders(int userId)
        {
            return await _userOrderRepository.GetAllSecondLevel(userId, "UserId");
        }

        public async Task<Order> GetOrderById(int userId, int orderId)
        {
            return await _userOrderRepository.GetSecondLevelById(userId, orderId, "UserId");
        }

        #endregion
    }
}
