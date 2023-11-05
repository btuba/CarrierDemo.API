using CarrierDemo.BLL;
using CarrierDemo.DTOS.Requests;
using CarrierDemo.DTOS.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarrierDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        private readonly ICarrierService _carrierService;

        public CarriersController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CarrierDisplayResponse carrier = await _carrierService.GetCarrier(id);
            return Ok(carrier);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var carriers = _carrierService.GetCarriers();
            return Ok(carriers);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarrierRequest request)
        {
            if (ModelState.IsValid)
            {
                int carrierId = await _carrierService.AddCarrier(request);
                return CreatedAtAction(nameof(Get), routeValues: new { id = carrierId }, value: "Kargo bilgileri eklendi!");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCarrierRequest request)
        {
            if (!await _carrierService.IsCarrierExist(id))
                return NotFound(new { message = $"{id} id'li kargo firması bulunamadı." });

            if (ModelState.IsValid)
            {
                await _carrierService.UpdateCarrier(id, request);
                return Ok(new { message = $"{id} id'li kargo firması bilgileri güncellendi." });
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _carrierService.IsCarrierExist(id))
            {
                await _carrierService.DeleteCarrier(id);
                return Ok(new { message = $"{id} id'li kargo firması silindi." });
            }
            return NotFound(new { message = $"{id} id'li kargo firması bulunamadı." });
        }
    }
}
