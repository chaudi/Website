using System;

namespace Cederfelt.se.DataAccess.Models
{
    public class Temperature 
    {
        public int TemperatureId { get; set; }
        public double Measurement { get; set; }
        public double Humidity { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
