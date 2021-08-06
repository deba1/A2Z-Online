using Application.Managers;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            return Ok(await _userManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var user = await _userManager.GetById(id);

            return (user == null) ? NotFound() : Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UserDTO userDTO)
        {
            var user = await _userManager.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.Update(user, userDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userManager.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.Remove(user);

            return NoContent();
        }

        #endregion
    }
}
