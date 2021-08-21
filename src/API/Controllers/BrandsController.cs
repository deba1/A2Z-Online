using Application.DTOs;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BrandsController : BaseController
    {
        private readonly IBrandManager _brandManager;

        public BrandsController(IBrandManager brandManager)
        {
            _brandManager = brandManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAll()
        {
            return Ok(await _brandManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> GetById(int id)
        {
            var brand = await _brandManager.GetById(id);

            return (brand == null) ? NotFound() : Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult<BrandDTO>> Add([FromBody] BrandDTO brandDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _brandManager.Add(brandDTO);

            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BrandDTO brandDTO)
        {
            var brand = await _brandManager.GetById(id);

            if (brand == null)
            {
                return NotFound();
            }

            await _brandManager.Update(brand, brandDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var brand = await _brandManager.GetById(id);

            if (brand != null)
            {
                await _brandManager.Remove(brand);
                return NoContent();
            }

            return NotFound();
        }

        #endregion

        #region Product

        [HttpGet("{brandId}/products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllBrandProducts(int brandId)
        {
            return Ok(await _brandManager.GetAllBrandProducts(brandId));
        }

        [HttpGet("{brandId}/products/{productId}")]
        public async Task<ActionResult<ProductDTO>> GetBrandProducttById(int brandId, int productId)
        {
            var result = await _brandManager.GetBrandProductById(brandId, productId);
            return (result != null) ? Ok(result) : NotFound();
        }

        #endregion
    }
}
