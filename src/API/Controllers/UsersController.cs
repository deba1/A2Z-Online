using API.Managers;
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
        private readonly IMapper _mapper;

        public UsersController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok(await _userManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
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
            user = _mapper.Map(userDTO, user);
            await _userManager.Update(user);

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
