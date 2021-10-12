using Application.DTOs.AuthenticationDTOs;
using Application.Interfaces.EncyptionInterfaces;
using Application.Repositories;
using Application.Services.DbServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Managers
{
    public interface IAuthenticationManager
    {
        Task<User> RegisterUser(RegisterDTO registerDTO);
        Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginRequestDTO);
        Task<bool> ChangePassword(int id, string password);
        Task<bool> CheckOldPassword(int id, string oldPassword);
        Task<RefreshTokenResponseDTO> RefreshToken(string refreshToken);
        Task<int?> Logout(string refreshToken);
    }

    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUserCredentialManager _userCredentialManager;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly ITransactionService _transactionService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEncryptionService _encryptionService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthenticationManager(
            IUserCredentialManager userCredentialManager,
            IUserManager userManager, IMapper mapper,
            ITransactionService transactionService,
            IAuthenticationService authenticationService,
            IEncryptionService encryptionService,
            IRefreshTokenRepository refreshTokenRepository
            )
        {
            _userCredentialManager = userCredentialManager;
            _userManager = userManager;
            _mapper = mapper;
            _transactionService = transactionService;
            _authenticationService = authenticationService;
            _encryptionService = encryptionService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        #region Login

        public async Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginRequestDTO)
        {
            var userCredential = await _userCredentialManager.LoginUser(loginRequestDTO.Email);

            if (userCredential == null || !_encryptionService.VerifyHash(userCredential.Password, loginRequestDTO.Password))
            {
                return null;
            }

            try
            {
                await _userCredentialManager.UpdateLastLogin(userCredential.Id);
            }
            catch
            {

            }

            string refreshToken = _authenticationService.CreateRefreshToken(userCredential);
            var existingToken = await _refreshTokenRepository.GetByToken(refreshToken);

            if (existingToken == null)
            {
                await _refreshTokenRepository.Add(refreshToken, userCredential.Id);
            }

            LoginResponseDTO loginResponseDTO = new()
            {
                Role = (userCredential.Role == UserRole.Admin) ?
                    RoleResponseEnum.Admin : RoleResponseEnum.Customer,
                AccessToken = _authenticationService.CreateToken(userCredential),
                RefreshToken = refreshToken
            };

            return loginResponseDTO;
        }

        #endregion

        public async Task<User> RegisterUser(RegisterDTO registerDTO)
        {
            registerDTO.Password = _encryptionService.GenerateHash(registerDTO.Password);
            var user = _mapper.Map<User>(registerDTO);

            using IDbContextTransaction transaction = _transactionService.GetTransaction();
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
                throw;
            }
        }

        #region Change Password

        public async Task<bool> CheckOldPassword(int id, string oldPassword)
        {
            return await _userCredentialManager.CheckOldPassword(id, oldPassword);
        }

        public async Task<bool> ChangePassword(int id, string password)
        {
            return await _userCredentialManager.ChangePassword(id, password);
        }

        #endregion

        #region Refresh Token

        public async Task<RefreshTokenResponseDTO> RefreshToken(string refreshToken)
        {
            try
            {
                var foundRefreshToken = await _refreshTokenRepository.GetByToken(refreshToken);

                if (
                    foundRefreshToken == null ||
                    foundRefreshToken.Invalidated ||
                    foundRefreshToken.Used ||
                    foundRefreshToken.ExpiryDate < DateTime.UtcNow
                    )
                {
                    return null;
                }

                UserCredential userCredential = await _userCredentialManager.GetById(foundRefreshToken.UserId);
                string newRefreshToken = _authenticationService.CreateRefreshToken(userCredential);

                var response = new RefreshTokenResponseDTO
                {
                    AccessToken = _authenticationService.CreateToken(foundRefreshToken.User),
                    RefreshToken = newRefreshToken
                };

                await _refreshTokenRepository.Add(newRefreshToken, foundRefreshToken.UserId);
                await _refreshTokenRepository.Remove(foundRefreshToken);

                return response;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int?> Logout(string refreshToken)
        {
            try
            {
                var foundToken = await _refreshTokenRepository.GetByToken(refreshToken);
                if (foundToken != null)
                {
                    return await _refreshTokenRepository.Remove(foundToken);
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        #endregion
    }
}
