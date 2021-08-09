using Application.DTOs;
using Application.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            return Ok(await _productManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var product = await _productManager.GetById(id);
            return (product == null) ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Add([FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productManager.Add(productDTO);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductDTO productDTO)
        {
            var product = await _productManager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productManager.Update(product, productDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productManager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productManager.Remove(product);

            return NoContent();
        }

        #endregion

        #region Feedback
   
        [HttpGet("{productId}/feedbacks")]
        public async Task<ActionResult<List<FeedbackDTO>>> Getfeedbacks(int productId)
        {
            return Ok(await _productManager.GetAllFeedbacksProduct(productId));
        }

        [HttpGet("{productId}/feedbacks/{feedbackId}")]
        public async Task<ActionResult<List<FeedbackDTO>>> GetFeedbacksByProductId(int productId, int feedbackId)
        {
            var result = await _productManager.GetFeedbacksByProductId(productId, feedbackId);
            return (result != null) ? Ok(result) : NotFound();
        }
        #endregion

        #region Inventory
        [HttpGet("{productId}/inventory")]
        public async Task<ActionResult<List<InventoryDTO>>> GetAllInventory(int productId)
        {
            return Ok(await _productManager.GetAllInventory(productId));
        }

        [HttpGet("{productId}/inventory/{inventoryId}")]
        public async Task<ActionResult<List<InventoryDTO>>> GetProductInventorytById(int productId, int inventoryId)
        {
            var result = await _productManager.GetProductInventoryById(productId, inventoryId);
            return (result != null) ? Ok(result) : NotFound();
        }
        #endregion
    }
}
