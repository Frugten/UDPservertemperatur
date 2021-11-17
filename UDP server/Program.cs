using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using UdpTemperatur;

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
                    IEnumerable<SensorTemperatur> items = myworker.GetAllItmesTask().Result;

                    IPEndPoint clientEndpoint = null;
                    byte[] received = socket.Receive(ref clientEndpoint);
                    Console.WriteLine("Client connected: " + clientEndpoint.Address);
                    Console.WriteLine("Temperatur: " + Encoding.UTF8.GetString(received));

                    SensorTemperatur newItem = new SensorTemperatur(Encoding.UTF8.GetString(received), DateTime.Now);
                    SensorTemperatur resultItem = myworker.PostItem(newItem).Result;
                    Console.WriteLine();
                }
            }
        }
    }
}
