using API.Managers;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class InventoriesController : BaseController
    {
        private readonly IInventoryManager _inventoryManager;
        private readonly IMapper _mapper;

        public InventoriesController(IInventoryManager inventoryManager, IMapper mapper)
        {
            _inventoryManager = inventoryManager;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetAll()
        {
            return Ok(await _inventoryManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetById(int id)
        {
            var inventory = await _inventoryManager.GetById(id);
            return (inventory == null) ? NotFound() : Ok(inventory);
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> Add([FromBody] InventoryDTO inventoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var inventory = _mapper.Map<Inventory>(inventoryDTO);
            await _inventoryManager.Add(inventory);

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
            inventory = _mapper.Map(inventoryDTO, inventory);
            await _inventoryManager.Update(inventory);

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
