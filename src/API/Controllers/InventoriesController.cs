using Application.DTOs;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class InventoriesController : BaseController
    {
        private readonly IInventoryManager _inventoryManager;

        public InventoriesController(IInventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDTO>>> GetAll()
        {
            return Ok(await _inventoryManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDTO>> GetById(int id)
        {
            var inventory = await _inventoryManager.GetById(id);
            return (inventory == null) ? NotFound() : Ok(inventory);
        }

        [HttpPost]
        public async Task<ActionResult<InventoryDTO>> Add([FromBody] InventoryDTO inventoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var inventory = await _inventoryManager.Add(inventoryDTO);

            return CreatedAtAction(nameof(GetById), new { id = inventory.Id }, inventory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] InventoryDTO inventoryDTO)
        {
            var inventory = await _inventoryManager.GetById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            await _inventoryManager.Update(inventory, inventoryDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var inventory = await _inventoryManager.GetById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            await _inventoryManager.Remove(inventory);

            return NoContent();
        }

        #endregion
    }
}
