using Application.DTOs;
using Application.Extensions;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class FeedbacksController : BaseController
    {
        private readonly IFeedbackManager _feedbackManager;

        public FeedbacksController(IFeedbackManager feedbackManager)
        {
            _feedbackManager = feedbackManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetAll()
        {
            return Ok(await _feedbackManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDTO>> GetById(int id)
        {
            var feedback = await _feedbackManager.GetById(id);
            return (feedback == null) ? NotFound() : Ok(feedback);
        }

        [HttpPost]
        public async Task<ActionResult<FeedbackDTO>> Add([FromBody] FeedbackDTO feedbackDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            feedbackDTO.UserId = HttpContext.GetUserId();
            var feedback = await _feedbackManager.Add(feedbackDTO);

            return CreatedAtAction(nameof(GetById), new { id = feedback.Id }, feedback);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FeedbackDTO feedbackDTO)
        {
            var feedback = await _feedbackManager.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            await _feedbackManager.Update(feedback, feedbackDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var feedback = await _feedbackManager.GetById(id);
            if (feedback != null)
            {
                await _feedbackManager.Remove(feedback);
                return NoContent();
            }
            return NotFound();
        }

        #endregion
    }
}
