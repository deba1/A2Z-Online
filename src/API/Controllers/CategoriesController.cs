using Application.DTOs.EntityDTOs;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryManager _categoryManager;

        public CategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            return Ok(await _categoryManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var category = await _categoryManager.GetById(id);

            return (category == null) ? NotFound() : Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Add([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryManager.Add(categoryDTO);

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

            await _categoryManager.Update(category, categoryDTO);

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

        #endregion

        #region Product

        [HttpGet("{categoryId}/products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllCategoryProducts(int categoryId)
        {
            return Ok(await _categoryManager.GetAllCategoryProducts(categoryId));
        }

        [HttpGet("{categoryId}/products/{productId}")]
        public async Task<ActionResult<ProductDTO>> GetCategoryProducttById(int categoryId, int productId)
        {
            var result = await _categoryManager.GetCategoryProductById(categoryId, productId);
            return (result != null) ? Ok(result) : NotFound();
        }

        #endregion
    }
}
