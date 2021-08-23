using Application.DTOs.EntityDTOs;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PaymentsController : BaseController
    {
        private readonly IPaymentManager _paymentManager;

        public PaymentsController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetAll()
        {
            return Ok(await _paymentManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDTO>> GetById(int id)
        {
            var payment = await _paymentManager.GetById(id);

            return (payment == null) ? NotFound() : Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDTO>> Add([FromBody] PaymentDTO paymentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payment = await _paymentManager.Add(paymentDTO);

            return CreatedAtAction(nameof(GetById), new { id = payment.Id }, payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PaymentDTO paymentDTO)
        {
            var payment = await _paymentManager.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            await _paymentManager.Update(payment, paymentDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var payment = await _paymentManager.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            await _paymentManager.Remove(payment);

            return NoContent();
        }

        #endregion
    }
}
