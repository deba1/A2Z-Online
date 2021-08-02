using Domain.Entities;
using Infrastructure.Repository;  

namespace API.Managers
{
    public interface IUserManager : IBaseManager<User>
    {

    }
    class UserManager: BaseManager<User>, IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepostory) : base(userRepostory)
        {
            _userRepository = userRepostory;
        }
    }
}
