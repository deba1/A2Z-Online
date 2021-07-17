using API.Managers;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        public async Task<ActionResult<ICollection<Brand>>> GetAll()
        {
            try
            {
                return Ok(await _brandManager.GetAll());
            }
            catch (Exception ex)
            {
                return (BadRequest(ex));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetById(int id)
        {
            try
            {
                var brand = await _brandManager.GetById(id);

                if (brand == null)
                {
                    return NoContent();
                }

                return Ok(brand);
            }
            catch (Exception ex)
            {
                return (BadRequest(ex));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> Add([FromBody] BrandViewModel brandViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var brand = _mapper.Map<Brand>(brandViewModel);

                await _brandManager.Add(brand);

                return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
            }
            catch (Exception ex)
            {
                return (BadRequest(ex));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> Update([FromRoute] int id, [FromBody] BrandViewModel brandViewModel)
        {
            try
            {
                var brand = await _brandManager.GetById(id);

                if (brand == null)
                {
                    return NoContent();
                }

                brand = _mapper.Map(brandViewModel, brand);
                await _brandManager.Update(brand);

                return Ok(brand);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                var brand = await _brandManager.GetById(id);

                if(brand != null)
                {
                    await _brandManager.Remove(brand);
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
