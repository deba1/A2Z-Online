using Domain.Entities;
using Application.Repository;
using AutoMapper;

namespace Application.Managers
{
    public interface IUserManager : IBaseManager<User>
    {

    }
    class UserManager: BaseManager<User>, IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepostory, IMapper mapper) : base(userRepostory, mapper)
        {
            _userRepository = userRepostory;
        }
    }
}
