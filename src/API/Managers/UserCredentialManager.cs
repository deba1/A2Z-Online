using Application.DTOs.AuthenticationDTOs;
using Domain.Entities;
using Infrastructure.Repository;
using System.Threading.Tasks;

namespace API.Managers
{
    public interface IUserCredentialManager : IBaseManager<UserCredential>
    {
        Task<UserCredential> LoginUser(LoginRequestDTO loginRequestDTO);
        Task<bool> CheckOldPassword(int id, string oldPassword);
        Task<bool> ChangePassword(int id, string password);
    }

    public class UserCredentialManager : BaseManager<UserCredential>, IUserCredentialManager
    {
        private readonly IUserCredentialRepository _userCredentialRepository;

        public UserCredentialManager(IUserCredentialRepository userCredentialRepository) : base(userCredentialRepository)
        {
            _userCredentialRepository = userCredentialRepository;
        }

        public Task<UserCredential> LoginUser(LoginRequestDTO loginRequestDTO)
        {
            return _userCredentialRepository.LoginUser(loginRequestDTO);
        }

        public async Task<bool> CheckOldPassword(int id, string oldPassword)
        {
            return ((await _userCredentialRepository.GetById(id)).Password == oldPassword);
        }

        public async Task<bool> ChangePassword(int id, string password)
        {
            return await _userCredentialRepository.ChangePassword(id, password);
        }
    }
}
