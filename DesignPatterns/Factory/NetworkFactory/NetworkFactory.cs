using DesignPatterns.Factory.NetworkUtility;
using DesignPatterns.Factory.NetworkUtility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.NetworkFactory
{
    internal class NetworkFactory
    {

        public Inetwork GetInetwork(string type) {

            Inetwork inetwork = null;
            switch (type.ToLower())
            {
                case "arp":
                    inetwork = new ARP();
                    break;
                case "dns":
                    inetwork = new DNS();
                    break;
                case "ping":
                    inetwork = new Ping();
                    break;
                default:
                    Console.WriteLine("type not found");
                    break;
                      
            }
            return inetwork;
        }
    }
}
