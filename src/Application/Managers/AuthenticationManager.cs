﻿using Application.DTOs.AuthenticationDTOs;
using Application.Interfaces;
using Application.Services.DbServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Application.Managers
{
    public interface IAuthenticationManager
    {
        Task<User> RegisterUser(RegisterDTO registerDTO);
        Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginRequestDTO);
        Task<bool> ChangePassword(int id, string password);
        Task<bool> CheckOldPassword(int id, string oldPassword);
    }

    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUserCredentialManager _userCredentialManager;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly ITransactionService _transactionService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEncryptionService _encryptionService;

        public AuthenticationManager(
            IUserCredentialManager userCredentialManager,
            IUserManager userManager, IMapper mapper,
            ITransactionService transactionService,
            IAuthenticationService authenticationService,
            IEncryptionService encryptionService
            )
        {
            _userCredentialManager = userCredentialManager;
            _userManager = userManager;
            _mapper = mapper;
            _transactionService = transactionService;
            _authenticationService = authenticationService;
            _encryptionService = encryptionService;
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

            LoginResponseDTO loginResponseDTO = new()
            {
                User = userCredential.User,
                AccessToken = _authenticationService.CreateToken(userCredential.User)
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
                return null;
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
    }
}