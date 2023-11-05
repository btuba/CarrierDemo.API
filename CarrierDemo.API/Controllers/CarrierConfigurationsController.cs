using CarrierDemo.BLL;
using CarrierDemo.DTOS.Requests;
using CarrierDemo.DTOS.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarrierDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : ControllerBase
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;

        public CarrierConfigurationsController(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CarrierConfigurationDisplayResponse carrier = await _carrierConfigurationService.GetCarrierConfiguration(id);
            return Ok(carrier);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var carrierConfigurations = _carrierConfigurationService.GetCarrierConfigurations();
            return Ok(carrierConfigurations);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarrierConfigurationRequest request)
        {
            if (ModelState.IsValid)
            {
                int carrierConfigurationId = await _carrierConfigurationService.AddCarrierConfiguration(request);
                return CreatedAtAction(nameof(Get), routeValues: new { id = carrierConfigurationId }, value: "Kargo konfigurasyon bilgileri eklendi!");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCarrierConfigurationRequest request)
        {
            if (!await _carrierConfigurationService.IsCarrierConfigurationExist(id))
                return NotFound(new { message = $"{id} id'li kargo firması konfigürasyonu bulunamadı." });

            if (ModelState.IsValid)
            {
                await _carrierConfigurationService.UpdateCarrierConfiguration(id, request);
                return Ok(new { message = $"{id} id'li kargo firması konfigürasyon bilgileri güncellendi." });
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _carrierConfigurationService.IsCarrierConfigurationExist(id))
            {
                await _carrierConfigurationService.DeleteCarrierConfiguration(id);
                return Ok(new { message = $"{id} id'li kargo firması konfigürasyonu silindi." });
            }
            return NotFound(new { message = $"{id} id'li kargo firması konfigürasyonu bulunamadı." });
        }
    }
}
