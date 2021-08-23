using Application.DTOs.EntityDTOs;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserManager _userManager;
        private readonly IUserCredentialManager _userCredentialManager;

        public UsersController(IUserManager userManager, IUserCredentialManager userCredentialManager)
        {
            _userManager = userManager;
            _userCredentialManager = userCredentialManager;
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

        #region Feedback

        [HttpGet("{userId}/feedbacks")]
        public async Task<ActionResult<IEnumerable<FeedbackDTO>>> Getfeedbacks(int userId)
        {
            return Ok(await _userManager.GetAllFeedbacks(userId));
        }

        [HttpGet("{userId}/feedbacks/{feedbackId}")]
        public async Task<ActionResult<FeedbackDTO>> GetFeedbackById(int userId, int feedbackId)
        {
            var result = await _userManager.GetFeedbackByUserId(userId, feedbackId);
            return (result != null) ? Ok(result) : NotFound();
        }
        #endregion

        #region User Credentials

        [HttpGet("{id}/UserCredential")]
        public async Task<ActionResult<UserCredentialDTO>> GetUserCredentialById(int id)
        {
            var userCredential = await _userCredentialManager.GetById(id);

            return (userCredential == null) ? NotFound() : Ok(userCredential);
        }

        #endregion

        #region Order

        [HttpGet("{userId}/orders")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders(int userId)
        {
            return Ok(await _userManager.GetAllOrders(userId));
        }

        [HttpGet("{userId}/orders/{orderId}")]
        public async Task<ActionResult<OrderDTO>> GetOrdersById(int userId, int orderId)
        {
            var result = await _userManager.GetOrderById(userId, orderId);
            return (result != null) ? Ok(result) : NotFound();
        }

        #endregion
    }
}
