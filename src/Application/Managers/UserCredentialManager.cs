using Domain.Entities;
using Application.Repositories;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.EncyptionInterfaces;

namespace Application.Managers
{
    public interface IUserCredentialManager : IBaseManager<UserCredential>
    {
        Task<UserCredential> LoginUser(string email);
        Task<bool> CheckOldPassword(int id, string oldPassword);
        Task<bool> ChangePassword(int id, string password);
        Task<bool> UpdateLastLogin(int id);
        Task<bool> EmailExists(string email);
    }

    public class UserCredentialManager : BaseManager<UserCredential>, IUserCredentialManager
    {
        private readonly IUserCredentialRepository _userCredentialRepository;
        private readonly IEncryptionService _encryptionService;

        public UserCredentialManager(
                IUserCredentialRepository userCredentialRepository,
                IEncryptionService encryptionService,
                IMapper mapper
            )
            : base(userCredentialRepository, mapper)
        {
            _userCredentialRepository = userCredentialRepository;
            _encryptionService = encryptionService;
        }

        #region Login

        public Task<UserCredential> LoginUser(string email)
        {
            return _userCredentialRepository.LoginUser(email);
        }

        public async Task<bool> UpdateLastLogin(int id)
        {
            return await _userCredentialRepository.UpdateLastLogin(id);
        }

        #endregion

        public async Task<bool> CheckOldPassword(int id, string oldPassword)
        {
            return (_encryptionService.VerifyHash((await _userCredentialRepository.GetById(id)).Password, oldPassword));
        }

        public async Task<bool> ChangePassword(int id, string password)
        {
            return await _userCredentialRepository.ChangePassword(id, _encryptionService.GenerateHash(password));
        }

        public async Task<bool> EmailExists(string email)
        {
            return (await _userCredentialRepository.GetByEmail(email)) != null;
        }
    }
}
