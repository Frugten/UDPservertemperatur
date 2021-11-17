using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UdpTemperatur;

namespace UDP_server
{
    class SensorWork
    {
        public async Task<IEnumerable<SensorTemperatur>> GetAllItmesTask()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://sensordatarest.azurewebsites.net/api/Sensor");
                IEnumerable<SensorTemperatur> Sensor = await response.Content.ReadFromJsonAsync<IEnumerable<SensorTemperatur>>();
                return Sensor;
            }
        }

        public async Task<SensorTemperatur> PostItem(SensorTemperatur sensor)
        {
            using (HttpClient client = new HttpClient())
            {
                JsonContent serialzedSensor = JsonContent.Create(sensor);
                HttpResponseMessage response = await client.PostAsync("https://sensordatarest.azurewebsites.net/api/Sensor", serialzedSensor);
                return await response.Content.ReadFromJsonAsync<SensorTemperatur>();
            }
        }
    }
}
