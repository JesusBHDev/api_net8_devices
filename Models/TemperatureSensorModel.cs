using System.Security.Cryptography.X509Certificates;

namespace DivicesSesorApi.Models
{
    public class TemperatureSensorModel
    {
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string? Description { get; set; }
        public string? IPAddress { get; set; }
        public bool IsOnline { get; set; }
        public decimal? LastTemperature { get; set; }
        public DateTime? LastReportAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class InformationSensor
    {
        public string SensorName { get; set; }
        public string Description { get; set; } 
        public decimal LastTemperature { get; set; }
    }

    public class SensorRegister
    {
        public string SensorName { get; set; }
        public string? Description { get; set; }
        public bool IsOnline { get; set; }

    }

    public class SensorUpdate
    {
        public int SensorId { get; set; }
        public string? SensorName { get; set; }
        public string? Description { get; set; }
        public bool IsOnline { get; set; }
    }
}
