using System;

namespace UdpTemperature
{
    public class SensorTemperature
    {
        public string Date { get; set;  }
        public string Temperature { get; set; }
        public string Humidity { get; set; } 
        public string RoomId { get; set; }

        public SensorTemperature(string date, string temperature, string humidity, string roomId)
        {
            Date = date;
            Temperature = temperature;
            Humidity = humidity;
            RoomId = roomId;
        }

    }
}
