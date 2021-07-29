using API.Managers;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BrandsController : BaseController
    {
        private readonly IBrandManager _brandManager;
        private readonly IMapper _mapper;

        public BrandsController(IBrandManager brandManager, IMapper mapper)
        {
            _brandManager = brandManager;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
        {
            return Ok(await _brandManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetById(int id)
        {
            var brand = await _brandManager.GetById(id);

            return (brand == null) ? NotFound() : Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> Add([FromBody] BrandDTO brandDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = _mapper.Map<Brand>(brandDTO);
            await _brandManager.Add(brand);

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

            brand = _mapper.Map(brandDTO, brand);
            await _brandManager.Update(brand);

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
    }
}
