using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UdpTemperature;

namespace UDP_server
{
    class SensorWork
    {
        public async Task<IEnumerable<SensorTemperature>> GetAllItmesTask()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://sensordatarest.azurewebsites.net/api/Sensor");
                IEnumerable<SensorTemperature> Sensor = await response.Content.ReadFromJsonAsync<IEnumerable<SensorTemperature>>();
                return Sensor;
            }
        }

        public async Task<SensorTemperature> PostItem(SensorTemperature sensor)
        {
            using (HttpClient client = new HttpClient())
            {
                JsonContent serialzedSensor = JsonContent.Create(sensor);
                HttpResponseMessage response = await client.PostAsync("https://sensordatarest.azurewebsites.net/api/Sensor", serialzedSensor);
                return await response.Content.ReadFromJsonAsync<SensorTemperature>();
            }
        }
    }
}
