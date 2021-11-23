using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using UdpTemperature;

namespace UDP_server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP server!");

            using (UdpClient socket = new UdpClient())
            {
                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 7010));

                while (true)
                {
                    SensorWork myworker = new SensorWork();
                    IEnumerable<SensorTemperature> items = myworker.GetAllItmesTask().Result;

                    IPEndPoint clientEndpoint = null;
                    byte[] received = socket.Receive(ref clientEndpoint);
                    Console.WriteLine("Client connected: " + clientEndpoint.Address);
                    Console.WriteLine("PI TEAMCOOL DATA: " + Encoding.UTF8.GetString(received));


                    SensorTemperature newItem = new SensorTemperature(Encoding.UTF8.GetString(received),Encoding.UTF8.GetString(received), Encoding.UTF8.GetString(received), Encoding.UTF8.GetString(received));
                    SensorTemperature resultItem = myworker.PostItem(newItem).Result;
                    Console.WriteLine();
                }
            }
        }
    }
}
