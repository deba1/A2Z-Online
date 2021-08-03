using API.Managers;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PaymentsController : BaseController
    {
        private readonly IPaymentManager _paymentManager;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentManager paymentManager, IMapper mapper)
        {
            _mapper = mapper;
            _paymentManager = paymentManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAll()
        {
            return Ok(await _paymentManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetById(int id)
        {
            var payment = await _paymentManager.GetById(id);

            return (payment == null) ? NotFound() : Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> Add([FromBody] PaymentDTO paymentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payment = _mapper.Map<Payment>(paymentDTO);
            await _paymentManager.Add(payment);

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
            payment = _mapper.Map(paymentDTO, payment);
            await _paymentManager.Update(payment);

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
