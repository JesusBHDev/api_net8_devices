namespace DivicesSesorApi.DTOs
{
    public class TemperatureSensorDTO
    {
        public int Id { get; set; }
        public string SensorName { get; set; }
        public bool IsOnline { get; set; }
        public decimal? LastTemperature { get; set; }
    }
}
