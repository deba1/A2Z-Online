using System.Collections.Generic;
using System.Threading.Tasks;
using API.Managers;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FeedbacksController : BaseController
    {
        private readonly IFeedbackManager _feedbackManager;
        private readonly IMapper _mapper;

        public FeedbacksController(IFeedbackManager feedbackManager, IMapper mapper)
        {
            _feedbackManager = feedbackManager;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAll()
        {
            return Ok(await _feedbackManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetById(int id)
        {
            var feedback = await _feedbackManager.GetById(id);
            return (feedback == null) ? NotFound() : Ok(feedback);
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> Add([FromBody] FeedbackDTO feedbackDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var feedback = _mapper.Map<Feedback>(feedbackDTO);
            await _feedbackManager.Add(feedback);

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
            feedback = _mapper.Map(feedbackDTO, feedback);
            await _feedbackManager.Update(feedback);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var feedback = await _feedbackManager.GetById(id);
            if(feedback != null)
            {
                await _feedbackManager.Remove(feedback);
                return NoContent();
            }
            return NotFound();
        }

        #endregion
    }
}
