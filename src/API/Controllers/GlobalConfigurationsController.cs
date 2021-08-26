using Application.DTOs.EntityDTOs;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class GlobalConfigurationsController : BaseController
    {
        private readonly IGlobalConfigurationManager _globalConfigurationManager;

        public GlobalConfigurationsController(IGlobalConfigurationManager globalConfigurationManager)
        {
            _globalConfigurationManager = globalConfigurationManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlobalConfigurationDTO>>> GetAll()
        {
            return Ok(await _globalConfigurationManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GlobalConfigurationDTO>> GetById(int id)
        {
            var globalConfiguration = await _globalConfigurationManager.GetById(id);

            return (globalConfiguration == null) ? NotFound() : Ok(globalConfiguration);
        }

        [HttpPost]
        public async Task<ActionResult<GlobalConfigurationDTO>> Add([FromBody] GlobalConfigurationDTO globalConfigurationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var globalConfiguration = await _globalConfigurationManager.Add(globalConfigurationDTO);

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
            await _globalConfigurationManager.Update(globalConfiguration, globalConfigurationDTO);

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
