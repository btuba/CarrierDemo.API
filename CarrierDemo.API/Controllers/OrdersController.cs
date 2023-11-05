using CarrierDemo.BLL;
using CarrierDemo.DTOS.Requests;
using CarrierDemo.DTOS.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarrierDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddOrderRequest request)
        {
            if (ModelState.IsValid)
            {
                int orderId = await _orderService.AddOrder(request);
                return Ok(new { message = $"Kargo bilgileri eklendi!" });
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _orderService.IsOrderExist(id))
            {
                await _orderService.DeleteOrder(id);
                return Ok(new { message = $"{id} id'li kargo firması silindi." });
            }
            return NotFound(new { message = $"{id} id'li kargo firması bulunamadı." });
        }
    }
}
