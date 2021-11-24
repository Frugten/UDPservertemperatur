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

        public async Task<StringContent> PostItem(string sensor)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent serialzedSensor = new StringContent(sensor, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsJsonAsync("https://restsensordb.azurewebsites.net/Sensor", serialzedSensor);
                return await response.Content.ReadFromJsonAsync<StringContent>();
            }
        }
    }
}
