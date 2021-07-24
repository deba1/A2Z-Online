using API.Managers;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return Ok(await _categoryManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _categoryManager.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Add([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryManager.Add(category);

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryDTO categoryDTO)
        {
            var category = await _categoryManager.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            category = _mapper.Map(categoryDTO, category);
            await _categoryManager.Update(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _categoryManager.GetById(id);

            if (category != null)
            {
                await _categoryManager.Remove(category);
                return NoContent();
            }

            return NotFound();
        }
    }
}
