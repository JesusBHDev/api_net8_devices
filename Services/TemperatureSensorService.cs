using DivicesSesorApi.Models;
using DivicesSesorApi.Repositories;

namespace DivicesSesorApi.Services
{
    public class TemperatureSensorService
    {
        private readonly TemperatureSensorRepository _repository;

        public TemperatureSensorService(TemperatureSensorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TemperatureSensorModel>> GetLastSensorsAsync()
        {
            return await _repository.GetLastSensorsAsync();
        }
    }
}
