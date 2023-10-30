using DesignPatterns.Adapter.Data_processor;
using DesignPatterns.Adapter.Network;
using DesignPatterns.Facade;
using DesignPatterns.Factory.NetworkFactory;
using DesignPatterns.Factory.NetworkUtility;
using DesignPatterns.Factory.NetworkUtility.Interface;
using DesignPatterns.SingletonLecture;
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
            //RunSingleton();
            //RunFactory();
            //RunFacade();
            RunAdapter();
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

        public static void RunSingleton() {
            Singleton instance = Singleton.Instance();
            Singleton instance2 = Singleton.Instance();

            if (instance==instance2)
            {
                Console.WriteLine("Same memory address");

            }
        }

        public static void RunFacade()
        {
            NetworkFacade networkFacade = new NetworkFacade("192.168.0.0", "UDP");
            networkFacade.buildNetworkLayer();
            networkFacade.sendPacketOverNetwor();

        }

        public static void RunAdapter()
        {
            InetworkClient networkClient = new NetworkClient();

            networkClient.SendRequest("192.168.124.1");

            IDataProcessor dataProcessor = new DataProcessor();
            dataProcessor.sendNetworkRequest("192.168.124.1", "123asd131asda");


            NetworkAdapter networkAdapter = new NetworkAdapter(dataProcessor);
            networkAdapter.SendRequest("192.168.124.1");

        }
    
    }
}
