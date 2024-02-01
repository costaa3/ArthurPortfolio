using System;

namespace DesignPatterns.Adapter.Network
{
    internal class NetworkClient : InetworkClient
    {
        public void SendRequest(string ipAddress)
        {
            Console.WriteLine($"Network request sent to Ip: {ipAddress}");
        }
    }
}
