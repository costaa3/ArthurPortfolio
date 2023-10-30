using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter.Network
{
    internal class NetworkClient : InetworkClient
    {
        public void  SendRequest(string ipAddress)
        {
            Console.WriteLine(  $"Network request sent to Ip: {ipAddress}");
        }
    }
}
