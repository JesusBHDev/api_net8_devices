using DivicesSesorApi.Models;
using DivicesSesorApi.Repositories;

namespace DivicesSesorApi.Services
{
    // El Service representa: la lógica de negocio
    //
    public class TemperatureSensorService
    {

        private readonly TemperatureSensorRepository _repository;

        //esto esta en el prgram.cd builder.Services.AddScoped<TemperatureSensorService>();
        // "Necesito crear un Repository primero" y se crea en automatico

        public TemperatureSensorService(TemperatureSensorRepository repository)
        {
            _repository = repository;
        }

        //en el controlador se manda a llamar _service.GetLastSensorsAsync()
        //trabaja con asyn porque va consultar ala bd y debe de esperar la respuesta sin bloquear el hil
        public async Task<IEnumerable<TemperatureSensorModel>> GetLastSensorsAsync()
        {//IEnumerable<TemperatureSensorModel> Esto significa: "Una colección/lista de TemperatureSensorModel"
            //"IEnumerable == muchos objetos"
            //el service no sabe sql, dapper, controlador solo sabe pedir sensores y recibir
            return await _repository.GetLastSensorsAsync();
        }

        public async Task<IEnumerable<InformationSensor>> GetInformationEsential()
        {
            return await _repository.GetInformationSesorBasic();
        }

        public async Task<TemperatureSensorModel?>GetByIdAsycn(int id)
        {
            return await _repository.GetByAsync(id);
        }

       public async Task<int> InsertSensor(SensorRegister sensor)
       {
            return await _repository.InsertSensor(sensor);
       }

        public async Task<int> UpdateSensor(SensorUpdate sensor)
        {
            return await _repository.UpdateSensor(sensor);
        }




    }
}
