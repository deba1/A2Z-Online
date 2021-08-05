using Application.DTOs.AuthenticationDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Transaction;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace API.Managers
{
    public interface IAuthenticationManager
    {
        Task<User> ResiterUser(RegisterDTO registerDTO);
        Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginRequestDTO);
        Task<bool> ChangePassword(int id, string password);
        Task<bool> CheckOldPassword(int id, string oldPassword);
    }
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUserCredentialManager _userCredentialManager;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly IDatabaseTransaction _databaseTransaction;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEncryptionService _encryptionService;

        public AuthenticationManager(
            IUserCredentialManager userCredentialManager,
            IUserManager userManager, IMapper mapper,
            IDatabaseTransaction databaseTransaction,
            IAuthenticationService authenticationService,
            IEncryptionService encryptionService
            )
        {
            _userCredentialManager = userCredentialManager;
            _userManager = userManager;
            _mapper = mapper;
            _databaseTransaction = databaseTransaction;
            _authenticationService = authenticationService;
            _encryptionService = encryptionService;
        }

        public async Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginRequestDTO)
        {
            var userCredential = await _userCredentialManager.LoginUser(loginRequestDTO.Email);

            if (userCredential == null)
            {
                return null;
            }

            if (!_encryptionService.VerifyHash(userCredential.Password, loginRequestDTO.Password))
            {
                return null;
            }

            LoginResponseDTO loginResponseDTO = new()
            {
                User = userCredential.User,
                AccessToken = _authenticationService.CreateToken(userCredential.User)
            };

            return loginResponseDTO;
        }

        public async Task<User> ResiterUser(RegisterDTO registerDTO)
        {
            registerDTO.Password = _encryptionService.GenerateHash(registerDTO.Password);
            var user = _mapper.Map<User>(registerDTO);

            using IDbContextTransaction transaction = _databaseTransaction.Transaction;
            try
            {
                await _userManager.Add(user);

                var userCredential = _mapper.Map<UserCredential>(registerDTO);
                userCredential.Id = user.Id;

                await _userCredentialManager.Add(userCredential);

                await transaction.CommitAsync();
                return user;
            }
            catch
            {
                await transaction.RollbackAsync();
                return null;
            }
        }

        #region Change Password

        public async Task<bool> CheckOldPassword(int id, string oldPassword)
        {
            return (await _userCredentialManager.CheckOldPassword(id, oldPassword));
        }

        public async Task<bool> ChangePassword(int id, string password)
        {
            return await _userCredentialManager.ChangePassword(id, password);
        }

        #endregion
    }
}
