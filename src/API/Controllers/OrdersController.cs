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
    public class OrdersController : BaseController
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;

        public OrdersController(IOrderManager orderManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return Ok(await _orderManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var order = await _orderManager.GetById(id);
            return (order == null) ? NotFound() : Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Add([FromBody] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = _mapper.Map<Order>(orderDTO);
            await _orderManager.Add(order);

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
            order = _mapper.Map(orderDTO, order);
            await _orderManager.Update(order);

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
