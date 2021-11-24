using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UdpTemperature;
using Newtonsoft.Json;

namespace UDP_server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("UDP server!");

            using (UdpClient socket = new UdpClient())
            {
                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 1313));

                while (true)
                {
                    IPEndPoint clientEndpoint = null;
                    byte[] received = socket.Receive(ref clientEndpoint);
                    Console.WriteLine("Client connected: " + clientEndpoint.Address);
                    string Jsonstring = Encoding.UTF8.GetString(received);
                    Console.WriteLine("PI TEAMCOOL DATA: " + Jsonstring);

                    var data = new StringContent(Jsonstring, Encoding.UTF8, "application/json");

                    var url = "https://restsensordb.azurewebsites.net/Sensor";
                    using var client = new HttpClient();

                    var response = await client.PostAsync(url, data);

                    string result = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                }
            }
        }
    }
}
