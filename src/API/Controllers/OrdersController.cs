using Application.DTOs;
using Application.DTOs.EntityDTOs;
using Application.Extensions;
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
            orderDTO.UserId = HttpContext.GetUserId();
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

        #region Payments

        [HttpGet("{orderId}/payments")]
        public async Task<ActionResult<List<PaymentDTO>>> GetPayments(int orderId)
        {
            return Ok(await _orderManager.GetAllPayments(orderId));
        }

        [HttpGet("{orderId}/payments/{paymentId}")]
        public async Task<ActionResult<List<PaymentDTO>>> GetOrderPaymentById(int orderId, int paymentId)
        {
            var result = await _orderManager.GetOrderPaymentById(orderId, paymentId);
            return (result != null) ? Ok(result) : NotFound();
        }

        #endregion

        #region Order Items

        [HttpGet("{orderId}/order-items")]
        public async Task<ActionResult<List<OrderItemDTO>>> GetOrderItems(int orderId)
        {
            return Ok(await _orderManager.GetAllOrderItems(orderId));
        }

        [HttpGet("{orderId}/order-items/{orderItemId}")]
        public async Task<ActionResult<List<OrderItemDTO>>> GetOrderOrderItemById(int orderId, int orderItemId)
        {
            var result = await _orderManager.GetOrderOrderItemById(orderId, orderItemId);
            return (result != null) ? Ok(result) : NotFound();
        }

        #endregion
    }
}
