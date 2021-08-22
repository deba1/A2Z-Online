﻿using Application.DTOs.AuthenticationDTOs;
using Application.DTOs.ResponseDTOs;
using Application.Extensions;
using Application.Managers;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AuthenticationsController : BaseController
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IApiResponseDTO _apiResponseDTO;

        public AuthenticationsController(IAuthenticationManager authenticationManager, IApiResponseDTO apiResponseDTO)
        {
            _authenticationManager = authenticationManager;
            _apiResponseDTO = apiResponseDTO;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(RegisterDTO registerDTO)
        {
            var result = await _authenticationManager.RegisterUser(registerDTO);
            return (result != null) ? Ok(result) : BadRequest(_apiResponseDTO.SetApiResponse("Registration failed"));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            var result = await _authenticationManager.LoginUser(loginRequestDTO);
            return (result != null) ? Ok(result) : BadRequest(_apiResponseDTO.SetApiResponse("Email or Password does not match."));
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<ActionResult<RefreshTokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO tokenRequestDTO)
        {
            var result = await _authenticationManager.RefreshToken(tokenRequestDTO.RefreshToken);
            return result != null ? Ok(result) : BadRequest(_apiResponseDTO.SetApiResponse("Invalid Token"));
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(RefreshTokenRequestDTO tokenRequestDTO)
        {
            var result = await _authenticationManager.Logout(tokenRequestDTO.RefreshToken);
            return result != null ? NoContent() : BadRequest(_apiResponseDTO.SetApiResponse("Logout failed"));
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var id = HttpContext.GetUserId();
            if (id == -1)
            {
                return Unauthorized(_apiResponseDTO.SetApiResponse("User is not logged in."));
            }

            if (!await _authenticationManager.CheckOldPassword(id, changePasswordDTO.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "Old password does not match.");
                return BadRequest(ModelState);
            }

            return await _authenticationManager.ChangePassword(id, changePasswordDTO.RepeatPassword) ? NoContent() : BadRequest(_apiResponseDTO.SetApiResponse("Password change failed."));
        }
    }
}
