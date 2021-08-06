using Application.DTOs;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            return Ok(await _productManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var product = await _productManager.GetById(id);
            return (product == null) ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Add([FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productManager.Add(productDTO);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductDTO productDTO)
        {
            var product = await _productManager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productManager.Update(product, productDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productManager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productManager.Remove(product);

            return NoContent();
        }

        #endregion
    }
}
