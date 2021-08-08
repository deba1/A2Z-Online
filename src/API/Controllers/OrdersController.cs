using Application.DTOs;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrderManager _orderManager;

        public OrdersController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAll()
        {
            return Ok(await _orderManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            var order = await _orderManager.GetById(id);
            return (order == null) ? NotFound() : Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Add([FromBody] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _orderManager.Add(orderDTO);

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] OrderDTO orderDTO)
        {
            var order = await _orderManager.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            await _orderManager.Update(order, orderDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var order = await _orderManager.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            await _orderManager.Remove(order);
            return NoContent();
        }

        #endregion
    }
}
