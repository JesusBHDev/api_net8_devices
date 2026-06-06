using DivicesSesorApi.Models;
using DivicesSesorApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace DivicesSesorApi.Controllers
{
    //aqui llega la peticion
    [Route("temperature-sensor")]
    [ApiController]
    public class TemperatureSensorsController : ControllerBase
    {
        private readonly TemperatureSensorService _service;


        //Tu constructor pide esto: TemperatureSensorService service
        //"Necesito un TemperatureSensorService para poder crear el controller"
        // se hace en automaticio var service = new TemperatureSensorService(...);
        //porque se ordeno en program 
        public TemperatureSensorsController(TemperatureSensorService service)
        {
            _service = service;
        }

        //el get se ejecuta aqui 
        [HttpGet("all-information")]
        public async Task<IActionResult> Get() //"Este método trabajará de forma asíncrona"
        {//Que NO bloquea el hilo mientras espera algo lento.
         //Un Task representa: "Una operación que terminará en el futuro" tarea
         //Qué es IActionResult?Es un tipo de respuesta HTTP. Gracias a IActionResult puedes devolver:
         //Ok() NotFound() etc en palabras  simples "Algún tipo de respuesta HTTP"


            //"Espera el resultado del Task" 
            //el service devuelve Task<IEnumerable<TemperatureSensorModel>> 
            //"Te daré los sensores después" 
            var sensors = await _service.GetLastSensorsAsync();
            //Sin await tendrías esto var sensors = _service.GetLastSensorsAsync();
            //Pero ahí sensors NO sería la lista.Sería un Task
            // Con await esperas el resultado real.

            //¿Qué hace Ok()? Crea una respuesta HTTP 200.
            return Ok(sensors);
            //Crea una respuesta HTTP 200.ASP.NET automáticamente convierte: json 
        }

        [HttpGet("basic-information")]
        public async Task<IActionResult> get()
        {
            var sensors = await _service.GetInformationEsential();

            return Ok(sensors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sensor = await _service.GetByIdAsycn(id);

            if (sensor == null)
                return NotFound();

            return Ok(sensor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SensorRegister sensor)
        {
            var id = await _service.InsertSensor(sensor);

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

    }
}