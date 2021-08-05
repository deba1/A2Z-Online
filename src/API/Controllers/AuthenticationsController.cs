using API.Managers;
using Application.DTOs.AuthenticationDTOs;
using Application.DTOs.ResponseDTOs;
using Application.Extensions;
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
            return Ok(await _authenticationManager.ResiterUser(registerDTO));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            var result = await _authenticationManager.LoginUser(loginRequestDTO);
            return (result != null) ? Ok(result) : BadRequest(_apiResponseDTO.SetApiResponse("Email or Password does not match."));
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var id = HttpContext.GetUserId();
            if (id == -1)
            {
                return BadRequest(_apiResponseDTO.SetApiResponse("User is not logged in."));
            }

            if (!await _authenticationManager.CheckOldPassword(id, changePasswordDTO.OldPassword))
            {
                return BadRequest(_apiResponseDTO.SetApiResponse("Old password does not match."));
            }

            return await _authenticationManager.ChangePassword(id, changePasswordDTO.RepeatPassword) ? NoContent() : BadRequest(_apiResponseDTO.SetApiResponse("Password change failed."));
        }
    }
}
