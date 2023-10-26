using DesignPatterns.Factory.NetworkFactory;
using DesignPatterns.Factory.NetworkUtility;
using DesignPatterns.Factory.NetworkUtility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunFactory();
            Console.ReadLine();
        }
    
        public static void RunFactory() {
            NetworkFactory networkFactory = new NetworkFactory();
            
            Inetwork ping = networkFactory.GetInetwork("PING");
            Inetwork dns = networkFactory.GetInetwork("DNS");
            Inetwork arp = networkFactory.GetInetwork("ARP");

            ping.SendRequest(@"192.168.2.2", 2);
            dns.SendRequest(@"192.168.2.2", 2);
            arp.SendRequest(@"192.168.2.2", 2);
        }
    
    }
}
