using API.Managers;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class GlobalConfigurationsController : BaseController
    {
        private readonly IGlobalConfigurationManager _globalConfigurationManager;
        private readonly IMapper _mapper;

        public GlobalConfigurationsController(IGlobalConfigurationManager globalConfigurationManager, IMapper mapper)
        {
            _globalConfigurationManager = globalConfigurationManager;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlobalConfiguration>>> GetAll()
        {
            return Ok(await _globalConfigurationManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GlobalConfiguration>> GetById(int id)
        {
            var globalConfiguration = await _globalConfigurationManager.GetById(id);

            return (globalConfiguration == null) ? NotFound() : Ok(globalConfiguration);
        }

        [HttpPost]
        public async Task<ActionResult<GlobalConfiguration>> Add([FromBody] GlobalConfigurationDTO globalConfigurationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var globalConfiguration = _mapper.Map<GlobalConfiguration>(globalConfigurationDTO);
            await _globalConfigurationManager.Add(globalConfiguration);

            return CreatedAtAction(nameof(GetById), new { id = globalConfiguration.Id }, globalConfiguration);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] GlobalConfigurationDTO globalConfigurationDTO)
        {
            var globalConfiguration = await _globalConfigurationManager.GetById(id);
            if (globalConfiguration == null)
            {
                return NotFound();
            }
            globalConfiguration = _mapper.Map(globalConfigurationDTO, globalConfiguration);
            await _globalConfigurationManager.Update(globalConfiguration);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var globalConfiguration = await _globalConfigurationManager.GetById(id);
            if (globalConfiguration == null)
            {
                return NotFound();
            }
            await _globalConfigurationManager.Remove(globalConfiguration);

            return NoContent();
        }

        #endregion
    }
}
