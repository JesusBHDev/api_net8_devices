using DivicesSesorApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DivicesSesorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureSensorsController : ControllerBase
    {
        private readonly TemperatureSensorService _service;

        public TemperatureSensorsController(TemperatureSensorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sensors = await _service.GetLastSensorsAsync();

            return Ok(sensors);
        }
    }
}